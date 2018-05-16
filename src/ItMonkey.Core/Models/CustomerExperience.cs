using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Abp.Domain.Entities.Auditing;

namespace ItMonkey.Models
{
    /// <summary>
    /// 用户工作经验
    /// </summary>
    [Table("m_customer_experience")]
   public class CustomerExperience:CreationAuditedEntity
    {
        /// <summary>
        /// 客户id
        /// </summary>
        public long CustomerId  { get; set; }
        /// <summary>
        /// 工作经验标题
        /// </summary>
        [Required,MaxLength(100)]

        public string Title { get; set; }
        /// <summary>
        /// 工作经验内容
        /// </summary>
        [Required,MaxLength(1000)]
        public string Content { get; set; }
    }
   
}
