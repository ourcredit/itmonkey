using Abp.Authorization;
using Abp.Authorization.Users;
using AutoMapper;
using ItMonkey.Authorization.Accounts.Dto;
using ItMonkey.Authorization.Permissions.Dto;
using ItMonkey.Authorization.Roles;
using ItMonkey.Authorization.Roles.Dto;
using ItMonkey.Authorization.Users;
using ItMonkey.Authorization.Users.Dto;
using ItMonkey.CustomerAddresss.Dtos;
using ItMonkey.CustomerExperiences.Dtos;
using ItMonkey.CustomerMonkeyChains.Dtos;
using ItMonkey.Customers.Dtos;
using ItMonkey.Jobs.Dtos;
using ItMonkey.Models;
using ItMonkey.Models.MonkeyChain;
using ItMonkey.MultiTenancy;
using ItMonkey.Products.Dtos;
using ItMonkey.Sessions.Dto;
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

          

            //Role
            configuration.CreateMap<RoleEditDto, Role>().ReverseMap();
            configuration.CreateMap<Role, RoleListDto>();
            configuration.CreateMap<UserRole, UserListRoleDto>();



          
            //Permission
            configuration.CreateMap<Permission, FlatPermissionDto>();
            configuration.CreateMap<Permission, FlatPermissionWithLevelDto>();

            //Tenant
            configuration.CreateMap<Tenant, TenantLoginInfoDto>();
            configuration.CreateMap<CurrentTenantInfoDto, Tenant>().ReverseMap();

            //User
            configuration.CreateMap<User, UserEditDto>()
                .ForMember(dto => dto.Password, options => options.Ignore())
                .ReverseMap()
                .ForMember(user => user.Password, options => options.Ignore());
            configuration.CreateMap<User, UserLoginInfoDto>();
            configuration.CreateMap<User, UserListDto>();
            configuration.CreateMap<UserLoginAttemptDto, UserLoginAttempt>().ReverseMap();
        }
    }
}
