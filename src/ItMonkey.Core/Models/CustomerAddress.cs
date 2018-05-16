using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Abp.Domain.Entities.Auditing;

namespace ItMonkey.Models
{
    /// <summary>
    /// 用户地址信息
    /// </summary>
    [Table("m_customer_address")]
    public class CustomerAddress : CreationAuditedEntity
    {
        /// <summary>
        /// 人员唯一编号
        /// </summary>
        public string OpenId { get; set; }
        /// <summary>
        /// 收货人姓名
        /// </summary>
        public string Consignee { get; set; }
        /// <summary>
        /// 手机
        /// </summary>
        public string Mobile { get; set; }
        /// <summary>
        /// 地址
        /// </summary>
        public string Address { get; set; }
        /// <summary>
        /// 是否默认
        /// </summary>
        public bool IsDefault { get; set; }
    }
}
