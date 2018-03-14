using Abp.AutoMapper;
using Abp.Modules;
using Abp.Reflection.Extensions;
using ItMonkey.Authorization;

namespace ItMonkey
{
    [DependsOn(
        typeof(ItMonkeyCoreModule), 
        typeof(AbpAutoMapperModule))]
    public class ItMonkeyApplicationModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.Authorization.Providers.Add<ItMonkeyAuthorizationProvider>();
        }

        public override void Initialize()
        {
            var thisAssembly = typeof(ItMonkeyApplicationModule).GetAssembly();

            IocManager.RegisterAssemblyByConvention(thisAssembly);

            Configuration.Modules.AbpAutoMapper().Configurators.Add(
                // Scan the assembly for classes which inherit from AutoMapper.Profile
                cfg => cfg.AddProfiles(thisAssembly)
            );
        }
    }
}
