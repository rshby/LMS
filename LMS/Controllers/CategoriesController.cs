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
    public class CategoriesController : BaseController<Category, CategoryRepository, int>
    {
        private readonly CategoryRepository categoryRepo;
        public IConfiguration configuraion;
        public CategoriesController(CategoryRepository categoryRepo, IConfiguration configuration) : base(categoryRepo)
        {
            this.categoryRepo = categoryRepo;
            this.configuraion = configuration;
        }

    }
}
