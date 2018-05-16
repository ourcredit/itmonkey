using System;
using System.ComponentModel.DataAnnotations.Schema;
using Abp.Domain.Entities.Auditing;

namespace ItMonkey.Models
{
    /// <summary>
    /// 订单
    /// </summary>
    [Table("m_order")]
    public   class Order : CreationAuditedEntity<Guid>
    {
        /// <summary>
        /// 下单人key
        /// </summary>
        public string OpenId { get; set; }

        public string Buyer { get; set; }
        /// <summary>
        /// 价格
        /// </summary>
        public int Price { get; set; }
        /// <summary>
        /// 数量
        /// </summary>
        public int Count { get; set; }
        /// <summary>
        /// 微信订单
        /// </summary>
        public string WeChatOrder  { get; set; }
        /// <summary>
        /// 订单类型  购买猿人比 等
        /// </summary>
        public string OrderType { get; set; }
        /// <summary>
        /// 收货人信息对象
        /// </summary>
        public string PostInfo { get; set; }
        /// <summary>
        /// 支付状态
        /// </summary>
        public bool? PayState { get; set; }
        /// <summary>
        /// 发货状态
        /// </summary>
        public bool? State { get; set; }
    }
}
