using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Abp.Domain.Repositories;
using Abp.Linq.Extensions;

using System.Linq.Dynamic.Core;
using Abp.Extensions;
using Abp.UI;
using ItMonkey.Customers.Dtos;
using Microsoft.EntityFrameworkCore;
using ItMonkey.Jobs.Dtos;
using ItMonkey.Models;
using ItMonkey.Models.MonkeyChain;

namespace ItMonkey.Jobs
{
    /// <summary>
    /// Job应用层服务的接口实现方法
    /// </summary>

    public class JobAppService : ItMonkeyAppServiceBase, IJobAppService
    {
        private readonly IRepository<Job, int> _jobRepository;
        private readonly IRepository<CustomerJob, int> _myJobRepository;
        private readonly IRepository<CustomerMonkeyChain, Guid> _bankRepository;
        /// <summary>
        /// 构造函数
        /// </summary>
        public JobAppService(IRepository<Job, int> jobRepository,
            IRepository<CustomerJob, int> myJobRepository,
            IRepository<CustomerMonkeyChain, Guid> bankRepository)
        {
            _jobRepository = jobRepository;
            _myJobRepository = myJobRepository;
            _bankRepository = bankRepository;
        }
       
        /// <summary>
        /// 获取Job的分页列表信息
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public async Task<PagedResultDto<JobListDto>> GetPagedJobs(GetJobsInput input)
        {
            var query = _jobRepository.GetAll();
            query = query.WhereIf(!input.Filter.IsNullOrWhiteSpace(), c => c.Name.Contains(input.Filter));
            var jobCount = await query.CountAsync();
            var jobs = await query
                .OrderBy(input.Sorting)
                .PageBy(input)
                .ToListAsync();
            var result = new List<JobListDto>();
            var cj = await _myJobRepository.GetAll().WhereIf(input.CustomerId.HasValue, c => c.CustomerId == input.CustomerId.Value)
                .ToListAsync();
            foreach (var job in jobs)
            {
                var model = job.MapTo<JobListDto>();
                model.JoinCount = cj.Count(w => w.JobId == job.Id && w.VilidateState.HasValue && w.VilidateState.Value);
                model.JoinState = cj.Count(w => w.JobId == job.Id &&
                (!w.VilidateState.HasValue || w.VilidateState.Value)) > 0;
                result.Add(model);
            }
            //var jobListDtos = ObjectMapper.Map<List <JobListDto>>(jobs);
            //  var jobListDtos = jobs.MapTo<List<JobListDto>>();
            return new PagedResultDto<JobListDto>(
                jobCount,
                result
                );
        }
        /// <summary>
        /// 报名工作
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public async Task JoinJob(JoinJobInput input)
        {
            var job = await _jobRepository.FirstOrDefaultAsync(c => c.Id == input.JobId);
            if (job == null) throw new UserFriendlyException("该工作不存在");
            var count = await _myJobRepository.CountAsync(c =>
                c.CustomerId == input.CustomerId && c.JobId == input.JobId);
            if (count > 0) throw new UserFriendlyException("已报名该工作不可重复报名");
            var model = new CustomerJob()
            {
                CustomerId = input.CustomerId,
                JobId = input.JobId,
                CreatorId = job.CreatorId
            };
            await _myJobRepository.InsertAsync(model);
        }
        /// <summary>
        /// 获取用户工作下的报名以及参与人员
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public async Task<ListResultDto<CustomerListDto>> GetJobCustomersTask(EntityDto input)
        {
            var query = _myJobRepository.GetAllIncluding(c=>c.Customer);
            query = query.Where(c => c.JobId == input.Id);
            var cusomters = await query
                .ToListAsync();
           var result=new List<CustomerListDto>();
            foreach (var customerJob in cusomters)
            {
                var model = customerJob.Customer.MapTo<CustomerListDto>();
                model.VilidateState = customerJob.VilidateState;
                result.Add(model);
            }
            return  new ListResultDto<CustomerListDto>(result);
        }
        /// <summary>
        /// 审核用户报名
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public async Task VilidateJober(VilidateJoberInput input)
        {
            var jobs = await _myJobRepository.GetAllListAsync(c => c.JobId == input.JobId);
            foreach (var jober in input.Vilidates)
            {
                var model = jobs.FirstOrDefault(c => c.CustomerId == jober.Id);
                if (model != null)
                {
                    model.VilidateState = jober.State;
                }
            }
        }
        
        /// <summary>
        /// 获取当前用户的工作列表
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public async Task<PagedResultDto<JobListDto>> GetMyJobs(GetMyJobsInput input)
        {
            var query = _myJobRepository.GetAllIncluding(c=>c.Job);
            query = query.Where(c => c.CustomerId == input.CustomerId &&
            c.VilidateState.HasValue && c.VilidateState.Value);
            var jobCount = await query.CountAsync();
            var jobs = await query
                .OrderBy(input.Sorting)
                .PageBy(input)
                .ToListAsync();
            var result = new List<JobListDto>();
            foreach (var c in jobs)
            {
                var model = c.Job.MapTo<JobListDto>();
                model.State = c.State;
                model.VilidateState = c.VilidateState;
                result.Add(model);
            }
            //var jobListDtos = ObjectMapper.Map<List <JobListDto>>(jobs);
            return new PagedResultDto<JobListDto>(
                jobCount,
                result
            );
        }
        /// <summary>
        /// 获取我创建的工作列表i
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public async Task<PagedResultDto<JobListDto>> GetMyCreateJobs(GetMyJobsInput input)
        {
            var query = _jobRepository.GetAll();
            query = query.Where(c => c.CreatorId == input.CustomerId);
            var jobCount = await query.CountAsync();
            var jobs = await query
                .OrderBy(input.Sorting)
                .PageBy(input)
                .ToListAsync();
            var cj = _myJobRepository.GetAll();
            var t = from c in jobs
                    join d in await cj.ToListAsync() on c.Id equals d.JobId
                into hh
                    from tt in hh.DefaultIfEmpty()
                    select new
                    {
                        c,
                         tt
                    };
            var ttt = from c in t
                group c by c.c
                into h
                select new
                {
                    h.Key,
                    Count = h.Count()
                };
            var result = new List<JobListDto>();
            foreach (var c in ttt)
            {
                var model = c.Key.MapTo<JobListDto>();
                model.JoinCount = c.Count;
                result.Add(model);
            }
            //var jobListDtos = ObjectMapper.Map<List <JobListDto>>(jobs);
            return new PagedResultDto<JobListDto>(
                jobCount,
                result
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
        /// 新增Job
        /// </summary>

        public async Task<JobEditDto> CreateJobAsync(JobEditDto input)
        {
            var entity = ObjectMapper.Map<Job>(input);
            var balances = await _bankRepository.GetAllListAsync(c => c.CustomerId == input.CreatorId);

            if (input.IsSecert)
            {
                if (balances.Count >= 3)
                {
                    var res = balances.OrderBy(c => c.CreationTime).Take(3).Select(c => c.Id);
                    await _bankRepository.DeleteAsync(c => res.Any(w => w == c.Id));
                    entity.PayState = true;
                }
            }
            entity = await _jobRepository.InsertAsync(entity);
            var model = entity.MapTo<JobEditDto>();
            return model;
        }
        /// <summary>
        /// 编辑Job
        /// </summary>
        /// <summary>
        /// 删除Job信息的方法
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>

        public async Task DeleteJob(EntityDto<int> input)
        {

            await _jobRepository.DeleteAsync(input.Id);
        }

        /// <summary>
        /// 批量删除Job的方法
        /// </summary>

        public async Task BatchDeleteJobsAsync(List<int> input)
        {
            await _jobRepository.DeleteAsync(s => input.Contains(s.Id));
        }

    }
}

