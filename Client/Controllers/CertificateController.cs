using Microsoft.AspNetCore.Mvc;

namespace Client.Controllers
{
    public class CertificateController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
