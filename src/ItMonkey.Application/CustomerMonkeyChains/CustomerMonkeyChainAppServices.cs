using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.AutoMapper;
using Abp.Domain.Repositories;
using Abp.Linq.Extensions;

using System.Linq.Dynamic.Core;
using Microsoft.EntityFrameworkCore;

using ItMonkey.CustomerMonkeyChains.Dtos;
using ItMonkey.Models.MonkeyChain;

namespace ItMonkey.CustomerMonkeyChains
{
    /// <summary>
    /// CustomerMonkeyChain应用层服务的接口实现方法
    /// </summary>

    public class CustomerMonkeyChainAppService : ItMonkeyAppServiceBase, ICustomerMonkeyChainAppService
    {
        ////BCC/ BEGIN CUSTOM CODE SECTION
        ////ECC/ END CUSTOM CODE SECTION
        private readonly IRepository<CustomerMonkeyChain, Guid> _customermonkeychainRepository;
        private readonly IRepository<MonkeyChain, Guid> _monkeyChainRepository;
        /// <summary>
        /// 构造函数
        /// </summary>
        public CustomerMonkeyChainAppService(IRepository<CustomerMonkeyChain, Guid> customermonkeychainRepository,
            IRepository<MonkeyChain, Guid> monkeyChainRepository)
        {
            _customermonkeychainRepository = customermonkeychainRepository;
            _monkeyChainRepository = monkeyChainRepository;
        }
        /// <summary>
        /// 新增CustomerMonkeyChain
        /// </summary>

        public  async Task<CustomerMonkeyChainEditDto> CreateCustomerMonkeyChainAsync(CustomerMonkeyChainEditDto input)
        {
            var lastChain =await _monkeyChainRepository.GetAll().OrderByDescending(c => c.Index).LastOrDefaultAsync();
            var chain=new MonkeyChain(lastChain.Index+1,input.JobData,lastChain.Hash);
            var cur =await _monkeyChainRepository.InsertAsync(chain);
            await CurrentUnitOfWork.SaveChangesAsync();

            var entity =new CustomerMonkeyChain(input.CustomerId,cur.Id);
            entity = await _customermonkeychainRepository.InsertAsync(entity);
            return entity.MapTo<CustomerMonkeyChainEditDto>();
        }
        /// <summary>
        /// 批量删除CustomerMonkeyChain的方法
        /// </summary>
        public async Task BatchDeleteCustomerMonkeyChainsAsync(List<Guid> input)
        {
            await _customermonkeychainRepository.DeleteAsync(s => input.Contains(s.Id));
        }
    }
}

