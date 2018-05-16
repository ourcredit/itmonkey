using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using System.Linq;
using Abp.Authorization;
using Abp.AutoMapper;
using Abp.Domain.Repositories;
using Abp.Linq.Extensions;

using System.Linq.Dynamic.Core;
using Microsoft.EntityFrameworkCore;
using ItMonkey.WithDrawas.Dtos;
using ItMonkey.Models;

namespace ItMonkey.WithDrawas
{
    /// <summary>
    /// WithDrawa应用层服务的接口实现方法
    /// </summary>
    [AbpAuthorize]
    public class WithDrawaAppService : ItMonkeyAppServiceBase, IWithDrawaAppService
    {
        ////BCC/ BEGIN CUSTOM CODE SECTION
        ////ECC/ END CUSTOM CODE SECTION
        private readonly IRepository<WithDrawa, Guid> _withdrawaRepository;

        /// <summary>
        /// 构造函数
        /// </summary>
        public WithDrawaAppService(IRepository<WithDrawa, Guid> withdrawaRepository
        )
        {
            _withdrawaRepository = withdrawaRepository;
        }

        /// <summary>
        /// 获取WithDrawa的分页列表信息
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public async Task<PagedResultDto<WithDrawaListDto>> GetPagedWithDrawas(GetWithDrawasInput input)
        {

            var query = _withdrawaRepository.GetAll();
            //TODO:根据传入的参数添加过滤条件
            var withdrawaCount = await query.CountAsync();

            var withdrawas = await query
                .OrderBy(input.Sorting).AsNoTracking()
                .PageBy(input)
                .ToListAsync();

            //var withdrawaListDtos = ObjectMapper.Map<List <WithDrawaListDto>>(withdrawas);
            var withdrawaListDtos = withdrawas.MapTo<List<WithDrawaListDto>>();

            return new PagedResultDto<WithDrawaListDto>(
                withdrawaCount,
                withdrawaListDtos
                );

        }

        /// <summary>
        /// 通过指定id获取WithDrawaListDto信息
        /// </summary>
        public async Task<WithDrawaListDto> GetWithDrawaByIdAsync(EntityDto<Guid> input)
        {
            var entity = await _withdrawaRepository.GetAsync(input.Id);

            return entity.MapTo<WithDrawaListDto>();
        }

        /// <summary>
        /// 导出WithDrawa为excel表
        /// </summary>
        /// <returns></returns>
        //public async Task<FileDto> GetWithDrawasToExcel(){
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
        public async Task<GetWithDrawaForEditOutput> GetWithDrawaForEdit(NullableIdDto<Guid> input)
        {
            var output = new GetWithDrawaForEditOutput();
            WithDrawaEditDto withdrawaEditDto;

            if (input.Id.HasValue)
            {
                var entity = await _withdrawaRepository.GetAsync(input.Id.Value);

                withdrawaEditDto = entity.MapTo<WithDrawaEditDto>();

                //withdrawaEditDto = ObjectMapper.Map<List <withdrawaEditDto>>(entity);
            }
            else
            {
                withdrawaEditDto = new WithDrawaEditDto();
            }

            output.WithDrawa = withdrawaEditDto;
            return output;

        }

        /// <summary>
        /// 添加或者修改WithDrawa的公共方法
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public async Task CreateOrUpdateWithDrawa(CreateOrUpdateWithDrawaInput input)
        {

            if (input.WithDrawa.Id.HasValue)
            {
                await UpdateWithDrawaAsync(input.WithDrawa);
            }
            else
            {
                await CreateWithDrawaAsync(input.WithDrawa);
            }
        }

        /// <summary>
        /// 新增WithDrawa
        /// </summary>
        protected virtual async Task<WithDrawaEditDto> CreateWithDrawaAsync(WithDrawaEditDto input)
        {
            //TODO:新增前的逻辑判断，是否允许新增
            var entity = ObjectMapper.Map<WithDrawa>(input);

            entity = await _withdrawaRepository.InsertAsync(entity);
            return entity.MapTo<WithDrawaEditDto>();
        }

        /// <summary>
        /// 编辑WithDrawa
        /// </summary>
        protected virtual async Task UpdateWithDrawaAsync(WithDrawaEditDto input)
        {
            //TODO:更新前的逻辑判断，是否允许更新
            var entity = await _withdrawaRepository.GetAsync(input.Id.Value);
            input.MapTo(entity);

            // ObjectMapper.Map(input, entity);
            await _withdrawaRepository.UpdateAsync(entity);
        }

        /// <summary>
        /// 删除WithDrawa信息的方法
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public async Task DeleteWithDrawa(EntityDto<Guid> input)
        {

            //TODO:删除前的逻辑判断，是否允许删除
            await _withdrawaRepository.DeleteAsync(input.Id);
        }

        /// <summary>
        /// 批量删除WithDrawa的方法
        /// </summary>
        public async Task BatchDeleteWithDrawasAsync(List<Guid> input)
        {
            //TODO:批量删除前的逻辑判断，是否允许删除
            await _withdrawaRepository.DeleteAsync(s => input.Contains(s.Id));
        }

    }
}

