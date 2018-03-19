using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Abp.Domain.Entities.Auditing;

namespace ItMonkey.Models
{
    /// <summary>
    /// 家族
    /// </summary>
    [Table("m_family")]
    public class Family : CreationAuditedEntity
    {
        public string Name { get; set; }
        public string Key { get; set; }
        public int Level { get; set; }
    }
    /// <summary>
    /// 消息记录存储
    /// </summary>
    [Table("s_message_store")]
    public class MessageStore:CreationAuditedEntity<long>
    {
        public int SenderId { get; set; }
        public int ReceiverId { get; set; }
        public string Content { get; set; }
        public MessageType Type { get; set; }
        public bool State { get; set; }
       
    }
    public enum MessageType
    {
        P2P = 1,
        Group = 2
    }
}
