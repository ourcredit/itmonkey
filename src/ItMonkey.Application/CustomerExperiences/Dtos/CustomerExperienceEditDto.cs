using System.ComponentModel.DataAnnotations;
using ItMonkey.Models;

namespace ItMonkey.CustomerExperiences.Dtos
{
    public class CustomerExperienceEditDto
    {
        ////BCC/ BEGIN CUSTOM CODE SECTION
        ////ECC/ END CUSTOM CODE SECTION
        public int? Id { get; set; }
        public long CustomerId { get; set; }

        /// <summary>
        /// 工作经验标题
        /// </summary>
        [Required, MaxLength(100)]
        public string Title { get; set; }

        /// <summary>
        /// 工作经验内容
        /// </summary>
        [Required, MaxLength(1000)]
        public string Content { get; set; }
    }
}