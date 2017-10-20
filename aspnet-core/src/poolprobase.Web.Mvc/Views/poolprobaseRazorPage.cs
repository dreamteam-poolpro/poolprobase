using Abp.AspNetCore.Mvc.Views;
using Abp.Runtime.Session;
using Microsoft.AspNetCore.Mvc.Razor.Internal;

namespace poolprobase.Web.Views
{
    public abstract class poolprobaseRazorPage<TModel> : AbpRazorPage<TModel>
    {
        [RazorInject]
        public IAbpSession AbpSession { get; set; }

        protected poolprobaseRazorPage()
        {
            LocalizationSourceName = poolprobaseConsts.LocalizationSourceName;
        }
    }
}
