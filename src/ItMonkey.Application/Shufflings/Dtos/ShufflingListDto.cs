using System;
using Abp.Application.Services.Dto;
using ItMonkey.Models;

namespace ItMonkey.Shufflings.Dtos
{
    public class ShufflingListDto : CreationAuditedEntityDto
    {
        ////BCC/ BEGIN CUSTOM CODE SECTION
        ////ECC/ END CUSTOM CODE SECTION
        public string Title { get; set; }
        public string ImageUrl { get; set; }
        public string Path { get; set; }
        public bool IsActive { get; set; }
    }
}