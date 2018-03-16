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
            Configuration.Modules.AbpAutoMapper().Configurators.Add(CustomDtoMapper.CreateMappings);
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(ItMonkeyApplicationModule).GetAssembly());
        }
    }
}
