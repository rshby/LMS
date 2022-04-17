using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Client.Controllers
{
    [Authorize(Roles = "Admin")]
    public class ClassAdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet("data")]
        public IActionResult data()
        {
            return View("DataPembayaran");
        }

        [HttpGet("regclass")]
        public IActionResult RegClass()
        {
            return View("CreateClass");
        }
        
        [HttpGet("dataclass")]
        public IActionResult TableClass()
        {
            return View("TableClass");
        }
        
        [HttpGet("regsection")]
        public IActionResult regSection()
        {
            return View("InputContent");
        }
        
        [HttpGet("datasection")]
        public IActionResult TableContent()
        {
            return View("TableContent");
        }
    }
}
