using Abp.Application.Services;
using Abp.Application.Services.Dto;
using ItMonkey.Authorization.Permissions.Dto;

namespace ItMonkey.Authorization.Permissions
{
    public interface IPermissionAppService : IApplicationService
    {
        ListResultDto<FlatPermissionWithLevelDto> GetAllPermissions();
    }
}
