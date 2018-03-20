using System.Collections.Generic;
using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using ItMonkey.CustomerExperiences.Dtos;
using ItMonkey.Models;

namespace ItMonkey.CustomerExperiences
{
    /// <summary>
    /// CustomerExperience应用层服务的接口方法
    /// </summary>
    public interface ICustomerExperienceAppService : IApplicationService
    {
        /// <summary>
        /// 获取CustomerExperience的分页列表信息
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<PagedResultDto<CustomerExperienceListDto>> GetPagedCustomerExperiences(GetCustomerExperiencesInput input);

        /// <summary>
        /// 通过指定id获取CustomerExperienceListDto信息
        /// </summary>
        Task<CustomerExperienceListDto> GetCustomerExperienceByIdAsync(EntityDto<int> input);

        /// <summary>
        /// 导出CustomerExperience为excel表
        /// </summary>
        /// <returns></returns>
        //  Task<FileDto> GetCustomerExperiencesToExcel();
        /// <summary>
        /// MPA版本才会用到的方法
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<GetCustomerExperienceForEditOutput> GetCustomerExperienceForEdit(NullableIdDto<int> input);

        //todo:缺少Dto的生成GetCustomerExperienceForEditOutput
        /// <summary>
        /// 添加或者修改CustomerExperience的公共方法
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task CreateOrUpdateCustomerExperience(CreateOrUpdateCustomerExperienceInput input);

        /// <summary>
        /// 删除CustomerExperience信息的方法
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task DeleteCustomerExperience(EntityDto<int> input);

        /// <summary>
        /// 批量删除CustomerExperience
        /// </summary>
        Task BatchDeleteCustomerExperiencesAsync(List<int> input);
    }
}
