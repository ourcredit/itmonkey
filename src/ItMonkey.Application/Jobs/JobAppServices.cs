﻿using System.Collections.Generic;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.AutoMapper;
using Abp.Domain.Repositories;
using Abp.Linq.Extensions;

using System.Linq.Dynamic.Core;
using Microsoft.EntityFrameworkCore;
using ItMonkey.Jobs.Dtos;
using ItMonkey.Jobs.DomainServices;
using ItMonkey.Models;

namespace ItMonkey.Jobs
{
    /// <summary>
    /// Job应用层服务的接口实现方法
    /// </summary>
    public class JobAppService : ItMonkeyAppServiceBase, IJobAppService
    {
        ////BCC/ BEGIN CUSTOM CODE SECTION
        ////ECC/ END CUSTOM CODE SECTION
        private readonly IRepository<Job, int> _jobRepository;
        private readonly IJobManager _jobManager;

        /// <summary>
        /// 构造函数
        /// </summary>
        public JobAppService(IRepository<Job, int> jobRepository
      , IJobManager jobManager
        )
        {
            _jobRepository = jobRepository;
            _jobManager = jobManager;
        }

        /// <summary>
        /// 获取Job的分页列表信息
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public async Task<PagedResultDto<JobListDto>> GetPagedJobs(GetJobsInput input)
        {

            var query = _jobRepository.GetAll();
            //TODO:根据传入的参数添加过滤条件
            var jobCount = await query.CountAsync();

            var jobs = await query
                .OrderBy(input.Sorting)
                .PageBy(input)
                .ToListAsync();

            //var jobListDtos = ObjectMapper.Map<List <JobListDto>>(jobs);
            var jobListDtos = jobs.MapTo<List<JobListDto>>();

            return new PagedResultDto<JobListDto>(
                jobCount,
                jobListDtos
                );

        }

        /// <summary>
        /// 通过指定id获取JobListDto信息
        /// </summary>
        public async Task<JobListDto> GetJobByIdAsync(EntityDto<int> input)
        {
            var entity = await _jobRepository.GetAsync(input.Id);

            return entity.MapTo<JobListDto>();
        }

        /// <summary>
        /// 导出Job为excel表
        /// </summary>
        /// <returns></returns>
        //public async Task<FileDto> GetJobsToExcel(){
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
        public async Task<GetJobForEditOutput> GetJobForEdit(NullableIdDto<int> input)
        {
            var output = new GetJobForEditOutput();
            JobEditDto jobEditDto;

            if (input.Id.HasValue)
            {
                var entity = await _jobRepository.GetAsync(input.Id.Value);

                jobEditDto = entity.MapTo<JobEditDto>();

                //jobEditDto = ObjectMapper.Map<List <jobEditDto>>(entity);
            }
            else
            {
                jobEditDto = new JobEditDto();
            }

            output.Job = jobEditDto;
            return output;

        }

        /// <summary>
        /// 添加或者修改Job的公共方法
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public async Task CreateOrUpdateJob(CreateOrUpdateJobInput input)
        {

            if (input.Job.Id.HasValue)
            {
                await UpdateJobAsync(input.Job);
            }
            else
            {
                await CreateJobAsync(input.Job);
            }
        }

        /// <summary>
        /// 新增Job
        /// </summary>
        protected virtual async Task<JobEditDto> CreateJobAsync(JobEditDto input)
        {
            //TODO:新增前的逻辑判断，是否允许新增
            var entity = ObjectMapper.Map<Job>(input);

            entity = await _jobRepository.InsertAsync(entity);
            return entity.MapTo<JobEditDto>();
        }

        /// <summary>
        /// 编辑Job
        /// </summary>
        protected virtual async Task UpdateJobAsync(JobEditDto input)
        {
            //TODO:更新前的逻辑判断，是否允许更新
            var entity = await _jobRepository.GetAsync(input.Id.Value);
            input.MapTo(entity);

            // ObjectMapper.Map(input, entity);
            await _jobRepository.UpdateAsync(entity);
        }

        /// <summary>
        /// 删除Job信息的方法
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public async Task DeleteJob(EntityDto<int> input)
        {

            //TODO:删除前的逻辑判断，是否允许删除
            await _jobRepository.DeleteAsync(input.Id);
        }

        /// <summary>
        /// 批量删除Job的方法
        /// </summary>
        public async Task BatchDeleteJobsAsync(List<int> input)
        {
            //TODO:批量删除前的逻辑判断，是否允许删除
            await _jobRepository.DeleteAsync(s => input.Contains(s.Id));
        }

    }
}
