using System;
using System.Collections.Generic;
using System.Linq;
using Abp.Domain.Repositories;
using Abp.Domain.Services;
using ItMonkey.Models;

namespace ItMonkey.CustomerAddresses.DomainServices
{
    /// <summary>
    /// CustomerAddress领域层的业务管理
    /// </summary>
    public class CustomerAddressManager : ItMonkeyDomainServiceBase, ICustomerAddressManager
    {
        ////BCC/ BEGIN CUSTOM CODE SECTION
        ////ECC/ END CUSTOM CODE SECTION
        private readonly IRepository<CustomerAddress, int> _customeraddressRepository;
        /// <summary>
        /// CustomerAddress的构造方法
        /// </summary>
        public CustomerAddressManager(IRepository<CustomerAddress, int> customeraddressRepository)
        {
            _customeraddressRepository = customeraddressRepository;
        }

        //TODO:编写领域业务代码
        /// <summary>
        ///     初始化
        /// </summary>
        public void InitCustomerAddress()
        {
            throw new NotImplementedException();
        }

    }

}
