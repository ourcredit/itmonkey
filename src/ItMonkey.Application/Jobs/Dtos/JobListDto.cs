using System;
using Abp.Application.Services.Dto;
using ItMonkey.Jobs.Dtos.LTMAutoMapper;
using ItMonkey.Models;

namespace ItMonkey.Jobs.Dtos
{
    public class JobListDto
    {
        ////BCC/ BEGIN CUSTOM CODE SECTION
        ////ECC/ END CUSTOM CODE SECTION
        public string Name { get; set; }
        public string Content { get; set; }
        public string Category { get; set; }
        public int Price { get; set; }
        public bool IsDeleted { get; set; }
    }
}