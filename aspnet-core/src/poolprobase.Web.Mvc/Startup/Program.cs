using Abp.Dependency;
using Castle.Windsor.MsDependencyInjection;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using poolprobase.Identity;
using poolprobase.Web.Data;
using System;
using System.ComponentModel;
using Castle.MicroKernel.Registration;


namespace poolprobase.Web.Startup
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = BuildWebHost(args);
                host.Run();
        }

        public static IWebHost BuildWebHost(string[] args)
        {
            return WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .Build();
        }

        /*public static void Register(IIocManager iocManager)
        {
            var services = new ServiceCollection();

            IdentityRegistrar.Register(services);

            // services.AddEntityFrameworkInMemoryDatabase();

            var serviceProvider = WindsorRegistrationHelper.CreateServiceProvider(iocManager.IocContainer, services);

            var builder = new DbContextOptionsBuilder<CustomerContext>();
            // builder.UseInMemoryDatabase(Guid.NewGuid().ToString()).UseInternalServiceProvider(serviceProvider);

            iocManager.IocContainer.Register(
                System.ComponentModel.Component
                    .For<DbContextOptions<CustomerContext>>()
                    .Instance(builder.Options)
                    .LifestyleSingleton()
            );*/
        }
}
