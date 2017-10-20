using Abp.Authorization;
using Abp.Localization;
using Abp.MultiTenancy;

namespace poolprobase.Authorization
{
    public class poolprobaseAuthorizationProvider : AuthorizationProvider
    {
        public override void SetPermissions(IPermissionDefinitionContext context)
        {
            context.CreatePermission(PermissionNames.Pages_Users, L("Users"));
            context.CreatePermission(PermissionNames.Pages_Roles, L("Roles"));
            context.CreatePermission(PermissionNames.Pages_WorkOrders, L("WorkOrders"));
            context.CreatePermission(PermissionNames.Pages_ServiceTechs, L("ServiceTechs"));
            context.CreatePermission(PermissionNames.Pages_Customers, L("Customers"));
            context.CreatePermission(PermissionNames.Pages_Tenants, L("Tenants"), multiTenancySides: MultiTenancySides.Host);
        }

        private static ILocalizableString L(string name)
        {
            return new LocalizableString(name, poolprobaseConsts.LocalizationSourceName);
        }
    }
}
