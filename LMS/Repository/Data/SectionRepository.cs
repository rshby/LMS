using LMS.Context;
using LMS.Models;
using System.Collections.Generic;

namespace LMS.Repository.Data
{
    public class SectionRepository : GeneralRepository<MyContext, Section, int>
    {
        private readonly MyContext myContext;

        //Constructor
        public SectionRepository(MyContext myContext) : base(myContext)
        {
            this.myContext = myContext;
        }
    }
}
