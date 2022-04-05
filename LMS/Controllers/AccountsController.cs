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
    }
}
