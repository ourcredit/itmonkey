using System;
using Abp.Application.Services.Dto;
using ItMonkey.Models;

namespace ItMonkey.CustomerAddresss.Dtos
{
    public class CustomerAddressListDto
    {
        ////BCC/ BEGIN CUSTOM CODE SECTION
        ////ECC/ END CUSTOM CODE SECTION
        public string OpenId { get; set; }
        public string Consignee { get; set; }
        public string Mobile { get; set; }
        public string Address { get; set; }
        public bool IsDefault { get; set; }
    }
}