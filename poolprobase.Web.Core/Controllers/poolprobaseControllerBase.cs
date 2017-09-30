using Abp.AspNetCore.Mvc.Controllers;
using Abp.IdentityFramework;
using Microsoft.AspNetCore.Identity;

namespace poolprobase.Controllers
{
    public abstract class poolprobaseControllerBase: AbpController
    {
        protected poolprobaseControllerBase()
        {
            LocalizationSourceName = poolprobaseConsts.LocalizationSourceName;
        }

        protected void CheckErrors(IdentityResult identityResult)
        {
            identityResult.CheckErrors(LocalizationManager);
        }
    }
}