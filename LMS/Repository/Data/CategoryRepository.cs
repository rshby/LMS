using LMS.Context;
using LMS.Models;
using LMS.ViewModels;
using MailKit.Net.Smtp;
using Microsoft.EntityFrameworkCore;
using MimeKit;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LMS.Repository.Data
{
    public class CategoryRepository : GeneralRepository<MyContext, Category, int>
    {
        private readonly MyContext myContext;

        //Constructor
        public CategoryRepository(MyContext myContext) : base(myContext)
        {
            this.myContext = myContext;
        }
    }
}
