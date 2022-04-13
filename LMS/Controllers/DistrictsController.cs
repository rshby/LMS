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
    public class DistrictsController : BaseController<District, DistrictRepository, int>
    {
        private readonly DistrictRepository districtRepo;
        public IConfiguration configuration;

        //Constructor
        public DistrictsController(DistrictRepository districtRepo, IConfiguration configuration) : base(districtRepo)
        {
            this.districtRepo = districtRepo;
            this.configuration = configuration;
        }

        //Get District berdasarkan parameter City_Id yang diinputkan -> hasil banyak data
        [HttpGet("bycity/{City_Id}")]
        public ActionResult DistrictByCityId(int City_Id)
        {
            try
            {
                //Cek apakah City_Id yang diinputkan ada di database
                if (districtRepo.CekCityId(City_Id))
                {
                    var data = districtRepo.DistrictByCityId(City_Id);
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
                        return Ok(new
                        {
                            status = 404,
                            message = "data District tidak ditemukan"
                        });
                    }
                }
                else
                {
                    return Ok(new
                    {
                        status = 404,
                        message = "data City dengan Id tersebut tidak ada"
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