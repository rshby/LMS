using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Client.Controllers
{
    public class ClassController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Details(int classId) //Details/1
        {
            ViewBag.ClassId = classId;
            return View();
        }
    }
}
