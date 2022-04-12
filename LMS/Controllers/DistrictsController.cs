using LMS.Base;
using LMS.Models;
using LMS.Repository.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

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
    }
}
