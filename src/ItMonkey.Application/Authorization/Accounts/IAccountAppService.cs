using System.Threading.Tasks;
using Abp.Application.Services;
using ItMonkey.Authorization.Accounts.Dto;

namespace ItMonkey.Authorization.Accounts
{
    public interface IAccountAppService : IApplicationService
    {
        Task<IsTenantAvailableOutput> IsTenantAvailable(IsTenantAvailableInput input);

        Task<RegisterOutput> Register(RegisterInput input);
    }
}
