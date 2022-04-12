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
    public class UniversitiesController : BaseController<University, UniversityRepository, int>
    {
        private readonly UniversityRepository repository;
        public IConfiguration configuration;

        //Constructor
        public UniversitiesController(UniversityRepository repository, IConfiguration configuration) : base(repository)
        {
            this.repository = repository;
            this.configuration = configuration;
        }
    }
}
