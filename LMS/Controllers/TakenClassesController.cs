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
    public class TakenClassesController : BaseController<TakenClass, TakenClassRepository, int>
    {
        private readonly TakenClassRepository takenClassRepo;
        private readonly IConfiguration configuration;

        //Constructor
        public TakenClassesController(TakenClassRepository takenClassRepo, IConfiguration configuration) : base(takenClassRepo)
        {
            this.takenClassRepo = takenClassRepo;
            this.configuration = configuration;
        }

        //Register
        [HttpPost("register")]
        public ActionResult RegisterTC(RegisterTakenClassVM inputData)
        {
            try
            {
                //Cek Email
                if (takenClassRepo.CekEmail(inputData.Email) == 1)
                {
                    //Cek Apakah Kelas dengan Id tersebut ada di database
                    if (takenClassRepo.CekClassId(inputData.Class_Id)) // if(true)
                    {
                        //Cek Hasil Register
                        var hasilRegisterTakenClass = takenClassRepo.RegisterTakenClass(inputData);

                        if (hasilRegisterTakenClass == 1)
                        {
                            return Ok(new
                            {
                                status = 200,
                                message = "sukses register taken class"
                            });
                        }
                        else
                        {
                            return BadRequest(new
                            {
                                status = 400,
                                message = "Kelas sudah pernah didaftar"
                            });
                        }
                    }
                    else
                    {
                        return NotFound(new
                        {
                            status = 404,
                            message = $"Kelas dengan Id {inputData.Class_Id} tidak ada di database"
                        });
                    }
                }
                else
                {
                    return NotFound(new
                    {
                        status = 404,
                        message = $"data dengan email {inputData.Email} tidak ditemukan"
                    });
                }
            }
            catch (Exception e)
            {

                return BadRequest(new
                {
                    message = "gagal register taken class",
                    error = e.Message
                });
            }
        }

        //Get TakenClassByEmail
        [HttpGet("byemail/{email}")]
        public ActionResult GetTakenClassByEmail(string email)
        {
            try
            {
                //Cek Email
                if (takenClassRepo.CekEmail(email) == 1)
                {
                    //ambil data
                    var data = takenClassRepo.GetTakenClassByEmail(email);

                    //Cek jika data tidak kosong
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
                        //Data Kosong
                        return NotFound(new
                        {
                            status = 404,
                            message = "data tidak ditemukan"
                        });
                    }
                }
                else
                {
                    return NotFound(new
                    {
                        status = 404,
                        message = $"data dengan email {email} tidak ditemukan"
                    });
                }
            }
            catch (Exception e)
            {

                return BadRequest(new
                {
                    message = "error get taken class by email data",
                    error = e.Message
                });
            }
        }

        //Get Taken Class by Email and IsDone
        [HttpGet("isdone")]
        public ActionResult GetTakenClassByIsDone(TakenClassIsDoneVM inputData)
        {
            try
            {
                //Cek Email
                if (takenClassRepo.CekEmail(inputData.Email) == 1)
                {
                    //ambil data
                    var data = takenClassRepo.GetTakenClassByIsDone(inputData);

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
                    message = "error get taken class by isDone",
                    error = e.Message
                });
            }
        }

        //Get Taken Class By Class_Id
        [HttpGet("classid/{class_id}")]
        public ActionResult GetTakenClassByClassId(int class_id)
        {
            try
            {
                //Cek Apakah Data Class dengan Id tersebut ada
                if (takenClassRepo.CekClassId(class_id))
                {
                    //Ambil Datanya
                    var data = takenClassRepo.GetTakenClassByClassId(class_id);
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
                else
                {
                    return NotFound(new
                    {
                        status = 404,
                        message = "data dengan id tersebut tidak ada"
                    });
                }

            }
            catch (Exception e)
            {

                return BadRequest(new
                {
                    message = "error get taken class by Class_Id",
                    error = e.Message
                });
            }
        }

        //Get Taken Class By Email dan Class_Id -> hasil 1 data aja
        //Mendapatkan data taken classes spesifik siapa usernya dan kelas apa yang diambil
        [HttpGet("byEmailAndClassId")]
        public ActionResult ByEmailAndClassId(TakenClassVM inputData)
        {
            try
            {
                //Cek Email dan Class_Id apakah Ada di database
                if (takenClassRepo.CekEmail(inputData.Email) == 1 && takenClassRepo.CekClassId(inputData.Class_Id))
                {
                    var data = takenClassRepo.GetTakenClassByEmailClassId(inputData.Email, inputData.Class_Id);
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
                else
                {
                    return NotFound(new
                    {
                        status = 404,
                        message = "data email dan class id tidak ditemukan di database"
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

        //Next Chapter (Menambah ProgressChapter)
        [HttpPost("nextchapter")]
        public ActionResult NextChapter(RegisterTakenClassVM inputData)
        {
            try
            {
                if (takenClassRepo.CekEmail(inputData.Email) == 1 && takenClassRepo.CekClassId(inputData.Class_Id))
                {
                    var hasilNextChapter = takenClassRepo.NextChapter(inputData);

                    if (hasilNextChapter == 1)
                    {
                        var data = takenClassRepo.GetTakenClassByEmailClassId(inputData.Email, inputData.Class_Id);

                        return Ok(new
                        {
                            status = 200,
                            message = "chapter bertambah 1",
                            data = data
                        });
                    }
                    else if(hasilNextChapter == -1)
                    {
                        return Ok(new { 
                            status = 200,
                            message = "semua chapter terselesaikan"
                        });
                    }
                    else
                    {
                        return BadRequest(new
                        {
                            status = 400,
                            message = "gagal next chapter"
                        });
                    }
                }
                else
                {
                    return NotFound(new
                    {
                        status = 404,
                        message = "data email atau class id tidak ditemukan di database"
                    });
                }
            }
            catch (Exception e)
            {

                return BadRequest(new
                {
                    message = "gagal next chapter",
                    error = e.Message
                });
            }
        }

        //Get Taken Class By IsPaid = False
        //Mendapatkan Daftar TakenClass Berdasarkan Usernya siapa dan Belum Bayar
        [HttpGet("ispaidfalse")]
        public ActionResult GetTakenClassIsPaidFalse(TakenClassVM inputData)
        {
            try
            {
                //Cek Email
                if (takenClassRepo.CekEmail(inputData.Email) == 1)
                {
                    //Ambil data dari takenclassRepo
                    var data = takenClassRepo.GetTakenClassByIsPaidFalse(inputData);

                    //Cek jika variabal data ada isinya
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
                else
                {
                    return NotFound(new
                    {
                        status = 404,
                        message = $"data dengan email {inputData.Email} tidak ditemukan"
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

        //Get Taken Class By OrderId
        //Melihat data TakenClass berdasarkan OrderId yang Diinput -> hasil 1 data
        [HttpGet("byorderid")]
        public ActionResult GetTakenClassByOrderId(TakenClassVM inputData)
        {
            try
            {
                var data = takenClassRepo.GetTakenClassByOrderId(inputData);
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
                        status = 400,
                        message = "data tidak ditemukan"
                    });
                }
            }
            catch (Exception e)
            {

                return BadRequest(new
                {
                    message = "gagal menampilkan data",
                    error = e.Message
                });
            }
        }
    }
}
