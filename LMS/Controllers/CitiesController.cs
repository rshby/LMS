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
    public class CitiesController : BaseController<City, CityRepository, int>
    {
        private readonly CityRepository cityRepo;
        public IConfiguration configuration;

        //Constructor
        public CitiesController(CityRepository cityRepo, IConfiguration configuration) : base(cityRepo)
        {
            this.cityRepo = cityRepo;
            this.configuration = configuration;
        }

        // Get Data City berdasarkan Province_Id yang diinput
        [HttpGet("byprovince/{Province_Id}")]
        public ActionResult CityByProvinceId(int Province_Id)
        {
            try
            {
                //Cek apakah Province_Id yang diinput ada di database
                if (cityRepo.CekProvinceId(Province_Id))
                {
                    var data = cityRepo.CityByProvinceId(Province_Id);

                    //Cek apabila datanya ada
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
                            message = "data City tidak ditemukan"
                        }); 
                    }
                }
                else
                {
                    return NotFound(new
                    {
                        status = 404,
                        message = "data Province dengan Id tersebut tidak ditemukan"
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
