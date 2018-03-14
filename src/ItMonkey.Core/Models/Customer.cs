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
        public string Name { get; set; }
        [Required]
        public string Key { get; set; }

        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }

        [ForeignKey("CustomerId")]
        public  virtual  ICollection<CustomerJob> CustomerJobs { get; set; }
    }
}
