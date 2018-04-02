using System;
using Abp.Application.Services.Dto;
using ItMonkey.Models;

namespace ItMonkey.Jobs.Dtos
{
    public class JobListDto
    {
        /// <summary>
        /// key
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// 名称
        /// </summary>
      
        public string Name { get; set; }
        /// <summary>
        /// 内容
        /// </summary>
        public string Content { get; set; }
        /// <summary>
        /// 是否私密发布
        /// </summary>
        public bool IsSecert { get; set; }
        /// <summary>
        /// 分类
        /// </summary>
        public string Category { get; set; }
        /// <summary>
        /// 定价
        /// </summary>
        public int Price { get; set; }
        /// <summary>
        /// 创建人
        /// </summary>
        public long CreatorId { get; set; }
        /// <summary>
        /// 一级奖励
        /// </summary>
        public int FirstGrade { get; set; }
        /// <summary>
        /// 二级奖励
        /// </summary>
        public int SecondGrade { get; set; }
        /// <summary>
        /// 三级奖励
        /// </summary>
        public int ThirdGrade { get; set; }
        /// <summary>
        /// 状态
        /// </summary>
        public int? State { get; set; }
        /// <summary>
        /// 审核状态
        /// </summary>
        public bool? VilidateState { get; set; }
        /// <summary>
        /// 报名人数
        /// </summary>
        public int JoinCount { get; set; }
        /// <summary>
        /// 当前用户参与状态
        /// </summary>
        public bool JoinState { get; set; }
    }
}