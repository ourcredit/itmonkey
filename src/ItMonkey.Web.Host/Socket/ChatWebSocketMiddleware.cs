using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.WebSockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using Abp.Extensions;
using Abp.Logging;

namespace ItMonkey.Web.Host.Socket
{
    public class ChatWebSocketMiddleware
    {
        private static readonly ConcurrentDictionary<string, WebSocket> Sockets =
            new ConcurrentDictionary<string, WebSocket>();
        private readonly RequestDelegate _next;
        public ChatWebSocketMiddleware(RequestDelegate next)
        {
            _next = next;
        }
        public async Task Invoke(HttpContext context)
        {
            if (!context.WebSockets.IsWebSocketRequest)
            {
                await _next.Invoke(context);
                return;
            }
            CancellationToken ct = context.RequestAborted;
            var currentSocket = await context.WebSockets.AcceptWebSocketAsync();
            //string socketId = Guid.NewGuid().ToString();
            string socketId = context.Request.Query["guid"].ToString();
            if (!Sockets.ContainsKey(socketId))
            {
                Sockets.TryAdd(socketId, currentSocket);
            }
            var buffer = new byte[1024 * 4];

            while (true)
            {
                if (ct.IsCancellationRequested)
                {
                    break;
                }
                if (currentSocket.State != WebSocketState.Open) break;
                WebSocketReceiveResult result = await currentSocket.ReceiveAsync(new ArraySegment<byte>(buffer),
                    CancellationToken.None);
                string response = Encoding.UTF8.GetString(buffer);
                LogHelper.Logger.Error("----------------"+ response);

                if (string.IsNullOrEmpty(response)) continue;
                Message msg;
                try
                {
                    msg = JsonConvert.DeserializeObject<Message>(response);
                }
                catch (Exception)
                {
                    msg = new Message()
                    {
                        SenderId = "1",
                        ReceiverId = "1",
                        Type = "text",
                        Content = "hello world"
                    };
                }
                foreach (var socket in Sockets)
                {
                    if (socket.Value.State != WebSocketState.Open) continue;
                    await SendStringAsync(socket.Value, JsonConvert.SerializeObject(msg), ct);
                    if (socket.Key == msg.ReceiverId || socket.Key == socketId)
                    {
                        await SendStringAsync(socket.Value, JsonConvert.SerializeObject(msg), ct);
                    }
                }
            }
            //_sockets.TryRemove(socketId, out dummy);
            await currentSocket.CloseAsync(WebSocketCloseStatus.NormalClosure, "Closing", ct);
            currentSocket.Dispose();
        }

        private static Task SendStringAsync(WebSocket socket, string data, CancellationToken ct = default(CancellationToken))
        {
            var buffer = Encoding.UTF8.GetBytes(data);
            var segment = new ArraySegment<byte>(buffer);
            return socket.SendAsync(segment, WebSocketMessageType.Text, true, ct);
        }

        private static async Task<string> ReceiveStringAsync(WebSocket socket, CancellationToken ct = default(CancellationToken))
        {
            var buffer = new ArraySegment<byte>(new byte[8192]);
            using (var ms = new MemoryStream())
            {
                WebSocketReceiveResult result;
                do
                {
                    ct.ThrowIfCancellationRequested();

                    result = await socket.ReceiveAsync(buffer, ct);
                    ms.Write(buffer.Array, buffer.Offset, result.Count);
                }
                while (!result.EndOfMessage);
                ms.Seek(0, SeekOrigin.Begin);
                if (result.MessageType != WebSocketMessageType.Text) return null;
                using (var reader = new StreamReader(ms, Encoding.UTF8))
                {
                    return await reader.ReadToEndAsync();
                }
            }
        }
    }
}
