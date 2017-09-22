using System.Reflection;
using Abp.AutoMapper;
using Abp.Modules;
using Abp.Reflection.Extensions;
using poolprobase.Authorization;

namespace poolprobase
{
    [DependsOn(
        typeof(poolprobaseCoreModule), 
        typeof(AbpAutoMapperModule))]
    public class poolprobaseApplicationModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.Authorization.Providers.Add<poolprobaseAuthorizationProvider>();
        }

        public override void Initialize()
        {
            Assembly thisAssembly = typeof(poolprobaseApplicationModule).GetAssembly();
            IocManager.RegisterAssemblyByConvention(thisAssembly);

            Configuration.Modules.AbpAutoMapper().Configurators.Add(cfg =>
            {
                //Scan the assembly for classes which inherit from AutoMapper.Profile
                cfg.AddProfiles(thisAssembly);
            });
        }
    }
}