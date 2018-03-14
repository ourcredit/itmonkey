using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;

namespace ItMonkey.Models
{
    /// <summary>
    /// 人参与的工作实例
    /// </summary>
    [Table("m_customer_job")]
    public class CustomerJob : CreationAuditedEntity, ISoftDelete
    {
        public int JobId { get; set; }
        public virtual Job Job { get; set; }
        public long CustomerId { get; set; }
        public virtual Customer Customer { get; set; }
        public int State { get; set; }
        public bool IsDeleted { get; set; }
    }
}
