﻿using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using ItMonkey.Customers.Dtos;
using ItMonkey.Jobs.Dtos;
using ItMonkey.Models;
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
        }
    }
}