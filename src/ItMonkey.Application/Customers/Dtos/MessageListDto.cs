using System;
using System.Collections.Generic;
using System.Text;
using ItMonkey.Models;

namespace ItMonkey.Customers.Dtos
{
   public class MessageListDto
    {
        public Guid Id { get; set; }
        public long SenderId { get; set; }
        public string SenderName { get; set; }
        public long ReceiverId { get; set; }
        public string ReceiverName { get; set; }
        public string Content { get; set; }
        public MessageType Type { get; set; }
        public bool State { get; set; }
    }
}
