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
    public class CategoriesController : BaseController<Category, CategoryRepository, int>
    {
        private readonly CategoryRepository repository;
        public IConfiguration configuration;

        //Constructor
        public CategoriesController(CategoryRepository repository, IConfiguration configuration) : base(repository)
        {
            this.repository = repository;
            this.configuration = configuration;
        }
=======
    public class CategoriesController : BaseController<Category, CategoryRepository, int>
    {
        private readonly CategoryRepository categoryRepo;
        public IConfiguration configuraion;
        public CategoriesController(CategoryRepository categoryRepo, IConfiguration configuration) : base(categoryRepo)
        {
            this.categoryRepo = categoryRepo;
            this.configuraion = configuration;
        }

>>>>>>> Denny
    }
}
