using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Client.Controllers
{
    [Authorize(Roles = "Peserta")]
    public class CertificateController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Code(string id)
        {
            var certCode = new[] { id };
            ViewBag.certCode1 = certCode;
            return View("index");
        }
    }
}
