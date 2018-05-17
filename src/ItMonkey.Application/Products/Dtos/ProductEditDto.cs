using System;
using System.ComponentModel.DataAnnotations;
using ItMonkey.Models;

namespace ItMonkey.Products.Dtos
{
    public class ProductEditDto
    {
        ////BCC/ BEGIN CUSTOM CODE SECTION
        ////ECC/ END CUSTOM CODE SECTION
        public Guid? Id { get; set; }
        /// <summary>
        /// 商品名称
        /// </summary>
        [Required, MaxLength(200)]
        public string ProductName { get; set; }
        public string ProductImage { get; set; }
        public int Price { get; set; }
        public string ProductDescription { get; set; }
        /// <summary>
        /// 是否猿人币结算
        /// </summary>
        public bool MonkeyCionDeal { get; set; }
        /// <summary>
        /// 启用禁用
        /// </summary>
        public bool IsActive { get; set; }
        public int ProductCount { get; set; }
    }
}