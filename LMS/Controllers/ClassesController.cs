using Client.Base;
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
    public class ClassesController : BaseController<Class, ClassRepository, int>
    {
        private readonly ClassRepository repository;
        public IConfiguration configuration;

        public ClassesController(ClassRepository repository, IConfiguration configuration) : base(repository)
        {
            this.repository = repository;
            this.configuration = configuration;
        }

        [HttpPost("regClass")]
        public ActionResult Register(RegisterClassVM classes)
        {
            try
            {
                var result = repository.RegClass(classes);
                if (result == 0)
                {
                    return BadRequest(new
                    {
                        message = "Gagal input Class"
                    });
                }
                else if (result == 1)
                {
                    return Ok(new
                    {
                        message = "Input berhasil"
                    });
                }
                else
                {
                    return Ok(new
                    {
                        message = "Input berhasil"
                    });
                }

            }
            catch (Exception e)
            {
                return BadRequest(new
                {
                    message = "Data belum terisi dengan benar",
                    e.Message
                });
            }
        }

        [HttpPost("InputContent")]
        public ActionResult InputContent(InputContentVM input)
        {
            try
            {
                var result = repository.InContent(input);
                if (result == 1)
                {
                    return Ok(new
                    {
                        message = "Penyimpanan Berhasil"
                    });
                }
                else if (result == -200)
                {
                    return BadRequest(new
                    {
                        message = "Input Gagal Karena Jumlah melebihi chapter"
                    });
                }
                else
                {
                    return BadRequest(new
                    {
                        message = "Gagal Input Content"
                    });
                }
            }
            catch (Exception e)
            {

                return BadRequest(new
                {
                    message = "Gagal Method Input", e.Message
                });
            }
            
        }
        [HttpPut("UpdateContent")]
        public ActionResult UpdateContent(InputContentVM input)
        {
            try
            {
                var result = repository.UpdateContent(input);
                if (result == 1)
                {
                    return Ok(new
                    {
                        message = "Edit Berhasil"
                    });
                }
                else if (result == -200)
                {
                    return BadRequest(new
                    {
                        message = "Edit Gagal Karena Jumlah melebihi chapter"
                    });
                }
                else
                {
                    return BadRequest(new
                    {
                        message = "Gagal Edit Content"
                    });
                }
            }
            catch (Exception e)
            {

                return BadRequest(new
                {
                    message = "Gagal Method Edit",
                    e.Message
                });
            }

        }

        [HttpPut("UpdateClass")]
        public ActionResult UpdateClass(UpdateRegClassVM input)
        {
            try
            {
                var result = repository.UpdateClass(input);
                if (result == 1)
                {
                    return Ok(new
                    {
                        message = "Update Class Berhasil"
                    });
                }
                else
                {
                    return BadRequest(new
                    {
                        message = "Gagal Update Class"
                    });
                }
            }
            catch (Exception e)
            {
                return BadRequest(new
                {
                    message = "Gagal Method Update Class",
                    e.Message
                });
            }

        }

    }

}
