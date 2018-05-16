using System;
using System.Threading.Tasks;
using Abp;
using Abp.Domain.Services;
using ItMonkey.Models;

namespace ItMonkey.CustomerAddresses.DomainServices
{
    public interface ICustomerAddressManager : IDomainService
    {

        /// <summary>
        /// 初始化方法
        /// </summary>
        void InitCustomerAddress();

    }
}
