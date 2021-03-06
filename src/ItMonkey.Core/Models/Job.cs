﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System.Text;
using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;

namespace ItMonkey.Models
{
    /// <summary>
    /// 工作实体
    /// </summary>
    [Table("m_job")]
   public class Job:Entity,IHasCreationTime,ISoftDelete
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
        /// 支付状态
        /// </summary>
        public bool PayState { get; set; } = false;
        /// <summary>
        /// 分类
        /// </summary>
        public string Category { get; set; }
        /// <summary>
        /// 悬赏金额
        /// </summary>
        public int Price { get; set; }
        /// <summary>
        /// 创建人
        /// </summary>
        public long CreatorId { get; set; }
        /// <summary>
        /// 创建者
        /// </summary>
        public  virtual Customer Creator { get; set; }
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
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreationTime { get; set; }
    }
  
}
