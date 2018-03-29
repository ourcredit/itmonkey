using System.Threading.Tasks;
using Abp.Application.Services;
using ItMonkey.Authorization.Accounts.Dto;

namespace ItMonkey.Authorization.Accounts
{
    public interface IAccountAppService : IApplicationService
    {
        Task<RegisterOutput> Register(RegisterInput input);


        Task SendPasswordResetCode(SendPasswordResetCodeInput input);


        Task<ResetPasswordOutput> ResetPassword(ResetPasswordInput input);
      

        Task ActivateEmail(ActivateEmailInput input);



    }
}
