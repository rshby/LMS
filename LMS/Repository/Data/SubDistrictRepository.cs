using LMS.Context;
using LMS.Models;
using System.Linq;
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

        //Cek District_Id yang diinputkan apakah ada di database
        public bool CekDistrictId(int inputDistrictId)
        {
            var dataCek = myContext.Districts.SingleOrDefault(x => x.Id == inputDistrictId);
            if (dataCek != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        //Get SubDistrict berdasarkan parameter District_Id yang diinputkan
        public List<SubDistrict> SubDistrictByDistrictId(int inputDistrictId)
        {
            var data = myContext.SubDistricts.Where(x => x.District_Id == inputDistrictId).ToList();
            return data;
        }
    }
}
