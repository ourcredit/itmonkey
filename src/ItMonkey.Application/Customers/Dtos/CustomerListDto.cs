using System;
using Abp.Application.Services.Dto;
using ItMonkey.Models;

namespace ItMonkey.Customers.Dtos
{
    public class CustomerListDto
    {
        public string Name { get; set; }
        public string Key { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
    }
}