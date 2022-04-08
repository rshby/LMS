using LMS.Context;
using LMS.Models;
using System.Collections.Generic;
using System.Linq;

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

        //Get City berdasarkan Province_Id yang diinputkan
        public List<City> CityByProvinceId(int inputProvinceId)
        {
            var data = myContext.Cities.Where(x => x.Province_Id == inputProvinceId).ToList();  
            return data;
        }

        //Cek Province Id apakah ada di database
        public bool CekProvinceId(int inputProvinceId)
        {
            var dataCek = myContext.Provinces.SingleOrDefault(x => x.Id == inputProvinceId);
            if (dataCek != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
