using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using ItMonkey.WithDrawas.Dtos;
using ItMonkey.Models;

namespace ItMonkey.WithDrawas
{
    /// <summary>
    /// WithDrawa应用层服务的接口方法
    /// </summary>
    public interface IWithDrawaAppService : IApplicationService
    {
        /// <summary>
        /// 获取WithDrawa的分页列表信息
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<PagedResultDto<WithDrawaListDto>> GetPagedWithDrawas(GetWithDrawasInput input);

        /// <summary>
        /// 通过指定id获取WithDrawaListDto信息
        /// </summary>
        Task<WithDrawaListDto> GetWithDrawaByIdAsync(EntityDto<Guid> input);

        /// <summary>
        /// 导出WithDrawa为excel表
        /// </summary>
        /// <returns></returns>
        //  Task<FileDto> GetWithDrawasToExcel();
        /// <summary>
        /// MPA版本才会用到的方法
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<GetWithDrawaForEditOutput> GetWithDrawaForEdit(NullableIdDto<Guid> input);

        //todo:缺少Dto的生成GetWithDrawaForEditOutput
        /// <summary>
        /// 添加或者修改WithDrawa的公共方法
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task CreateOrUpdateWithDrawa(CreateOrUpdateWithDrawaInput input);

        /// <summary>
        /// 删除WithDrawa信息的方法
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task DeleteWithDrawa(EntityDto<Guid> input);

        /// <summary>
        /// 批量删除WithDrawa
        /// </summary>
        Task BatchDeleteWithDrawasAsync(List<Guid> input);
    }
}
