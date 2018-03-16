using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Authorization.Users;
using Abp.AutoMapper;
using Abp.Domain.Repositories;
using Abp.Linq.Extensions;
using Abp.Extensions;
using ItMonkey.Models;
using ItMonkey.Shufflings.Dtos;
using Microsoft.EntityFrameworkCore;

namespace ItMonkey.Shufflings
{
    /// <summary>
    /// Shuffling应用层服务的接口实现方法
    /// </summary>

    public class ShufflingAppService : ItMonkeyAppServiceBase, IShufflingAppService
    {
        ////BCC/ BEGIN CUSTOM CODE SECTION
        ////ECC/ END CUSTOM CODE SECTION
        private readonly IRepository<Shuffling, int> _shufflingRepository;

        /// <summary>
        /// 构造函数
        /// </summary>
        public ShufflingAppService(IRepository<Shuffling, int> shufflingRepository

            )
        {
            _shufflingRepository = shufflingRepository;

        }

        /// <summary>
        /// 获取Shuffling的分页列表信息
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public async Task<ListResultDto<ShufflingListDto>> GetPagedShufflings(GetShufflingsInput input)
        {

            var query = _shufflingRepository.GetAll();
            query = query.Where(c => c.IsActive);
            var shufflings = await query
                .OrderBy("Sort")
                .ToListAsync();
            var shufflingListDtos = shufflings.MapTo<List<ShufflingListDto>>();

            return new ListResultDto<ShufflingListDto>(
                shufflingListDtos
                );

        }

        /// <summary>
        /// 通过指定id获取ShufflingListDto信息
        /// </summary>
        public async Task<ShufflingListDto> GetShufflingByIdAsync(EntityDto<int> input)
        {
            var entity = await _shufflingRepository.GetAsync(input.Id);

            return entity.MapTo<ShufflingListDto>();
        }

        /// <summary>
        /// 导出Shuffling为excel表
        /// </summary>
        /// <returns></returns>
        //public async Task<FileDto> GetShufflingsToExcel(){
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
        public async Task<GetShufflingForEditOutput> GetShufflingForEdit(NullableIdDto<int> input)
        {
            var output = new GetShufflingForEditOutput();
            ShufflingEditDto shufflingEditDto;

            if (input.Id.HasValue)
            {
                var entity = await _shufflingRepository.GetAsync(input.Id.Value);

                shufflingEditDto = entity.MapTo<ShufflingEditDto>();

                //shufflingEditDto = ObjectMapper.Map<List <shufflingEditDto>>(entity);
            }
            else
            {
                shufflingEditDto = new ShufflingEditDto();
            }

            output.Shuffling = shufflingEditDto;
            return output;

        }

        /// <summary>
        /// 添加或者修改Shuffling的公共方法
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public async Task CreateOrUpdateShuffling(CreateOrUpdateShufflingInput input)
        {

            if (input.Shuffling.Id.HasValue)
            {
                await UpdateShufflingAsync(input.Shuffling);
            }
            else
            {
                await CreateShufflingAsync(input.Shuffling);
            }
        }

        /// <summary>
        /// 新增Shuffling
        /// </summary>

        protected virtual async Task<ShufflingEditDto> CreateShufflingAsync(ShufflingEditDto input)
        {
            var entity = ObjectMapper.Map<Shuffling>(input);

            entity = await _shufflingRepository.InsertAsync(entity);
            return entity.MapTo<ShufflingEditDto>();
        }

        /// <summary>
        /// 编辑Shuffling
        /// </summary>

        protected virtual async Task UpdateShufflingAsync(ShufflingEditDto input)
        {
            var entity = await _shufflingRepository.GetAsync(input.Id.Value);
            input.MapTo(entity);

            // ObjectMapper.Map(input, entity);
            await _shufflingRepository.UpdateAsync(entity);
        }

        /// <summary>
        /// 删除Shuffling信息的方法
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>

        public async Task DeleteShuffling(EntityDto<int> input)
        {

            await _shufflingRepository.DeleteAsync(input.Id);
        }

        /// <summary>
        /// 批量删除Shuffling的方法
        /// </summary>

        public async Task BatchDeleteShufflingsAsync(List<int> input)
        {
            await _shufflingRepository.DeleteAsync(s => input.Contains(s.Id));
        }

    }
}

