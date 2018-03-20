using System;
using Abp.Application.Services.Dto;
using ItMonkey.Models;

namespace ItMonkey.Jobs.Dtos
{
    public class JobListDto
    {
        public int Id { get; set; }
        ////BCC/ BEGIN CUSTOM CODE SECTION
        ////ECC/ END CUSTOM CODE SECTION
        public string Name { get; set; }
        public string Content { get; set; }
        public bool IsSecert { get; set; }
        public string Category { get; set; }
        public int Price { get; set; }
        public int FirstGrade { get; set; }
        public int SecondGrade { get; set; }
        public int ThirdGrade { get; set; }
    }
}