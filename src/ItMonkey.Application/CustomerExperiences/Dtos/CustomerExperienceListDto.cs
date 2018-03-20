using System;
using Abp.Application.Services.Dto;
using ItMonkey.Models;

namespace ItMonkey.CustomerExperiences.Dtos
{
    public class CustomerExperienceListDto
    {
        public int Id { get; set; }
        ////BCC/ BEGIN CUSTOM CODE SECTION
        ////ECC/ END CUSTOM CODE SECTION
        public long CustomerId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
    }
}