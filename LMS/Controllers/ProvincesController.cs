using LMS.Base;
using LMS.Models;
using LMS.Repository.Data;
using LMS.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;

namespace LMS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProvincesController : BaseController<Province, ProvinceRepository, int>
    {
        private readonly ProvinceRepository provinceRepo;
        public IConfiguration configuraion;

        public ProvincesController(ProvinceRepository provinceRepo, IConfiguration configuration) : base(provinceRepo)
        {
            this.provinceRepo = provinceRepo;
            this.configuraion = configuration;
        }

    }
}
