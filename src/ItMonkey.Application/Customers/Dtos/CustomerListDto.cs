using System;
using System.Collections.Generic;
using Abp.Application.Services.Dto;
using ItMonkey.Models;

namespace ItMonkey.Customers.Dtos
{
    public class CustomerListDto
    {
        public long Id { get; set; }
        public string Name { get; set; }
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
        /// 家族标识
        /// </summary>
        public string Family { get; set; }
        /// <summary>
        /// 家族级别
        /// </summary>
        public int? FamilyCode { get; set; }
        /// <summary>
        /// 职称
        /// </summary>
        public string Title { get; set; }

        public int Balance { get; set; }
        /// <summary>
        /// 唯一标识
        /// </summary>
        public string Key { get; set; }
        /// <summary>
        /// 参与工作数
        /// </summary>
        public int JobsCount { get; set; }
        /// <summary>
        /// 验证状态
        /// </summary>
        public bool? VilidateState { get; set; }
    }

    public class FamilyChildsDto
    {
        public FamilyChildsDto() { }

        public FamilyChildsDto(long id, string name, string title,bool self=false)
        {
            Id = id;
            Name = name;
            Title = title;
            Self = self;
            Children=new List<FamilyChildsDto>();
        }
        public long Id { get; set; }
        public string Name { get; set; }
        public string Title { get; set; }
        public bool Self { get; set; }
        public List<FamilyChildsDto> Children { get; set; }
    }

    public class TempFamily
    {
        public TempFamily() { }

        public TempFamily(long id, params long[] childs)
        {
            Id = id;
            Childs = childs;
        }
        public long Id { get; set; }
        public long[] Childs { get; set; } 
    }
}