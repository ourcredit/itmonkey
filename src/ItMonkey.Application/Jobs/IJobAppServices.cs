using System.Collections.Generic;
using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
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

        //todo:缺少Dto的生成GetJobForEditOutput
        /// <summary>
        /// 添加或者修改Job的公共方法
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task CreateOrUpdateJob(CreateOrUpdateJobInput input);

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
