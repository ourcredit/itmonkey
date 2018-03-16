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
        /// <summary>
        /// 工作id
        /// </summary>
        public int JobId { get; set; }
        /// <summary>
        /// 工作对象
        /// </summary>
        public virtual Job Job { get; set; }
        /// <summary>
        /// 用户id
        /// </summary>
        public long CustomerId { get; set; }
        /// <summary>
        /// 用户对象
        /// </summary>
        public virtual Customer Customer { get; set; }
        /// <summary>
        /// 工作状态
        /// </summary>
        public int State { get; set; }
        /// <summary>
        /// 是否删除
        /// </summary>
        public bool IsDeleted { get; set; }
    }
}
