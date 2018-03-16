using System.Collections.Generic;
using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using ItMonkey.Shufflings.Dtos;
using ItMonkey.Models;

namespace ItMonkey.Shufflings
{
    /// <summary>
    /// Shuffling应用层服务的接口方法
    /// </summary>
    public interface IShufflingAppService : IApplicationService
    {
        /// <summary>
        /// 获取Shuffling的分页列表信息
        /// </summary>
        /// <returns></returns>
        Task<ListResultDto<ShufflingListDto>> GetPagedShufflings();

        /// <summary>
        /// 通过指定id获取ShufflingListDto信息
        /// </summary>
        Task<ShufflingListDto> GetShufflingByIdAsync(EntityDto<int> input);

        /// <summary>
        /// 导出Shuffling为excel表
        /// </summary>
        /// <returns></returns>
        //  Task<FileDto> GetShufflingsToExcel();
        /// <summary>
        /// MPA版本才会用到的方法
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<GetShufflingForEditOutput> GetShufflingForEdit(NullableIdDto<int> input);
        /// <summary>
        /// 添加或者修改Shuffling的公共方法
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task CreateOrUpdateShuffling(CreateOrUpdateShufflingInput input);

        /// <summary>
        /// 删除Shuffling信息的方法
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task DeleteShuffling(EntityDto<int> input);

        /// <summary>
        /// 批量删除Shuffling
        /// </summary>
        Task BatchDeleteShufflingsAsync(List<int> input);
    }
}
