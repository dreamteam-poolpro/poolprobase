using Abp.AspNetCore.Mvc.ViewComponents;

namespace poolprobase.Web.Views
{
    public abstract class poolprobaseViewComponent : AbpViewComponent
    {
        protected poolprobaseViewComponent()
        {
            LocalizationSourceName = poolprobaseConsts.LocalizationSourceName;
        }
    }
}