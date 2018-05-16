using System.ComponentModel.DataAnnotations;
using ItMonkey.Models;

namespace ItMonkey.Customers.Dtos
{
    public class CustomerEditDto
    {
        ////BCC/ BEGIN CUSTOM CODE SECTION
        ////ECC/ END CUSTOM CODE SECTION
        public long? Id { get; set; }
        public string Name { get; set; }
        /// <summary>
        /// 头像
        /// </summary>
        public string AvatarUrl { get; set; }
        /// <summary>
        /// 一级技能
        /// </summary>
        public string Skill { get; set; }
        /// <summary>
        /// 二级技能
        /// </summary>
        public string ChildSkill { get; set; }
        /// <summary>
        /// 唯一标识
        /// </summary>
        [Required]
        public string Key { get; set; }

        public bool IsActive { get; set; } = true;

    }

   
}