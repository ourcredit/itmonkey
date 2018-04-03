using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.WebSockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Abp.Extensions;
using Abp.Logging;
using ItMonkey.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace ItMonkey.Web.Host.Socket
{
    public class SocketHandler
    {
        public class Point
        {
            public string Key { get; set; }
            public WebSocket Socket { get; set; }
        }
        public class Group
        {
            public string Key { get; set; }
            public List<Point> Sockets { get; set; }
        }
        /// <summary>
        /// 人员socket集合
        /// </summary>
        private static readonly ConcurrentBag<Point> Points =
            new ConcurrentBag<Point>();


        private static readonly ConcurrentBag<Group> Groups =
            new ConcurrentBag<Group>();
        private static readonly ConcurrentBag<Group> Jobs =
            new ConcurrentBag<Group>();
        public const int BufferSize = 4096;
        public static object ObjLock = new object();
        public static List<Message> HistoricalMessg = new List<Message>();//存放历史消息


        private static async Task DealSocketType(string job,string group, Point point)
        {
            if (Points.Count > 100)
            {
                await point.Socket.CloseAsync(WebSocketCloseStatus.PolicyViolation, "超过上限", CancellationToken.None);
                return;
            }

            if (!Points.Contains(point))
            {
                lock (ObjLock)
                {
                    Points.Add(point);
                }

            }
          
            if (!group.IsNullOrWhiteSpace())
            {
                if (Groups.Count > 100)
                {
                    await point.Socket.CloseAsync(WebSocketCloseStatus.PolicyViolation, "超过上限", CancellationToken.None);
                    return;
                }
                var p = Groups.FirstOrDefault(c => c.Key == group);
                if (p == null)
                {
                    p = new Group()
                    {
                        Key = group,
                        Sockets = new List<Point>()
                        {
                            point
                        }
                    };
                    Groups.Add(p);
                }
                else
                {
                    if (!p.Sockets.Contains(point))
                    {
                        lock (ObjLock)
                        {
                            p.Sockets.Add(point);
                        }
                    }
                }
            }
            if (!job.IsNullOrWhiteSpace())
            {
                if (Jobs.Count > 100)
                {
                    await point.Socket.CloseAsync(WebSocketCloseStatus.PolicyViolation, "超过上限", CancellationToken.None);
                    return;
                }
                var p = Jobs.FirstOrDefault(c => c.Key == job);
                if (p == null)
                {
                    p = new Group()
                    {
                        Key = job,
                        Sockets = new List<Point>()
                        {
                            point
                        }
                    };
                    Jobs.Add(p);
                }
                else
                {
                    if (!p.Sockets.Contains(point))
                    {
                        lock (ObjLock)
                        {
                            p.Sockets.Add(point);
                        }
                    }
                }
            }
        }
        /// <summary>
        /// 接收请求
        /// </summary>
        /// <param name="httpContext"></param>
        /// <param name="n"></param>
        /// <returns></returns>
        static async Task Acceptor(HttpContext httpContext, Func<Task> n)
        {
            if (!httpContext.WebSockets.IsWebSocketRequest)
                return;

            //建立一个WebSocket连接请求
            var socket = await httpContext.WebSockets.AcceptWebSocketAsync();
            string user = httpContext.Request.Query["user"].ToString();
            string job = httpContext.Request.Query["job"].ToString();
            string group = httpContext.Request.Query["group"].ToString();
            //判断最大连接数
            //if (Sockets.Count >= 100)
            //{
            //    await socket.CloseAsync(WebSocketCloseStatus.PolicyViolation, "超过上限", CancellationToken.None);
            //    return;
            //}
            //if (!Sockets.ContainsKey(socketId))
            //{
            //    lock (ObjLock)
            //    {
            //        Sockets.TryAdd(socketId, socket);
            //    }
            //}
            Point point=new Point()
            {
                Key= user,
                Socket = socket
            };
            await DealSocketType(job,group, point);
            var buffer = new byte[BufferSize];
            Message msg;
            while (true)
            {
                try
                {
                    //建立连接，阻塞等待接收消息
                    var incoming = await socket.ReceiveAsync(new ArraySegment<byte>(buffer), CancellationToken.None);
                    //如果主动退出，则移除
                    if (incoming.MessageType == WebSocketMessageType.Close)//incoming.CloseStatus == WebSocketCloseStatus.EndpointUnavailable WebSocketCloseStatus.NormalClosure)
                    {
                        lock (ObjLock)
                        {
                            Points.TryTake(out point);
                           // Sockets.TryRemove(socketId, out socket);//移除   
                        }
                        break; //【注意】：：这里一定要记得 跳出循环 （坑了好久）
                    }
                    //转字符串，然后序列化，然后赋值，然后再序列化
                    var chatDataStr = await ArraySegmentToStringAsync(new ArraySegment<byte>(buffer, 0, incoming.Count));
                    if (chatDataStr == "@heart")//如果是心跳检查，则直接跳过
                        continue;
                    msg = JsonConvert.DeserializeObject<Message>(chatDataStr);
                
                    await SendToWebSocketsAsync( msg);
                }
                catch (Exception ex) //因为 nginx 没有数据传输 会自动断开 然后就会异常。
                {
                    LogHelper.Logger.Error(ex.Message);
                    Points.TryTake(out point);//移除  
                    //【注意】：：这里很重要 （如果不发送关闭会一直循环，且不能直接break。）
                    await socket.CloseAsync(WebSocketCloseStatus.PolicyViolation, "未知异常 ...", CancellationToken.None);
                    // 后面 就不走了？ CloseAsync也不能 try 包起来？
                }
            }
        }

        /// <summary>
        /// 发送消息到所有人
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static async Task SendToWebSocketsAsync(Message data)
        {
            SaveHistoricalMessg(data);//保存历史消息
           var list=new List<Point>();
            if (data.Type == MessageType.P2P)
            {
                list = Points.Where(c => c.Key == data.SenderId || c.Key == data.ReceiverId).ToList();
            }
            if (data.Type == MessageType.Group)
            {
                list = Groups.Where(c => c.Key == data.ReceiverId).SelectMany(c => c.Sockets).ToList();
            }
            if (data.Type == MessageType.Job)
            {
                list = Jobs.Where(c => c.Key == data.ReceiverId).SelectMany(c => c.Sockets).ToList();
            }
            var chatData = JsonConvert.SerializeObject(data);
            var buffer = Encoding.UTF8.GetBytes(chatData);
            ArraySegment<byte> arraySegment = new ArraySegment<byte>(buffer);
            //循环发送消息
            foreach (var temp in list)
            {
                if (temp.Socket.State == WebSocketState.Open)
                {
                    //发送消息
                    await temp.Socket.SendAsync(arraySegment, WebSocketMessageType.Text, true, CancellationToken.None);
                }
            }
        }

        static readonly object LockSaveMsg = new object();

        /// <summary>
        /// 保存历史消息
        /// </summary>
        /// <param name="data"></param>
        public static void SaveHistoricalMessg(Message data)
        {
            var size = 5;
            lock (LockSaveMsg)
            {
                data.ReciveTime=DateTime.Now;
                HistoricalMessg.Add(data);
            }
            if (HistoricalMessg.Count >= size)
            {
                lock (LockSaveMsg)
                {
                    SaveToDb(HistoricalMessg);
                    HistoricalMessg.Clear();
                }
            }
        }

        public static void SaveToDb(List<Message> list)
        {
            var sql = @"INSERT INTO `itmonkey`.`s_message_store`
(`Content`, `CreationTime`,`ReceiverId`, `SenderId`, `State`, `Type` )
VALUES
	";
            list.ForEach(c =>
            {
                var time = c.ReciveTime.ToString("yyyy/MM/dd HH:mm:ss");
                sql += $"('{c.Content}', '{time}', {c.ReceiverId}, {c.SenderId}, 0,{(int)c.Type}),";
            });
            DapperHelper.Execute(sql.TrimEnd(','));
        }
        #region
        /// <summary>
        /// 转字符串
        /// </summary>
        /// <param name="arraySegment"></param>
        /// <returns></returns>
        static async Task<string> ArraySegmentToStringAsync(ArraySegment<byte> arraySegment)
        {
            using (var ms = new MemoryStream())
            {
                ms.Write(arraySegment.Array, arraySegment.Offset, arraySegment.Count);
                ms.Seek(0, SeekOrigin.Begin);
                using (var reader = new StreamReader(ms, Encoding.UTF8))
                {
                    return await reader.ReadToEndAsync();
                }
            }
        }
        #endregion
        /// <summary>
        /// 请求
        /// </summary>
        /// <param name="app"></param>
        public static void Map(IApplicationBuilder app)
        {
            // app.UseWebSockets(); //nuget   导入 Microsoft.AspNetCore.WebSockets.Server
            app.Use(Acceptor);
        }


    }
}
