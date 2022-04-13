using LMS.Context;
using LMS.Models;
using LMS.ViewModels;

namespace LMS.Repository.Data
{
    public class AddressRepository : GeneralRepository<MyContext, Address, int>
    {
        private readonly MyContext myContext;

        //Constructor
        public AddressRepository(MyContext myContext) : base(myContext)
        {
            this.myContext = myContext; 
        }
    }
}
