using Abp.Zero.EntityFrameworkCore;
using poolprobase.Authorization.Roles;
using poolprobase.Authorization.Users;
using poolprobase.MultiTenancy;
using Microsoft.EntityFrameworkCore;
using poolprobase.Web;

namespace poolprobase.EntityFrameworkCore
{
    public class poolprobaseDbContext : AbpZeroDbContext<Tenant, Role, User, poolprobaseDbContext>
    {
        /* Define an IDbSet for each entity of the application */
        
        public poolprobaseDbContext(DbContextOptions<poolprobaseDbContext> options)
            : base(options)
        {
        }

    }
}
