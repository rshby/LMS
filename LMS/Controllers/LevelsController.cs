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
    public class LevelsController : BaseController<Level, LevelRepository, int>
    {
        private readonly LevelRepository levelRepo;
        public IConfiguration configuration;

        //Constructor
        public LevelsController(LevelRepository levelRepo, IConfiguration configuration) : base(levelRepo)
        {
            this.levelRepo = levelRepo;
            this.configuration = configuration;
        }
    }
}