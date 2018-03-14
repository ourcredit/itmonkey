using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Abp.Modules;
using Abp.Reflection.Extensions;
using ItMonkey.Configuration;

namespace ItMonkey.Web.Host.Startup
{
    [DependsOn(
       typeof(ItMonkeyWebCoreModule))]
    public class ItMonkeyWebHostModule: AbpModule
    {
        private readonly IHostingEnvironment _env;
        private readonly IConfigurationRoot _appConfiguration;

        public ItMonkeyWebHostModule(IHostingEnvironment env)
        {
            _env = env;
            _appConfiguration = env.GetAppConfiguration();
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(ItMonkeyWebHostModule).GetAssembly());
        }
    }
}
