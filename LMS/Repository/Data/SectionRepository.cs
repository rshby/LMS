using LMS.Context;
using LMS.Models;
using LMS.ViewModels;
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

        // Master Section
        public List<MasterSectionVM> AllMasterSectionVM()
        {
            var data = myContext.Sections
                .Join(myContext.Classes, s => s.Class_Id, c => c.Id, (s, c) => new { s, c})
                .Join(myContext.Levels, sc => sc.c.Level_Id, l => l.Id, (sc, l) => new { sc, l})
                .Join(myContext.Categories, scl => scl.sc.c.Category_Id, ct => ct.Id, ())
        }


        //Menampilkan Semua Section by Class_Id yang diinputkan
        public List<Section> SectionByClassId(int inputClassId)
        {
            var data = myContext.Sections.Where(x => x.Class_Id == inputClassId).ToList();
            return data;
        }
    }
}
