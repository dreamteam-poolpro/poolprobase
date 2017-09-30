using System.Data.Common;
using Microsoft.EntityFrameworkCore;

namespace poolprobase.EntityFrameworkCore
{
    public static class poolprobaseDbContextConfigurer
    {
        public static void Configure(DbContextOptionsBuilder<poolprobaseDbContext> builder, string connectionString)
        {
            builder.UseSqlServer(connectionString);
        }

        public static void Configure(DbContextOptionsBuilder<poolprobaseDbContext> builder, DbConnection connection)
        {
            builder.UseSqlServer(connection);
        }
    }
}