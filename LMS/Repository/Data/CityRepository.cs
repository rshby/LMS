using LMS.Context;
using LMS.Models;
using System.Collections.Generic;

namespace LMS.Repository.Data
{
    public class CityRepository : GeneralRepository<MyContext, City, int>
    {
        private readonly MyContext myContext;
        public IEnumerable<City> City { get; set; }

        //Constructor
        public CityRepository(MyContext myContext) : base(myContext)
        {
            this.myContext = myContext;
        }
    }
}
