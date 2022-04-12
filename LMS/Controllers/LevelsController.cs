using LMS.Base;
using LMS.Models;
using LMS.Repository.Data;
<<<<<<< HEAD
=======
using LMS.ViewModels;
>>>>>>> Denny
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;

namespace LMS.Controllers
{
<<<<<<< HEAD
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
=======
    public class LevelsController : BaseController<Level, LevelRepository, int>
    {
        private readonly LevelRepository levelRepo;
        public IConfiguration configuraion;
        public LevelsController(LevelRepository levelRepo, IConfiguration configuration) : base(levelRepo)
        {
            this.levelRepo = levelRepo;
            this.configuraion = configuration;
        }

>>>>>>> Denny
    }
}
