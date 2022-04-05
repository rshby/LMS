using LMS.Context;
using LMS.Models;
using System.Collections;
using System.Linq;

namespace LMS.Repository.Data
{
    public class UserRepository : GeneralRepository<MyContext, User, string>
    {
        private readonly MyContext myContext;

        //Constructor
        public UserRepository(MyContext myContext) : base(myContext)
        {
            this.myContext = myContext;
        }

        //Get All User Data
        public IEnumerable AllMasterUser()
        {
            //join data
            var data = myContext.Users
                .Join(myContext.Addresses, u => u.Address_Id, a => a.Id, (u, a) => new {u,a})
                .Join(myContext.SubDistricts, ua => ua.a.Subdistrict_Id, sd => sd.Id, (ua, sd) => new {ua, sd})
                .Join(myContext.Districts, uasd => uasd.sd.District_Id, d => d.Id, (uasd, d) => new { uasd, d})
                .Join(myContext.Cities, uasdd => uasdd.d.City_Id, c => c.Id, (uasdd, c) => new {uasdd, c})
                .Join(myContext.Provinces, uasddc => uasddc.c.Province_Id, p => p.Id, (uasddc, p) => new { uasddc, p})
                .Join(myContext.Educations, uasddcp => uasddcp.uasddc.uasdd.uasd.ua.u.Education_Id, e => e.Id)

            return null;
        }
    }
}
