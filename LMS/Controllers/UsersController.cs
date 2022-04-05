using LMS.Models;
using LMS.Base;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using LMS.Repository.Data;
using Microsoft.Extensions.Configuration;
using System;

namespace LMS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : BaseController<User, UserRepository, string>
    {
        private readonly UserRepository userRepo;
        public IConfiguration configuration;

        //Constructor
        public UsersController(UserRepository userRepo, IConfiguration configuration) : base(userRepo)
        {
            this.userRepo = userRepo;
            this.configuration = configuration;
        }

        //GE All Master Users Data
        [HttpGet("master")]
        public ActionResult GetAllMasterUsers()
        {
            try
            {
                var hasilData = userRepo.AllMasterUser();
                if (hasilData != null)
                {
                    return Ok(new
                    {
                        status = 200,
                        message = "data ditemukan",
                        data = hasilData
                    });
                }
                else
                {
                    return NotFound(new
                    {
                        message = "data tidak ditemukan"
                    });
                }
            }
            catch (Exception e)
            {

                return BadRequest(new { 
                    message = e.Message,
                    keterangan = "gagal get data"
                });
            }
        }
    }
}
