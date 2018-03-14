using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using ItMonkey.Roles.Dto;
using ItMonkey.Users.Dto;

namespace ItMonkey.Users
{
    public interface IUserAppService : IAsyncCrudAppService<UserDto, long, PagedResultRequestDto, CreateUserDto, UserDto>
    {
        Task<ListResultDto<RoleDto>> GetRoles();

        Task ChangeLanguage(ChangeUserLanguageDto input);
    }
}
