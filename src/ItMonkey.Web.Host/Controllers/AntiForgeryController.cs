using Microsoft.AspNetCore.Antiforgery;
using ItMonkey.Controllers;

namespace ItMonkey.Web.Host.Controllers
{
    public class AntiForgeryController : ItMonkeyControllerBase
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
