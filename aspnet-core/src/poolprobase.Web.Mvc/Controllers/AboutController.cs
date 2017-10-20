using Abp.AspNetCore.Mvc.Authorization;
using poolprobase.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace poolprobase.Web.Controllers
{
    [AbpMvcAuthorize]
    public class AboutController : poolprobaseControllerBase
    {
        public ActionResult Index()
        {
            return View();
        }
	}
}