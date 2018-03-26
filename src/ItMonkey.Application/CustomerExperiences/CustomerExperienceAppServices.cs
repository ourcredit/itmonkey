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

using ItMonkey.CustomerExperiences.Dtos;
using ItMonkey.Models;

namespace ItMonkey.CustomerExperiences
{
    /// <summary>
    /// CustomerExperience应用层服务的接口实现方法
    /// </summary>

    public class CustomerExperienceAppService : ItMonkeyAppServiceBase, ICustomerExperienceAppService
    {
        ////BCC/ BEGIN CUSTOM CODE SECTION
        ////ECC/ END CUSTOM CODE SECTION
        private readonly IRepository<CustomerExperience, int> _customerexperienceRepository;

        /// <summary>
        /// 构造函数
        /// </summary>
        public CustomerExperienceAppService(IRepository<CustomerExperience, int> customerexperienceRepository

            )
        {
            _customerexperienceRepository = customerexperienceRepository;

        }

        /// <summary>
        /// 获取CustomerExperience的分页列表信息
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public async Task<PagedResultDto<CustomerExperienceListDto>> GetPagedCustomerExperiences(GetCustomerExperiencesInput input)
        {

            var query = _customerexperienceRepository.GetAll();
            query = query.Where(c => c.CustomerId == input.CustomerId);
            var customerexperienceCount = await query.CountAsync();
            var customerexperiences = await query
                .OrderBy(input.Sorting)
                .PageBy(input)
                .ToListAsync();
            //var customerexperienceListDtos = ObjectMapper.Map<List <CustomerExperienceListDto>>(customerexperiences);
            var customerexperienceListDtos = customerexperiences.MapTo<List<CustomerExperienceListDto>>();

            return new PagedResultDto<CustomerExperienceListDto>(
                customerexperienceCount,
                customerexperienceListDtos
                );

        }

        /// <summary>
        /// 通过指定id获取CustomerExperienceListDto信息
        /// </summary>
        public async Task<CustomerExperienceListDto> GetCustomerExperienceByIdAsync(EntityDto<int> input)
        {
            var entity = await _customerexperienceRepository.GetAsync(input.Id);

            return entity.MapTo<CustomerExperienceListDto>();
        }

        /// <summary>
        /// MPA版本才会用到的方法
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public async Task<GetCustomerExperienceForEditOutput> GetCustomerExperienceForEdit(NullableIdDto<int> input)
        {
            var output = new GetCustomerExperienceForEditOutput();
            CustomerExperienceEditDto customerexperienceEditDto;

            if (input.Id.HasValue)
            {
                var entity = await _customerexperienceRepository.GetAsync(input.Id.Value);

                customerexperienceEditDto = entity.MapTo<CustomerExperienceEditDto>();

                //customerexperienceEditDto = ObjectMapper.Map<List <customerexperienceEditDto>>(entity);
            }
            else
            {
                customerexperienceEditDto = new CustomerExperienceEditDto();
            }

            output.CustomerExperience = customerexperienceEditDto;
            return output;

        }

        /// <summary>
        /// 添加或者修改CustomerExperience的公共方法
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public async Task CreateOrUpdateCustomerExperience(CreateOrUpdateCustomerExperienceInput input)
        {

            if (input.CustomerExperience.Id.HasValue)
            {
                await UpdateCustomerExperienceAsync(input.CustomerExperience);
            }
            else
            {
                await CreateCustomerExperienceAsync(input.CustomerExperience);
            }
        }

        /// <summary>
        /// 新增CustomerExperience
        /// </summary>

        protected virtual async Task<CustomerExperienceEditDto> CreateCustomerExperienceAsync(CustomerExperienceEditDto input)
        {
            var entity = ObjectMapper.Map<CustomerExperience>(input);

            entity = await _customerexperienceRepository.InsertAsync(entity);
            return entity.MapTo<CustomerExperienceEditDto>();
        }

        /// <summary>
        /// 编辑CustomerExperience
        /// </summary>

        protected virtual async Task UpdateCustomerExperienceAsync(CustomerExperienceEditDto input)
        {
            var entity = await _customerexperienceRepository.GetAsync(input.Id.Value);
            input.MapTo(entity);

            // ObjectMapper.Map(input, entity);
            await _customerexperienceRepository.UpdateAsync(entity);
        }

        /// <summary>
        /// 删除CustomerExperience信息的方法
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>

        public async Task DeleteCustomerExperience(EntityDto<int> input)
        {

            await _customerexperienceRepository.DeleteAsync(input.Id);
        }

        /// <summary>
        /// 批量删除CustomerExperience的方法
        /// </summary>

        public async Task BatchDeleteCustomerExperiencesAsync(List<int> input)
        {
            await _customerexperienceRepository.DeleteAsync(s => input.Contains(s.Id));
        }

    }
}

