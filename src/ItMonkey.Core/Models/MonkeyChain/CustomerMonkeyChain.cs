using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Abp.Domain.Entities.Auditing;

namespace ItMonkey.Models.MonkeyChain
{
    /// <summary>
    /// 用户持有的猿人币
    /// </summary>
    [Table("m_user_monkey_chain")]
    public class CustomerMonkeyChain : CreationAuditedEntity<Guid>
    {
        public CustomerMonkeyChain() { }
        public CustomerMonkeyChain(long id, Guid hash)
        {
            CustomerId = id;
            Hash = hash;
        }
        public long CustomerId { get; set; }
        public Guid Hash { get; set; }
    }
}
