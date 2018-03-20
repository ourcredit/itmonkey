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
    /// 注册人员信息
    /// </summary>
    [Table("m_customer")]
   public class Customer:CreationAuditedEntity<long>,IPassivable,ISoftDelete
    {
        /// <summary>
        /// 名称
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 唯一标识
        /// </summary>
        [Required]
        public string Key { get; set; }
        /// <summary>
        /// 家族标识
        /// </summary>
        public string Family { get; set; }
        /// <summary>
        /// 家族级别
        /// </summary>
        [Range(1,40)]
        public int? FamilyCode { get; set; }
        /// <summary>
        /// 职称
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// 一级技能
        /// </summary>
        public string Skill { get; set; }
        /// <summary>
        /// 二级技能
        /// </summary>
        public string ChildSkill { get; set; }
        /// <summary>
        /// 余额
        /// </summary>
        public int Balance { get; set; }
        /// <summary>
        /// 启用禁用
        /// </summary>
        public bool IsActive { get; set; }
        /// <summary>
        /// 软删除
        /// </summary>
        public bool IsDeleted { get; set; }
        /// <summary>
        /// 参与的工作
        /// </summary>
        [ForeignKey("CustomerId")]
        public  virtual  ICollection<CustomerJob> CustomerJobs { get; set; }
    }
}
