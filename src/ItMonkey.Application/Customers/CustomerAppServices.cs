using System.Collections.Generic;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.AutoMapper;
using Abp.Domain.Repositories;
using Abp.Linq.Extensions;

using System.Linq.Dynamic.Core;
using Microsoft.EntityFrameworkCore;

using ItMonkey.Customers.Dtos;
using ItMonkey.Dto;
using ItMonkey.Models;

namespace ItMonkey.Customers
{
    /// <summary>
    /// Customer应用层服务的接口实现方法
    /// </summary>

    public class CustomerAppService : ItMonkeyAppServiceBase, ICustomerAppService
    {
        ////BCC/ BEGIN CUSTOM CODE SECTION
        ////ECC/ END CUSTOM CODE SECTION
        private readonly IRepository<Customer, long> _customerRepository;

        /// <summary>
        /// 构造函数
        /// </summary>
        public CustomerAppService(IRepository<Customer, long> customerRepository

            )
        {
            _customerRepository = customerRepository;

        }

        /// <summary>
        /// 获取Customer的分页列表信息
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public async Task<PagedResultDto<CustomerListDto>> GetPagedCustomers(GetCustomersInput input)
        {

            var query = _customerRepository.GetAll();
            var customerCount = await query.CountAsync();

            var customers = await query
                .OrderBy(input.Sorting)
                .PageBy(input)
                .ToListAsync();

            //var customerListDtos = ObjectMapper.Map<List <CustomerListDto>>(customers);
            var customerListDtos = customers.MapTo<List<CustomerListDto>>();

            return new PagedResultDto<CustomerListDto>(
                customerCount,
                customerListDtos
                );

        }

        /// <summary>
        /// 通过指定id获取CustomerListDto信息
        /// </summary>
        public async Task<CustomerListDto> GetCustomerByIdAsync(EntityDto<long> input)
        {
            var entity = await _customerRepository.GetAsync(input.Id);

            return entity.MapTo<CustomerListDto>();
        }

   
        /// <summary>
        /// MPA版本才会用到的方法
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public async Task<GetCustomerForEditOutput> GetCustomerForEdit(NullableIdDto<long> input)
        {
            var output = new GetCustomerForEditOutput();
            CustomerEditDto customerEditDto;

            if (input.Id.HasValue)
            {
                var entity = await _customerRepository.GetAsync(input.Id.Value);

                customerEditDto = entity.MapTo<CustomerEditDto>();

                //customerEditDto = ObjectMapper.Map<List <customerEditDto>>(entity);
            }
            else
            {
                customerEditDto = new CustomerEditDto();
            }

            output.Customer = customerEditDto;
            return output;

        }

        /// <summary>
        /// 添加或者修改Customer的公共方法
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public async Task CreateOrUpdateCustomer(CreateOrUpdateCustomerInput input)
        {

            if (input.Customer.Id.HasValue)
            {
                await UpdateCustomerAsync(input.Customer);
            }
            else
            {
                await CreateCustomerAsync(input.Customer);
            }
        }

        /// <summary>
        /// 新增Customer
        /// </summary>

        protected virtual async Task<CustomerEditDto> CreateCustomerAsync(CustomerEditDto input)
        {
            var entity = ObjectMapper.Map<Customer>(input);
            entity = await _customerRepository.InsertAsync(entity);
            return entity.MapTo<CustomerEditDto>();
        }

        /// <summary>
        /// 编辑Customer
        /// </summary>

        protected virtual async Task UpdateCustomerAsync(CustomerEditDto input)
        {
            var entity = await _customerRepository.GetAsync(input.Id.Value);
            input.MapTo(entity);

            // ObjectMapper.Map(input, entity);
            await _customerRepository.UpdateAsync(entity);
        }

        /// <summary>
        /// 删除Customer信息的方法
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>

        public async Task DeleteCustomer(EntityDto<long> input)
        {

            await _customerRepository.DeleteAsync(input.Id);
        }

        /// <summary>
        /// 批量删除Customer的方法
        /// </summary>

        public async Task BatchDeleteCustomersAsync(List<long> input)
        {
            await _customerRepository.DeleteAsync(s => input.Contains(s.Id));
        }

    }
}

