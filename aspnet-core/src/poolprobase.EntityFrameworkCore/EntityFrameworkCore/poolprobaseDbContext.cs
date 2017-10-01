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
        //we really should not have created another db context, we should have put dbsets in here for our
        //extra tables.
        
        public poolprobaseDbContext(DbContextOptions<poolprobaseDbContext> options)
            : base(options)
        {
        }

    }
}
