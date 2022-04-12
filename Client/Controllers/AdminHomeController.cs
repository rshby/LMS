using Microsoft.AspNetCore.Mvc;

namespace Client.Controllers
{
    public class AdminHomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
