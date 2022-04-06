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
    }
}
