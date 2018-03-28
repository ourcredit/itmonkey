using System.Collections.Generic;
using Abp.Application.Services.Dto;
using ItMonkey.Models;

namespace ItMonkey.Jobs.Dtos
{
    public class GetJobForEditOutput
    {
        ////BCC/ BEGIN CUSTOM CODE SECTION
        ////ECC/ END CUSTOM CODE SECTION
        public JobEditDto Job { get; set; }

    }
    /// <summary>
    /// input
    /// </summary>

    public class JoinJobInput
    {
        /// <summary>
        /// 客户id
        /// </summary>
        public long CustomerId { get; set; }
        /// <summary>
        /// 工作id
        /// </summary>
        public int JobId { get; set; }
    }
    /// <summary>
    /// 审核用户
    /// </summary>
    public class VilidateJober
    {
        public int Id { get; set; }
        public bool State { get; set; }
    }
}