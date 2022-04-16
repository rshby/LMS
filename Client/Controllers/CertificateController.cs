using Microsoft.AspNetCore.Mvc;

namespace Client.Controllers
{
    public class CertificateController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Code(string id)
        {
            var certEmail = new[] { id };
            ViewBag.certEmail1 = certEmail;
            return View("index");
        }
    }
}
