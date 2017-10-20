using poolprobase.Controllers;
using Microsoft.AspNetCore.Antiforgery;

namespace poolprobase.Web.Host.Controllers
{
    public class AntiForgeryController : poolprobaseControllerBase
    {
        private readonly IAntiforgery _antiforgery;

        public AntiForgeryController(IAntiforgery antiforgery)
        {
            _antiforgery = antiforgery;
        }

        public void GetToken()
        {
            _antiforgery.SetCookieTokenAndHeader(HttpContext);
        }
    }
}