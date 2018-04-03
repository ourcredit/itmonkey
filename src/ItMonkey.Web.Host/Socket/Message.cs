using System;
using ItMonkey.Models;

namespace ItMonkey.Web.Host.Socket
{
    /// <summary>
    /// 消息体
    /// </summary>
    public class Message
    {
        /// <summary>
        /// 发送人
        /// </summary>
        public string SenderId { get; set; }
        /// <summary>
        /// 接收人
        /// </summary>
        public string ReceiverId { get; set; }
        /// <summary>
        /// 类型
        /// </summary>
        public MessageType Type { get; set; }
        /// <summary>
        /// 内容
        /// </summary>
        public string Content { get; set; }
        /// <summary>
        /// 接受时间
        /// </summary>
        public DateTime ReciveTime { get; set; }
    }

  
}
