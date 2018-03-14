using Abp.AspNetCore.Mvc.Controllers;
using Abp.IdentityFramework;
using Microsoft.AspNetCore.Identity;

namespace ItMonkey.Controllers
{
    public abstract class ItMonkeyControllerBase: AbpController
    {
        protected ItMonkeyControllerBase()
        {
            LocalizationSourceName = ItMonkeyConsts.LocalizationSourceName;
        }

        protected void CheckErrors(IdentityResult identityResult)
        {
            identityResult.CheckErrors(LocalizationManager);
        }
    }
}
