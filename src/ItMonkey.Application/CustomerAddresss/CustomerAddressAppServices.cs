using System.Collections.Generic;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.AutoMapper;
using Abp.Domain.Repositories;
using Abp.Linq.Extensions;
using ItMonkey.CustomerAddresses.DomainServices;
using ItMonkey.CustomerAddresss.Dtos;
using ItMonkey.Models;
using Microsoft.EntityFrameworkCore;

namespace ItMonkey.CustomerAddresss
{
    /// <summary>
    /// CustomerAddress应用层服务的接口实现方法
    /// </summary>
    [AbpAuthorize]
    public class CustomerAddressAppService : ItMonkeyAppServiceBase, ICustomerAddressAppService
    {
        ////BCC/ BEGIN CUSTOM CODE SECTION
        ////ECC/ END CUSTOM CODE SECTION
        private readonly IRepository<CustomerAddress, int> _customeraddressRepository;
        private readonly ICustomerAddressManager _customeraddressManager;

        /// <summary>
        /// 构造函数
        /// </summary>
        public CustomerAddressAppService(IRepository<CustomerAddress, int> customeraddressRepository
      , ICustomerAddressManager customeraddressManager
        )
        {
            _customeraddressRepository = customeraddressRepository;
            _customeraddressManager = customeraddressManager;
        }

        /// <summary>
        /// 获取CustomerAddress的分页列表信息
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public async Task<PagedResultDto<CustomerAddressListDto>> GetPagedCustomerAddresss(GetCustomerAddresssInput input)
        {

            var query = _customeraddressRepository.GetAll();
            //TODO:根据传入的参数添加过滤条件
            var customeraddressCount = await query.CountAsync();

            var customeraddresss = await query
                .OrderBy(input.Sorting).AsNoTracking()
                .PageBy(input)
                .ToListAsync();

            //var customeraddressListDtos = ObjectMapper.Map<List <CustomerAddressListDto>>(customeraddresss);
            var customeraddressListDtos = customeraddresss.MapTo<List<CustomerAddressListDto>>();

            return new PagedResultDto<CustomerAddressListDto>(
                customeraddressCount,
                customeraddressListDtos
                );

        }

        /// <summary>
        /// 通过指定id获取CustomerAddressListDto信息
        /// </summary>
        public async Task<CustomerAddressListDto> GetCustomerAddressByIdAsync(EntityDto<int> input)
        {
            var entity = await _customeraddressRepository.GetAsync(input.Id);

            return entity.MapTo<CustomerAddressListDto>();
        }

        /// <summary>
        /// 导出CustomerAddress为excel表
        /// </summary>
        /// <returns></returns>
        //public async Task<FileDto> GetCustomerAddresssToExcel(){
        //var users = await UserManager.Users.ToListAsync();
        //var userListDtos = ObjectMapper.Map<List<UserListDto>>(users);
        //await FillRoleNames(userListDtos);
        //return _userListExcelExporter.ExportToFile(userListDtos);
        //}
        /// <summary>
        /// MPA版本才会用到的方法
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public async Task<GetCustomerAddressForEditOutput> GetCustomerAddressForEdit(NullableIdDto<int> input)
        {
            var output = new GetCustomerAddressForEditOutput();
            CustomerAddressEditDto customeraddressEditDto;

            if (input.Id.HasValue)
            {
                var entity = await _customeraddressRepository.GetAsync(input.Id.Value);

                customeraddressEditDto = entity.MapTo<CustomerAddressEditDto>();

                //customeraddressEditDto = ObjectMapper.Map<List <customeraddressEditDto>>(entity);
            }
            else
            {
                customeraddressEditDto = new CustomerAddressEditDto();
            }

            output.CustomerAddress = customeraddressEditDto;
            return output;

        }

        /// <summary>
        /// 添加或者修改CustomerAddress的公共方法
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public async Task CreateOrUpdateCustomerAddress(CreateOrUpdateCustomerAddressInput input)
        {

            if (input.CustomerAddress.Id.HasValue)
            {
                await UpdateCustomerAddressAsync(input.CustomerAddress);
            }
            else
            {
                await CreateCustomerAddressAsync(input.CustomerAddress);
            }
        }

        /// <summary>
        /// 新增CustomerAddress
        /// </summary>
        protected virtual async Task<CustomerAddressEditDto> CreateCustomerAddressAsync(CustomerAddressEditDto input)
        {
            //TODO:新增前的逻辑判断，是否允许新增
            var entity = ObjectMapper.Map<CustomerAddress>(input);

            entity = await _customeraddressRepository.InsertAsync(entity);
            return entity.MapTo<CustomerAddressEditDto>();
        }

        /// <summary>
        /// 编辑CustomerAddress
        /// </summary>
        protected virtual async Task UpdateCustomerAddressAsync(CustomerAddressEditDto input)
        {
            //TODO:更新前的逻辑判断，是否允许更新
            var entity = await _customeraddressRepository.GetAsync(input.Id.Value);
            input.MapTo(entity);

            // ObjectMapper.Map(input, entity);
            await _customeraddressRepository.UpdateAsync(entity);
        }

        /// <summary>
        /// 删除CustomerAddress信息的方法
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public async Task DeleteCustomerAddress(EntityDto<int> input)
        {

            //TODO:删除前的逻辑判断，是否允许删除
            await _customeraddressRepository.DeleteAsync(input.Id);
        }

        /// <summary>
        /// 批量删除CustomerAddress的方法
        /// </summary>
        public async Task BatchDeleteCustomerAddresssAsync(List<int> input)
        {
            //TODO:批量删除前的逻辑判断，是否允许删除
            await _customeraddressRepository.DeleteAsync(s => input.Contains(s.Id));
        }

    }
}

