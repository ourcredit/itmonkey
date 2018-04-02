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
using Abp.Extensions;
using Abp.UI;
using Microsoft.EntityFrameworkCore;

using ItMonkey.Customers.Dtos;
using ItMonkey.Dto;
using ItMonkey.Models;
using Microsoft.EntityFrameworkCore.Metadata;

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
        private readonly IRepository<Family> _familyRepository;
        private readonly IRepository<CustomerJob> _myJobRepository;
        /// <summary>
        /// 构造函数
        /// </summary>
        public CustomerAppService(IRepository<Customer, long> customerRepository, IRepository<Family> familyRepository,
            IRepository<CustomerJob> myJobRepository)
        {
            _customerRepository = customerRepository;
            _familyRepository = familyRepository;
            _myJobRepository = myJobRepository;
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
        /// 通过指定id获取CustomerListDto信息
        /// </summary>
        public async Task<CustomerListDto> GetCustomerByKeyAsync(EntityDto<string> input)
        {
            var entity = await _customerRepository.FirstOrDefaultAsync(c => c.Key.Equals(input.Id));
            if (entity == null) return null;
            var model = entity.MapTo<CustomerListDto>();
            var count = await _myJobRepository.CountAsync(c => c.CustomerId == entity.Id);
            model.JobsCount = count;
            return model;
        }
        /// <summary>
        /// 获取家族成员树
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public async Task<FamilyChildsDto> GetFamilyChildsAsync(EntityDto<long> input)
        {
            var family = await _customerRepository.FirstOrDefaultAsync(c => c.Id == input.Id);
            //所有人员 
            var fulls = await _customerRepository.GetAllListAsync(c => c.Family == family.Family);
            return GenderFamily(fulls, family.Id);
        }
        /// <summary>
        /// 拼接家族书
        /// </summary>
        /// <param name="list"></param>
        /// <param name="current"></param>
        /// <returns></returns>
        private FamilyChildsDto GenderFamily(List<Customer> list, long current)
        {
            var r=new List<TempFamily>()
            {
                new TempFamily(5, 14, 23, 32),
                new TempFamily(8, 17, 26, 35),
                new TempFamily(11, 20,29,38),
                new TempFamily(6, 15, 24, 33),
                new TempFamily(9, 18, 27, 36),
                new TempFamily(12, 21, 30, 39),
                new TempFamily(7, 16, 25, 34),
                new TempFamily(10,19, 28, 37),
                new TempFamily(13, 22, 31, 40)
            };
            var root = list.First(c => c.FamilyCode.HasValue && c.FamilyCode.Value == 1);
            var rootf = new FamilyChildsDto(root.Id, root.Name, root.Title, root.Id == current);
            var r2 = list.FirstOrDefault(c => c.FamilyCode.HasValue && c.FamilyCode.Value == 2);
            var r3 = list.FirstOrDefault(c => c.FamilyCode.HasValue && c.FamilyCode.Value == 3);
            var r4 = list.FirstOrDefault(c => c.FamilyCode.HasValue && c.FamilyCode.Value == 4);
            if (r2 != null)
            {
                var r2f=new FamilyChildsDto(r2.Id,r2.Name,r2.Title,r2.Id==current);
                var rt = r.Where(c => c.Id.IsIn(5, 8, 11));
                foreach (var tempFamily in rt)
                {
                    var temp = list.FirstOrDefault(c => c.FamilyCode.HasValue && c.FamilyCode.Value == tempFamily.Id);
                    if (temp != null)
                    {
                       var l2=new FamilyChildsDto(temp.Id,temp.Name,temp.Title,temp.Id==current);
                        var t1 = list.Where(
                            c => c.FamilyCode.HasValue && tempFamily.Childs.Contains(c.FamilyCode.Value));
                        l2.Children.AddRange(t1.Select(w => new FamilyChildsDto(w.Id, w.Name, w.Title, w.Id == current)));
                        r2f.Children.Add(l2);
                    }
                }
              rootf.Children.Add(r2f);
            }
            if (r3 != null)
            {
                var r3f = new FamilyChildsDto(r3.Id, r3.Name, r3.Title, r3.Id == current);
                var rt = r.Where(c => c.Id.IsIn(6,9,12));
                foreach (var tempFamily in rt)
                {
                    var temp = list.FirstOrDefault(c => c.FamilyCode.HasValue && c.FamilyCode.Value == tempFamily.Id);
                    if (temp != null)
                    {
                        var l2 = new FamilyChildsDto(temp.Id, temp.Name, temp.Title, temp.Id == current);
                        var t1 = list.Where(
                            c => c.FamilyCode.HasValue && tempFamily.Childs.Contains(c.FamilyCode.Value));
                        l2.Children.AddRange(t1.Select(w => new FamilyChildsDto(w.Id, w.Name, w.Title, w.Id == current)));
                        r3f.Children.Add(l2);
                    }
                }
                rootf.Children.Add(r3f);
            }
            if (r4 != null)
            {
                var r4f = new FamilyChildsDto(r4.Id, r4.Name, r4.Title, r4.Id == current);
                var rt = r.Where(c => c.Id.IsIn(7,10,13));
                foreach (var tempFamily in rt)
                {
                    var temp = list.FirstOrDefault(c => c.FamilyCode.HasValue && c.FamilyCode.Value == tempFamily.Id);
                    if (temp != null)
                    {
                        var l2 = new FamilyChildsDto(temp.Id, temp.Name, temp.Title, temp.Id == current);
                        var t1 = list.Where(
                            c => c.FamilyCode.HasValue && tempFamily.Childs.Contains(c.FamilyCode.Value));
                        l2.Children.AddRange(t1.Select(w => new FamilyChildsDto(w.Id, w.Name, w.Title, w.Id == current)));
                        r4f.Children.Add(l2);
                    }
                }
                rootf.Children.Add(r4f);
            }


            return rootf;
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
            var temp = await _customerRepository.CountAsync(c => c.Key == input.Key);
            if (temp > 0) throw new UserFriendlyException("该用户已经注册");
            var entity = ObjectMapper.Map<Customer>(input);
            var family = await _familyRepository.FirstOrDefaultAsync(c => !c.IsSecret);
            if (family == null)
            {
                var code = Guid.NewGuid().ToString("D").Split('-').Last();
                family = await _familyRepository.InsertAsync(new Family()
                {
                    IsSecret = false,
                    Name = code,
                    Key = code
                });

            }
            entity.Family = family.Key;
            var count = await _customerRepository.CountAsync(c => c.Family == family.Key);
            entity.FamilyCode = count + 1;
            entity.Title = FamilyConsts.GetTitle(entity.FamilyCode.Value);
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

