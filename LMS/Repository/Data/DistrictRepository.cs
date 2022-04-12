using LMS.Context;
using LMS.Models;
using System.Collections.Generic;

namespace LMS.Repository.Data
{
    public class DistrictRepository : GeneralRepository<MyContext, District, int>
    {
        private readonly MyContext myContext;
        public IEnumerable<District> District { get; set; }

        //Constructor
        public DistrictRepository(MyContext myContext) : base(myContext)
        {
            this.myContext = myContext;
        }
    }
}
