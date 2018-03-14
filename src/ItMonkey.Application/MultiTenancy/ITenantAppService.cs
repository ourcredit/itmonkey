using Abp.Application.Services;
using Abp.Application.Services.Dto;
using ItMonkey.MultiTenancy.Dto;

namespace ItMonkey.MultiTenancy
{
    public interface ITenantAppService : IAsyncCrudAppService<TenantDto, int, PagedResultRequestDto, CreateTenantDto, TenantDto>
    {
    }
}
