using poolprobase.Configuration;
using poolprobase.Web;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace poolprobase.EntityFrameworkCore
{
    /* This class is needed to run "dotnet ef ..." commands from command line on development. Not used anywhere else */
    public class poolprobaseDbContextFactory : IDesignTimeDbContextFactory<poolprobaseDbContext>
    {
        public poolprobaseDbContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<poolprobaseDbContext>();
            var configuration = AppConfigurations.Get(WebContentDirectoryFinder.CalculateContentRootFolder());

            poolprobaseDbContextConfigurer.Configure(builder, configuration.GetConnectionString(poolprobaseConsts.ConnectionStringName));

            return new poolprobaseDbContext(builder.Options);
        }
    }
}