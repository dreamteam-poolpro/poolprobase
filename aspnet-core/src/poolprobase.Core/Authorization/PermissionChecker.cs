using Abp.Authorization;
using poolprobase.Authorization.Roles;
using poolprobase.Authorization.Users;

namespace poolprobase.Authorization
{
    public class PermissionChecker : PermissionChecker<Role, User>
    {
        public PermissionChecker(UserManager userManager)
            : base(userManager)
        {

        }
    }
}
