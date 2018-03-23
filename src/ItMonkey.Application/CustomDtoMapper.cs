using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using ItMonkey.CustomerExperiences.Dtos;
using ItMonkey.CustomerMonkeyChains.Dtos;
using ItMonkey.Customers.Dtos;
using ItMonkey.Jobs.Dtos;
using ItMonkey.Models;
using ItMonkey.Models.MonkeyChain;
using ItMonkey.Shufflings.Dtos;

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

            configuration.CreateMap<Job, JobListDto>();
            configuration.CreateMap<JobEditDto, Job>();

            configuration.CreateMap<CustomerExperience, CustomerExperienceListDto>();
            configuration.CreateMap<CustomerExperienceEditDto, CustomerExperience>();

            configuration.CreateMap<CustomerMonkeyChain, CustomerMonkeyChainListDto>();
            configuration.CreateMap<CustomerMonkeyChainEditDto, CustomerMonkeyChain>();
        }
    }
}
