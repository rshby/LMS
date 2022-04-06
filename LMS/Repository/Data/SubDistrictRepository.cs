using LMS.Context;
using LMS.Models;
using System;
using System.Collections.Generic;

namespace LMS.Repository.Data
{
    public class SubDistrictRepository : GeneralRepository<MyContext, SubDistrict, int>
    {
        private readonly MyContext myContext;

        //Constructor
        public SubDistrictRepository(MyContext myContext) : base(myContext)
        {
            this.myContext = myContext;
        }
    }
}
