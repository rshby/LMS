using LMS.Base;
using LMS.Models;
using LMS.Repository.Data;
using LMS.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace LMS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EducationsController : BaseController<Education, EducationRepository, int>
    {
        private readonly EducationRepository educationRepo;
        public readonly IConfiguration configuration;

        //Constructor
        public EducationsController(EducationRepository educationRepo, IConfiguration configuration) : base(educationRepo)
        {
            this.educationRepo = educationRepo;
            this.configuration = configuration;
        }
    }
}
