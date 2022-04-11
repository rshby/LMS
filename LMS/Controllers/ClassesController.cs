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

        [HttpGet("section/{key}")]
        public ActionResult UpdateClass(int key)
        {
            try
            {
                var result = repository.GetSectionByClassId(key);
                return Ok(new
                {
                    status = 200,
                    message = "data ditemukan",
                    data = result
                });
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

        //Get Semua Master Class
        [HttpGet("master")]
        public ActionResult AllMasterClass()
        {
            try
            {
                var data = repository.AllMasterClass();
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
                        message = "data tidak ditemukan"
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

        //Get Master Class berdasarkan Class_Id yang diinput
        [HttpGet("masterbyid/{id}")]
        public ActionResult MasterClassById(int id)
        {
            try
            {
                var data = repository.MasterClassById(id);
                if (data != null)
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
                        message = "data tidak ditemukan"
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

        // Mster Class By Populer
        [HttpGet("master/populer")]
        public ActionResult MasterbyPopuler()
        {
            try
            {
                var data = repository.MasterPopuler();
                return Ok(new
                {
                    status = 200,
                    message = "data ditemukan",
                    data = data
                }); ;
            }
            catch (Exception e)
            {

                return BadRequest(new {
                    message = "gagal get data",
                    error = e.Message
                });
            }
        }

        // Mster Class By rating
        [HttpGet("master/rating")]
        public ActionResult MasterbyRating()
        {
            try
            {
                var data = repository.MasterRating();
                return Ok(new
                {
                    status = 200,
                    message = "data ditemukan",
                    data = data
                }); ;
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
