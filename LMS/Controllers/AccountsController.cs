using LMS.Base;
using LMS.Models;
using LMS.Repository.Data;
using LMS.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;

namespace LMS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountsController : BaseController<Account, AccountRepository, string>
    {
        private readonly AccountRepository accountRepo;
        public IConfiguration configuration;

        public AccountsController(AccountRepository accountRepo, IConfiguration configuration) : base(accountRepo)
        {
            this.accountRepo = accountRepo;
            this.configuration = configuration;
        }

        //Mendaftar Akun
        [HttpPost("register")]
        public ActionResult Register(RegisterVM inputData)
        {
            try
            {
                //cek inputData tidak kosong
                if (inputData != null)
                {
                    var hasilRegister = accountRepo.Register(inputData);
                    if (hasilRegister == 1)
                    {
                        return Ok(new
                        {
                            message = "Sukses Register Berhasil"
                        }); 
                    }
                    else
                    {
                        return BadRequest(new
                        {
                            message = "maaf, nomor telepon sudah ada"
                        });
                    }
                }
                else
                {
                    return BadRequest(new
                    {
                        message = "data register tidak terisi"
                    });
                }
            }
            catch (Exception e)
            {

                return BadRequest(new
                {
                    message = "gagal insert",
                    error = e.Message
                });
            }
        }

        //Login
        [HttpPost("login")]
        public ActionResult Login(LoginVM inputData)
        {
            try
            {
                //Cek Apakah Email Ada di Database
                if (accountRepo.CekEmail(inputData.Email) == 1)
                {
                    var hasilLogin = accountRepo.Login(inputData);
                    if (hasilLogin == 1)
                    {
                        return Ok(new
                        {
                            status = 200,
                            message = "login berhasil"
                        });
                    }
                    else
                    {
                        return BadRequest(new
                        {
                            message = "password anda salah"
                        });
                    }
                }
                else
                {
                    return NotFound(new
                    {
                        message = "data email tidak ditemukan di database"
                    });
                }
            }
            catch (Exception e)
            {

                return BadRequest(new
                {
                    message = "gagal login",
                    error = e.Message
                });
            }
        }
    }
}
