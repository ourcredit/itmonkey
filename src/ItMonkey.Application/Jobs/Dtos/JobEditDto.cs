using System.ComponentModel.DataAnnotations;
using ItMonkey.Models;

namespace ItMonkey.Jobs.Dtos
{
    public class JobEditDto
    {
        ////BCC/ BEGIN CUSTOM CODE SECTION
        ////ECC/ END CUSTOM CODE SECTION
        public int? Id { get; set; }
        /// <summary>
        /// 工作名称
        /// </summary>
        [Required, MaxLength(200)]
        public string Name { get; set; }
        public string Content { get; set; }
        public string Category { get; set; }
        public int Price { get; set; }
        public bool IsDeleted { get; set; }
    }
}