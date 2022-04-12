using LMS.Base;
using LMS.Models;
using LMS.Repository.Data;
<<<<<<< HEAD
using LMS.ViewModels;
=======
>>>>>>> parent of 1cbd5a5 (-c)
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;

namespace LMS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : BaseController<Category, CategoryRepository, int>
    {
<<<<<<< HEAD
        private readonly CategoryRepository categoryRepo;
        public IConfiguration configuraion;
        public CategoriesController(CategoryRepository categoryRepo, IConfiguration configuration) : base(categoryRepo)
        {
            this.categoryRepo = categoryRepo;
            this.configuraion = configuration;
=======
        private readonly CategoryRepository repository;
        public IConfiguration configuration;

        //Constructor
        public CategoriesController(CategoryRepository repository, IConfiguration configuration) : base(repository)
        {
            this.repository = repository;
            this.configuration = configuration;
>>>>>>> parent of 1cbd5a5 (-c)
        }
    }
}
