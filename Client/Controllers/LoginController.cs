using Client.Base;
using Client.Repositories.Data;
using Client.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
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

            //Ambil Rolesnya
            var handler = new JwtSecurityTokenHandler();
            var jsonToken = handler.ReadToken(token);
            var tokenS = jsonToken as JwtSecurityToken;
            var rolesLogin = tokenS.Claims.First(claim => claim.Type == "roles").Value; // -> Peserta, Admin, Trainer

            //bawa session saat login
            HttpContext.Session.SetString("jwt", token); // -> wpieukash12312lkajhsfkaj0293
            HttpContext.Session.SetString("email", inputData.Email);

            //Cek jika roles adalah peserta
            if (rolesLogin == "Peserta")
            {
                return RedirectToAction("index", "Dashboard");
            }
            else
            {
                return RedirectToAction("index", "AdminHome");
            }
        }

        public async Task<IActionResult> Terminate()
        {
            HttpContext.Session.SetString("jwt", "");
            HttpContext.Session.SetString("email", "");
            return RedirectToAction("index", "Home");
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
