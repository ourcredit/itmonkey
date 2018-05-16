using System.Collections.Generic;
using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using ItMonkey.CustomerAddresss.Dtos;

namespace ItMonkey.CustomerAddresss
{
    /// <summary>
    /// CustomerAddress应用层服务的接口方法
    /// </summary>
    public interface ICustomerAddressAppService : IApplicationService
    {
        /// <summary>
        /// 获取CustomerAddress的分页列表信息
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<PagedResultDto<CustomerAddressListDto>> GetPagedCustomerAddresss(GetCustomerAddresssInput input);

        /// <summary>
        /// 通过指定id获取CustomerAddressListDto信息
        /// </summary>
        Task<CustomerAddressListDto> GetCustomerAddressByIdAsync(EntityDto<int> input);

        /// <summary>
        /// 导出CustomerAddress为excel表
        /// </summary>
        /// <returns></returns>
        //  Task<FileDto> GetCustomerAddresssToExcel();
        /// <summary>
        /// MPA版本才会用到的方法
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<GetCustomerAddressForEditOutput> GetCustomerAddressForEdit(NullableIdDto<int> input);

        //todo:缺少Dto的生成GetCustomerAddressForEditOutput
        /// <summary>
        /// 添加或者修改CustomerAddress的公共方法
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task CreateOrUpdateCustomerAddress(CreateOrUpdateCustomerAddressInput input);

        /// <summary>
        /// 删除CustomerAddress信息的方法
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task DeleteCustomerAddress(EntityDto<int> input);

        /// <summary>
        /// 批量删除CustomerAddress
        /// </summary>
        Task BatchDeleteCustomerAddresssAsync(List<int> input);
    }
}
