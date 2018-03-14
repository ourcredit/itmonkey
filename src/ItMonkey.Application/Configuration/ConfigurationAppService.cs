using System.Threading.Tasks;
using Abp.Authorization;
using Abp.Runtime.Session;
using ItMonkey.Configuration.Dto;

namespace ItMonkey.Configuration
{
    [AbpAuthorize]
    public class ConfigurationAppService : ItMonkeyAppServiceBase, IConfigurationAppService
    {
        public async Task ChangeUiTheme(ChangeUiThemeInput input)
        {
            await SettingManager.ChangeSettingForUserAsync(AbpSession.ToUserIdentifier(), AppSettingNames.UiTheme, input.Theme);
        }
    }
}
