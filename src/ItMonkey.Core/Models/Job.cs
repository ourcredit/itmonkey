using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;

namespace ItMonkey.Models
{
    /// <summary>
    /// 工作实体
    /// </summary>
    [Table("m_job")]
   public class Job:CreationAuditedEntity,ISoftDelete
    {
        /// <summary>
        /// 工作名称
        /// </summary>
        [Required,MaxLength(200)]
        public string Name { get; set; }
        /// <summary>
        /// 描述
        /// </summary>
        public string Content { get; set; }
        /// <summary>
        /// 是否私密邀请
        /// </summary>
        public bool IsSecert { get; set; }
        /// <summary>
        /// 分类
        /// </summary>
        public string Category { get; set; }
        /// <summary>
        /// 悬赏金额
        /// </summary>
        public int Price { get; set; }
        /// <summary>
        /// 一级奖励
        /// </summary>
        public int  FirstGrade { get; set; }
        /// <summary>
        /// 二级奖励
        /// </summary>
        public int  SecondGrade { get; set; }
        /// <summary>
        /// 三级奖励
        /// </summary>
        public int  ThirdGrade { get; set; }
        /// <summary>
        /// 是否删除
        /// </summary>
        public bool IsDeleted { get; set; }
    }
  
}
