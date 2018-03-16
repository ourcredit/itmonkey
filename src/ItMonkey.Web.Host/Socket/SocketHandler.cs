﻿using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.WebSockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Abp.Logging;
using ItMonkey.Web.Host.Startup;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace ItMonkey.Web.Host.Socket
{
    public class SocketHandler
    {
        private static readonly ConcurrentDictionary<string, WebSocket> Sockets =
            new ConcurrentDictionary<string, WebSocket>();
        public const int BufferSize = 4096;
        public static object ObjLock = new object();
        public static List<string> HistoricalMessg = new List<string>();//存放历史消息

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
            //判断最大连接数
            if (Sockets.Count >= 100)
            {
                await socket.CloseAsync(WebSocketCloseStatus.PolicyViolation, "超过上限", CancellationToken.None);
                return;
            }
            string socketId = httpContext.Request.Query["guid"].ToString();
            if (!Sockets.ContainsKey(socketId))
            {
                lock (ObjLock)
                {
                    Sockets.TryAdd(socketId, socket);
                }
            }
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
                            Sockets.TryRemove(socketId,out socket);//移除   
                        }
                        break; //【注意】：：这里一定要记得 跳出循环 （坑了好久）
                    }
                    //转字符串，然后序列化，然后赋值，然后再序列化
                    var chatDataStr = await ArraySegmentToStringAsync(new ArraySegment<byte>(buffer, 0, incoming.Count));
                    if (chatDataStr == "@heart")//如果是心跳检查，则直接跳过
                        continue;
                  //  msg = JsonConvert.DeserializeObject<Message>(chatDataStr);
                    await SendToWebSocketsAsync(Sockets.Where(t => t.Key == socketId).Select(c=>c.Value).ToList(), chatDataStr);
                }
                catch (Exception ex) //因为 nginx 没有数据传输 会自动断开 然后就会异常。
                {
                    LogHelper.Logger.Error(ex.Message);
                    Sockets.TryRemove(socketId, out socket);//移除  
                    //【注意】：：这里很重要 （如果不发送关闭会一直循环，且不能直接break。）
                    await socket.CloseAsync(WebSocketCloseStatus.PolicyViolation, "未知异常 ...", CancellationToken.None);
                    // 后面 就不走了？ CloseAsync也不能 try 包起来？
                }
            }
        }

        /// <summary>
        /// 发送消息到所有人
        /// </summary>
        /// <param name="sockets"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        public static async Task SendToWebSocketsAsync(List<WebSocket> sockets, string data)
        {
            SaveHistoricalMessg(data);//保存历史消息
          //  var chatData = JsonConvert.SerializeObject(data);
            var buffer = Encoding.UTF8.GetBytes(data);
            ArraySegment<byte> arraySegment = new ArraySegment<byte>(buffer);
            //循环发送消息
            foreach (var tempsocket in sockets)
            {
                if (tempsocket.State == WebSocketState.Open)
                {
                    //发送消息
                    await tempsocket.SendAsync(arraySegment, WebSocketMessageType.Text, true, CancellationToken.None);
                }
            }
        }

        static readonly object LockSaveMsg = new object();
        /// <summary>
        /// 保存历史消息
        /// </summary>
        /// <param name="data"></param>
        public static void SaveHistoricalMessg(string data)
        {
            var size = 40;
            lock (LockSaveMsg)
            {
                HistoricalMessg.Add(data);
            }
            if (HistoricalMessg.Count >= size)
            {
                lock (LockSaveMsg)
                {
                    HistoricalMessg.RemoveRange(0, 30);
                }
            }
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
            app.UseWebSockets(); //nuget   导入 Microsoft.AspNetCore.WebSockets.Server
            app.Use(Acceptor);
        }

       
    }
}
