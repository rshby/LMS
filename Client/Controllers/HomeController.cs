using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Client.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet("Unauthorized/")]
        public IActionResult Unauthorized()
        {
            return View("401");
        }

        [HttpGet("Forbidden/")]
        public IActionResult Forbidden()
        {
            return View("403");
        }

        [HttpGet("Notfound/")]
        public IActionResult Notfound()
        {
            return View("404");
        }
    }
}
