using System.Reflection;
using Abp.Modules;
using Abp.Reflection.Extensions;
using poolprobase.Configuration;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;

namespace poolprobase.Web.Startup
{
    [DependsOn(typeof(poolprobaseWebCoreModule))]
    public class poolprobaseWebMvcModule : AbpModule
    {
        private readonly IHostingEnvironment _env;
        private readonly IConfigurationRoot _appConfiguration;

        public poolprobaseWebMvcModule(IHostingEnvironment env)
        {
            _env = env;
            _appConfiguration = env.GetAppConfiguration();
        }

        public override void PreInitialize()
        {
            Configuration.Navigation.Providers.Add<poolprobaseNavigationProvider>();
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(poolprobaseWebMvcModule).GetAssembly());
        }
    }
}