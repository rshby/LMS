using LMS.Context;
using LMS.Models;
using System.Collections.Generic;

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
