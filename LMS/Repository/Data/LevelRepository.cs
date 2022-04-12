using LMS.Context;
using LMS.Models;
using System.Collections.Generic;

namespace LMS.Repository.Data
{
    public class LevelRepository : GeneralRepository<MyContext, Level, int>
    {
        private readonly MyContext myContext;

        //Constructor
        public LevelRepository(MyContext myContext) : base(myContext)
        {
            this.myContext = myContext;
        }
    }
}
