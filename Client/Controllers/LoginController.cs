using Client.Base;
using Client.Repositories.Data;
using Client.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Client.Controllers
{
    public class LoginController : BaseController<LoginVM, LoginRepository, string>
    {
        private readonly LoginRepository loginRepo;
        public LoginController(LoginRepository loginRepo) : base(loginRepo)
        {
                this.loginRepo = loginRepo;
        }

        [HttpPost]
        public async Task<IActionResult> Auth(LoginVM inputData)
        {
            var jwtToken = await loginRepo.Auth(inputData);
            var token = jwtToken.token;
            
            if (token == null)
            {
                return RedirectToAction("index");
            }
            
            HttpContext.Session.SetString("jwt", token);
            HttpContext.Session.SetString("email", inputData.Email);
            
            return RedirectToAction("index", "Dashboard");
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
