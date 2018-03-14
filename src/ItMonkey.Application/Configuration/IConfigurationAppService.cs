using System.Threading.Tasks;
using ItMonkey.Configuration.Dto;

namespace ItMonkey.Configuration
{
    public interface IConfigurationAppService
    {
        Task ChangeUiTheme(ChangeUiThemeInput input);
    }
}
