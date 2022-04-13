using LMS.Context;
using LMS.Models;
using System.Collections.Generic;
using System.Linq;

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

        //Cek City_Id yang diinputkan apakah ada di database
        public bool CekCityId(int inputCityId)
        {
            var dataCek = myContext.Cities.SingleOrDefault(x => x.Id == inputCityId);
            if (dataCek != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        //Get District berdasarkan parameter City_Id yang diinputkan
        public List<District> DistrictByCityId(int inputCityId)
        {
            var data = myContext.Districts.Where(x => x.City_Id == inputCityId).ToList();
            return data;
        }
    }
}