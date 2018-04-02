using System.Collections.Generic;
using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using ItMonkey.Customers.Dtos;
using ItMonkey.Jobs.Dtos;
using ItMonkey.Models;

namespace ItMonkey.Jobs
{
    /// <summary>
    /// Job应用层服务的接口方法
    /// </summary>
    public interface IJobAppService : IApplicationService
    {
        /// <summary>
        /// 获取Job的分页列表信息
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<PagedResultDto<JobListDto>> GetPagedJobs(GetJobsInput input);

        /// <summary>
        /// 通过指定id获取JobListDto信息
        /// </summary>
        Task<JobListDto> GetJobByIdAsync(EntityDto<int> input);

        /// <summary>
        /// 审核用户报名
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task VilidateJober(VilidateJoberInput input);
        /// <summary>
        /// 报名工作
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task JoinJob(JoinJobInput input);
        /// <summary>
        /// 获取当前用户的工作列表
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<PagedResultDto<JobListDto>> GetMyJobs(GetMyJobsInput input);

        /// <summary>
        /// 获取用户工作下的报名以及参与人员
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<ListResultDto<CustomerListDto>> GetJobCustomersTask(EntityDto input);
       
        /// <summary>
        /// 获取我创建的工作列表i
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<PagedResultDto<JobListDto>> GetMyCreateJobs(GetMyJobsInput input);
        /// <summary>
        /// 导出Job为excel表
        /// </summary>
        /// <returns></returns>
        //  Task<FileDto> GetJobsToExcel();
        /// <summary>
        /// MPA版本才会用到的方法
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<GetJobForEditOutput> GetJobForEdit(NullableIdDto<int> input);

        /// <summary>
        /// 新增Job
        /// </summary>
        Task<JobEditDto> CreateJobAsync(JobEditDto input);
        /// <summary>
        /// 删除Job信息的方法
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task DeleteJob(EntityDto<int> input);

        /// <summary>
        /// 批量删除Job
        /// </summary>
        Task BatchDeleteJobsAsync(List<int> input);
    }
}
