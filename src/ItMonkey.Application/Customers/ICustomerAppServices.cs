using System.Collections.Generic;
using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using ItMonkey.Customers.Dtos;
using ItMonkey.Models;

namespace ItMonkey.Customers
{
    /// <summary>
    /// Customer应用层服务的接口方法
    /// </summary>
    public interface ICustomerAppService : IApplicationService
    {
        /// <summary>
        /// 获取Customer的分页列表信息
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<PagedResultDto<CustomerListDto>> GetPagedCustomers(GetCustomersInput input);

        /// <summary>
        /// 通过指定id获取CustomerListDto信息
        /// </summary>
        Task<CustomerListDto> GetCustomerByIdAsync(EntityDto<long> input);
        /// <summary>
        /// 通过指定id获取CustomerListDto信息
        /// </summary>
        Task<CustomerListDto> GetCustomerByKeyAsync(EntityDto<string> input);

        /// <summary>
        /// 获取家族成员树
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<FamilyChildsDto> GetFamilyChildsAsync(EntityDto<long> input);
        /// <summary>
        /// 导出Customer为excel表
        /// </summary>
        /// <returns></returns>
        //  Task<FileDto> GetCustomersToExcel();
        /// <summary>
        /// MPA版本才会用到的方法
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<GetCustomerForEditOutput> GetCustomerForEdit(NullableIdDto<long> input);

        /// <summary>
        /// 从缓存获取消息记录
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<PagedResultDto<MessageListDto>> GetMessageAsync(GetMessageInput input);
        /// <summary>
        /// 添加或者修改Customer的公共方法
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task CreateOrUpdateCustomer(CreateOrUpdateCustomerInput input);

        /// <summary>
        /// 删除Customer信息的方法
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task DeleteCustomer(EntityDto<long> input);

        /// <summary>
        /// 批量删除Customer
        /// </summary>
        Task BatchDeleteCustomersAsync(List<long> input);
    }
}
