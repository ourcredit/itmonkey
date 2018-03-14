using System;
using System.Threading.Tasks;
using Abp;
using Abp.Domain.Services;
using ItMonkey.Models;

namespace ItMonkey.Jobs.DomainServices
{
    public interface IJobManager : IDomainService
    {

        /// <summary>
        /// 初始化方法
        /// </summary>
        void InitJob();

    }
}
