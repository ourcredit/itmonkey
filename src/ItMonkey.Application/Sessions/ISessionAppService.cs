using System.Threading.Tasks;
using Abp.Application.Services;
using ItMonkey.Sessions.Dto;

namespace ItMonkey.Sessions
{
    public interface ISessionAppService : IApplicationService
    {
        Task<GetCurrentLoginInformationsOutput> GetCurrentLoginInformations();
    }
}
