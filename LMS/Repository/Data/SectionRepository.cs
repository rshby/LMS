using LMS.Context;
using LMS.Models;
using System.Collections.Generic;
using System.Linq;

namespace LMS.Repository.Data
{
    public class SectionRepository : GeneralRepository<MyContext, Section, int>
    {
        private readonly MyContext myContext;

        //Constructor
        public SectionRepository(MyContext myContext) : base(myContext)
        {
            this.myContext = myContext;
        }

        // Cek inputan Class_Id apakah ada di database
        public bool CekClassId(int inputClassId)
        {
            var cekData = myContext.Classes.SingleOrDefault(x => x.Id == inputClassId);
            if (cekData != null)
            {
                return true;
            }
            else
            { 
                return false; 
            }
        }

        //Menampilkan Semua Section by Class_Id yang diinputkan
        public List<Section> SectionByClassId(int inputClassId)
        {
            var data = myContext.Sections.Where(x => x.Class_Id == inputClassId).ToList();
            return data;
        }
    }
}
