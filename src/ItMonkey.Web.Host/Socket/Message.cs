using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
        public string Type { get; set; }
        /// <summary>
        /// 内容
        /// </summary>
        public string Content { get; set; }
    }
}
