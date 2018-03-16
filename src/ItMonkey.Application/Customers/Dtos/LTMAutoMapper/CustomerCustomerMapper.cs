using AutoMapper;

namespace ItMonkey.Customers.Dtos.LTMAutoMapper
{
    using ItMonkey.Models;

    /// <summary>
    /// 配置Customer的AutoMapper
    /// </summary>
    internal static class CustomerCustomerMapper
    {
        public static void CreateMappings(IMapperConfigurationExpression configuration)
        {
            //    configuration.CreateMap <Customer, CustomerDto>();
            configuration.CreateMap<Customer, CustomerListDto>();
            configuration.CreateMap<CustomerEditDto, Customer>();
            // configuration.CreateMap<CreateCustomerInput, Customer>();
            //        configuration.CreateMap<Customer, GetCustomerForEditOutput>();
        }
    }
}