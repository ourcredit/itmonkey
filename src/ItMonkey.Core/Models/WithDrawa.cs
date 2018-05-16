using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Abp.Domain.Entities.Auditing;

namespace ItMonkey.Models
{
    /// <summary>
    /// 提现信息
    /// </summary>
    [Table("m_withdrawa")]
   public class WithDrawa:CreationAuditedEntity<Guid>
    {
        /// <summary>
        /// 客户id
        /// </summary>
        public int CustomerId { get; set; }
        /// <summary>
        /// 客户信息
        /// </summary>
        public  virtual  Customer Customer { get; set; }
        /// <summary>
        /// 提现金额
        /// </summary>
        public int WithDrawaValue { get; set; }
        /// <summary>
        /// 税费
        /// </summary>
        public int TaxesFee { get; set; }
        /// <summary>
        /// 服务费
        /// </summary>
        public int ServiceFee { get; set; }
        /// <summary>
        /// 提现状态
        /// </summary>
        public bool? State { get; set; }
    }
}
