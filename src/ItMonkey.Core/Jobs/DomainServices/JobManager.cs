using System;
using System.Collections.Generic;
using System.Linq;
using Abp.Domain.Repositories;
using Abp.Domain.Services;
using ItMonkey.Models;

namespace ItMonkey.Jobs.DomainServices
{
    /// <summary>
    /// Job领域层的业务管理
    /// </summary>
    public class JobManager : ItMonkeyDomainServiceBase, IJobManager
    {
        ////BCC/ BEGIN CUSTOM CODE SECTION
        ////ECC/ END CUSTOM CODE SECTION
        private readonly IRepository<Job, int> _jobRepository;
        /// <summary>
        /// Job的构造方法
        /// </summary>
        public JobManager(IRepository<Job, int> jobRepository)
        {
            _jobRepository = jobRepository;
        }

        //TODO:编写领域业务代码
        /// <summary>
        ///     初始化
        /// </summary>
        public void InitJob()
        {
            throw new NotImplementedException();
        }

    }

}
