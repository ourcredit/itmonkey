using System;
using Abp.Application.Services.Dto;
using ItMonkey.Models;

namespace ItMonkey.Products.Dtos
{
    public class ProductListDto : CreationAuditedEntityDto<Guid>
    {
        ////BCC/ BEGIN CUSTOM CODE SECTION
        ////ECC/ END CUSTOM CODE SECTION
        public string ProductName { get; set; }
        public string ProductImage { get; set; }
        public int Price { get; set; }
        public string ProductDescription { get; set; }
        public SettlementType SettlementType { get; set; }
        public int ProductCount { get; set; }
    }
}