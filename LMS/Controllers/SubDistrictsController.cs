using LMS.Base;
using LMS.Models;
using LMS.Repository.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;

namespace LMS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubDistrictsController : BaseController<SubDistrict, SubDistrictRepository, int>
    {
        private readonly SubDistrictRepository subDistrictRepo;
        private readonly IConfiguration configuration;

        //Constructor
        public SubDistrictsController(SubDistrictRepository subDistrictRepo, IConfiguration configuration) : base(subDistrictRepo)
        {
            this.subDistrictRepo = subDistrictRepo;
            this.configuration = configuration;
        }

        //Get SubDistrict berdasarkan parameter District_Id yang diinputkan
        [HttpGet("bydistrict/{District_Id}")]
        public ActionResult GetByDistrictId(int District_Id)
        {
            try
            {
                //Cek apakah District_Id ada di database atau tidak
                if (subDistrictRepo.CekDistrictId(District_Id))
                {
                    var data = subDistrictRepo.SubDistrictByDistrictId(District_Id);
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
                            message = "data SubDistrict tidak ditemukan"
                        });
                    }
                }
                else
                {
                    return NotFound(new
                    {
                        status = 404,
                        message = "data District dengan Id tersebut tidak ada di database"
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
