using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Abp.Application.Services;
using ItMonkey.CustomerMonkeyChains.Dtos;

namespace ItMonkey.CustomerMonkeyChains
{
    /// <summary>
    /// CustomerMonkeyChain应用层服务的接口方法
    /// </summary>
    public interface ICustomerMonkeyChainAppService : IApplicationService
    {
        /// <summary>
        /// 新增CustomerMonkeyChain
        /// </summary>

        Task<CustomerMonkeyChainEditDto> CreateCustomerMonkeyChainAsync(CustomerMonkeyChainEditDto input);

        /// <summary>
        /// 批量删除CustomerMonkeyChain的方法
        /// </summary>
        Task BatchDeleteCustomerMonkeyChainsAsync(List<Guid> input);
    }
}
