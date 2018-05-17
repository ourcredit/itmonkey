using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Abp.Domain.Entities.Auditing;

namespace ItMonkey.Models
{
    /// <summary>
    /// 商品列表
    /// </summary>
    [Table("m_product")]
   public class Product: CreationAuditedEntity<Guid>
    {
        /// <summary>
        /// 商品名称
        /// </summary>
        [Required,MaxLength(200)]
        public string ProductName { get; set; }
        /// <summary>
        /// 商品图片
        /// </summary>
        public string ProductImage { get; set; }
        /// <summary>
        /// 上架下架
        /// </summary>
        public bool IsActive { get; set; }
        /// <summary>
        /// 价格
        /// </summary>
        public int Price { get; set; }
        /// <summary>
        /// 商品描述
        /// </summary>
        public string ProductDescription { get; set; }
        /// <summary>
        /// 是否猿人币结算
        /// </summary>
        public bool MonkeyCionDeal { get; set; }
        /// <summary>
        /// 数量
        /// </summary>
        public int ProductCount { get; set; }
    }
    /// <summary>
    /// 结算方式枚举
    /// </summary>
    public enum SettlementType
    {
        Cash=1, MonkeyCion=2
    }
}
