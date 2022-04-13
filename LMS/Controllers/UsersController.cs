using LMS.Models;
using LMS.Base;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using LMS.Repository.Data;
using Microsoft.Extensions.Configuration;
using System;
using LMS.ViewModels;

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

                return BadRequest(new
                {
                    message = e.Message,
                    keterangan = "gagal get data"
                });
            }
        }

        //Get Master Data By Email
        [HttpPost("masterbyemail")]
        public ActionResult GetMasterUserByEmail(MasterUserVM inputData)
        {
            try
            {
                if (userRepo.CekEmail(inputData.Email) == 1)
                {
                    return Ok(new
                    {
                        status = 200,
                        message = "data ditemukan",
                        data = userRepo.GetMasterUserByEmail(inputData.Email)
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

                return BadRequest(new
                {
                    message = "gagal Get Master User By Email",
                    error = e.Message
                });
            }
        }

        //Update Data Master By Email
        [HttpPut("updatemaster")]
        public ActionResult UpdateMaster(RegisterVM inputData)
        {
            try
            {
                //Cek Apakah Email Ada
                if (userRepo.CekEmail(inputData.Email) == 1)
                {
                    var hasilUpdate = userRepo.UpdateMasterUser(inputData);
                    if (hasilUpdate == 1)
                    {
                        //Sukses Update
                        return Ok(new
                        {
                            status = 200,
                            message = "sukses update data master"
                        });
                    }
                    else
                    {
                        return BadRequest(new
                        {
                            message = "gagal update data master"
                        });
                    }
                }
                else
                {
                    return NotFound(new
                    {
                        status = 404,
                        message = $"data dengan email {inputData.Email} tidak ada di database"
                    });
                }
            }
            catch (Exception e)
            {

                return BadRequest(new
                {
                    message = "gagal update data master user",
                    error = e.Message
                });
            }
        }

        // Get Semua Daftar Pembayaran User
        [HttpGet("daftarpembayaran")]
        public ActionResult GetDaftarPembayaran()
        {
            try
            {
                var data = userRepo.AllDaftarPembayaran();
                if (data.Count != 0)
                {
                    return Ok(new
                    {
                        status = 200,
                        message = "data ditemukan",
                        data = data
                    });
                }
                else
                {
                    return NotFound(new
                    {
                        status = 404,
                        message = "data pembayaran tidak ditemukan"
                    });
                }
            }
            catch (Exception e)
            {

                return BadRequest(new
                {
                    message = "gagal get data",
                    error = e.Message
                });
            }
        }
    }
}