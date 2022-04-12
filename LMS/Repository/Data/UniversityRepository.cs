using LMS.Context;
using LMS.Models;
using System.Collections.Generic;

namespace LMS.Repository.Data
{
    public class UniversityRepository : GeneralRepository<MyContext, University, int>
    {
        private readonly MyContext myContext;
        public IEnumerable<City> City { get; set; }

        //Constructor
        public UniversityRepository(MyContext myContext) : base(myContext)
        {
            this.myContext = myContext;
        }
    }
}
