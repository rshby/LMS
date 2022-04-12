using LMS.Context;
using LMS.Models;
using System.Collections.Generic;

namespace LMS.Repository.Data
{
    public class ProvinceRepository : GeneralRepository<MyContext, Province, int>
    {
        private readonly MyContext myContext;
        public IEnumerable<Province> Province { get; set; }

        //Constructor
        public ProvinceRepository(MyContext myContext) : base(myContext)
        {
            this.myContext = myContext;
        }
    }
}