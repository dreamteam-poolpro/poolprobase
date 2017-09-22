using System.Reflection;
using Abp.Modules;
using Abp.Reflection.Extensions;
using poolprobase.Configuration;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;

namespace poolprobase.Web.Host.Startup
{
    [DependsOn(
       typeof(poolprobaseWebCoreModule))]
    public class poolprobaseWebHostModule: AbpModule
    {
        private readonly IHostingEnvironment _env;
        private readonly IConfigurationRoot _appConfiguration;

        public poolprobaseWebHostModule(IHostingEnvironment env)
        {
            _env = env;
            _appConfiguration = env.GetAppConfiguration();
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(poolprobaseWebHostModule).GetAssembly());
        }
    }
}
