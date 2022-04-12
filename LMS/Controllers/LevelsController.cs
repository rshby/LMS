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
    }
}