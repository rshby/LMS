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
    public class CertificatesController : BaseController<Certificate, CertificateRepository, int>
    {
        private readonly CertificateRepository certificateRepo;
        private readonly IConfiguration configuration;

        //Constructor
        public CertificatesController(CertificateRepository certificateRepo, IConfiguration configuration) : base(certificateRepo)
        {
            this.certificateRepo = certificateRepo;
            this.configuration = configuration;
        }

        //Get All Certificate Data Lengkap
        [HttpGet("all")]
        public ActionResult GetAll()
        {
            try
            {
                var data = certificateRepo.AllCerfiticate();

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
                    message = "gagal get certificate",
                    error = e.Message
                });
            }
        }

        // Get Certificate Berdasarkan Email dan Class_Id yang diinput -> hasil 1 data aja
        [HttpPost("byemailclassid")]
        public ActionResult GetByEmailClassId(TakenClassVM inputData)
        {
            try
            {
                //Cek Id Kelas apakah ada di database
                if (certificateRepo.CekClass(inputData.Class_Id))
                {
                    var data = certificateRepo.GetCertificateByEmailClassId(inputData);
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
                            message = "data tidak ditemukan di database, periksa Email anda!"
                        });
                    }
                }
                else
                {
                    return NotFound(new
                    {
                        status = 404,
                        message = $"Class dengan Id {inputData.Class_Id} tidak ada di database"
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