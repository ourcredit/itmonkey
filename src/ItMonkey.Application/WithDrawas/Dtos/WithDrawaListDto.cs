using System;
using Abp.Application.Services.Dto;
using ItMonkey.Models;

namespace ItMonkey.WithDrawas.Dtos
{
    public class WithDrawaListDto
    {
        ////BCC/ BEGIN CUSTOM CODE SECTION
        ////ECC/ END CUSTOM CODE SECTION
        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
        public string CustomerAvatarUrl { get; set; }
        public string CustomerFamily { get; set; }
        public int WithDrawaValue { get; set; }
        public int TaxesFee { get; set; }
        public int ServiceFee { get; set; }
        public bool? State { get; set; }
    }
}