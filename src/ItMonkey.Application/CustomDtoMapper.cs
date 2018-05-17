using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using ItMonkey.CustomerAddresss.Dtos;
using ItMonkey.CustomerExperiences.Dtos;
using ItMonkey.CustomerMonkeyChains.Dtos;
using ItMonkey.Customers.Dtos;
using ItMonkey.Jobs.Dtos;
using ItMonkey.Models;
using ItMonkey.Models.MonkeyChain;
using ItMonkey.Products.Dtos;
using ItMonkey.Shufflings.Dtos;
using ItMonkey.WithDrawas.Dtos;

namespace ItMonkey
{
    internal static class CustomDtoMapper
    {
        public static void CreateMappings(IMapperConfigurationExpression configuration)
        {
            configuration.CreateMap<Shuffling, ShufflingListDto>();
            configuration.CreateMap<ShufflingEditDto, Shuffling>();

            configuration.CreateMap<Customer, CustomerListDto>();
            configuration.CreateMap<CustomerEditDto, Customer>();

            configuration.CreateMap<Job, JobListDto>()
                .ForMember(c=>c.CreatorName,o=>o.MapFrom(w=>w.Creator.Name));
            configuration.CreateMap<JobEditDto, Job>();

            configuration.CreateMap<CustomerExperience, CustomerExperienceListDto>();
            configuration.CreateMap<CustomerExperienceEditDto, CustomerExperience>();

            configuration.CreateMap<CustomerMonkeyChain, CustomerMonkeyChainListDto>();
            configuration.CreateMap<CustomerMonkeyChainEditDto, CustomerMonkeyChain>();

            configuration.CreateMap<CustomerAddress, CustomerAddressListDto>();
            configuration.CreateMap<CustomerAddressEditDto, CustomerAddress>();

            configuration.CreateMap<WithDrawa, WithDrawaListDto>();
            configuration.CreateMap<WithDrawaEditDto, WithDrawa>();

            configuration.CreateMap<Product, ProductListDto>();
            configuration.CreateMap<ProductEditDto, Product>();
        }
    }
}
