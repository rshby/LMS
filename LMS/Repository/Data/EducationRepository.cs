using LMS.Context;
using LMS.Models;
using LMS.ViewModels;

namespace LMS.Repository.Data
{
    public class EducationRepository : GeneralRepository<MyContext, Education, int>
    {
        private readonly MyContext myContext;

        //Constructor
        public EducationRepository(MyContext myContext) : base(myContext)
        {
            this.myContext = myContext;
        }
    }
}
