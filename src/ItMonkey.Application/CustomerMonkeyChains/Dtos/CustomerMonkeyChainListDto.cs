using System;
using Abp.Application.Services.Dto;
using ItMonkey.Models.MonkeyChain;

namespace ItMonkey.CustomerMonkeyChains.Dtos
{
    public class CustomerMonkeyChainListDto
    {
        ////BCC/ BEGIN CUSTOM CODE SECTION
        ////ECC/ END CUSTOM CODE SECTION
        public long CustomerId { get; set; }
        public Guid Hash { get; set; }
    }
}