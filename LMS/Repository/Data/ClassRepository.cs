using LMS.Context;
using LMS.Models;
using LMS.ViewModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace LMS.Repository.Data
{
    public class ClassRepository : GeneralRepository<MyContext,Class, int>
    {
        private readonly MyContext myContext;

        //Constructor
        public ClassRepository(MyContext myContext) : base(myContext)
        {
            this.myContext = myContext;
        }

        //Register Class
        public int RegClass(RegisterClassVM register)
        {
            Class cls = new Class()
            {
                Name = register.Name,
                UrlPic = register.UrlPic,
                Desc = register.Desc,
                TotalChapter = register.TotalChapter,
                Price = register.Price,
                Rating = 0.0,
                Level_Id = register.Level_Id,
                Category_Id = register.Category_Id
            };

            myContext.Classes.Add(cls);
            var result = myContext.SaveChanges();
            return result;
        }

        //Update Class
        public int UpdateClass(UpdateRegClassVM updateRegis)
        {
            var data = myContext.Classes.SingleOrDefault(e => e.Id == updateRegis.Id);

            Class cls = new Class()
            {
                Id = data.Id,
                Name = updateRegis.Name,
                UrlPic = updateRegis.UrlPic,
                Desc = updateRegis.Desc,
                TotalChapter = updateRegis.TotalChapter,
                Price = updateRegis.Price,
                Rating = Convert.ToDouble(data.Rating),
                Level_Id = updateRegis.Level_Id,
                Category_Id = updateRegis.Category_Id
            };

            myContext.Entry(data).CurrentValues.SetValues(cls);
            myContext.SaveChanges();
            return 1;
        }

        //Content input
        public int InContent(InputContentVM content)
        {
            var getClass = myContext.Classes.SingleOrDefault(e => e.Id == content.class_id);
            if (content.chapter <= getClass.TotalChapter)
            {
                Section section = new Section()
                {
                    Chapter = content.chapter,
                    Name = content.name,
                    Content = content.content,
                    Class_Id = getClass.Id
                };

                myContext.Sections.Add(section);
                var result = myContext.SaveChanges();
                return result;
            }
            else
            {
                return -200;
            }
        }

        //Update Content 
        public int UpdateContent(InputContentVM content)
        {
            var getClass = myContext.Classes.Join(myContext.Sections,
                c => c.Id,
                s => s.Class_Id, (c, s) => new
                {
                    Class_Id = c.Id,
                    Chapter = s.Chapter,
                    Section_Id = s.Id,
                    TotalChapter = c.TotalChapter

                }).SingleOrDefault(e => (e.Class_Id == content.class_id) && (e.Chapter == content.chapter));
            
            if (content.chapter <= getClass.TotalChapter)
            {
                Section section = new Section()
                {
                    Id = getClass.Section_Id,
                    Chapter = content.chapter,
                    Name = content.name,
                    Content = content.content,
                    Class_Id = getClass.Class_Id
                };

                myContext.Entry(section).State = EntityState.Modified;
                var result = myContext.SaveChanges();
                return result;
            }
            else
            {
                return -200;
            }
        }

        public IEnumerable GetSectionByClassId(int inputClass)
        {
            var data = myContext.Classes
                .Join(myContext.Levels, c => c.Level_Id, l => l.Id, (c, l) => new { c, l })
                .Join(myContext.Categories, cl => cl.c.Category_Id, ct => ct.Id, (cl, ct) => new { cl, ct })
                .Select(data => new ClassVM()
                {
                    Class_Id = data.cl.c.Id,
                    Class_Name = data.cl.c.Name,
                    Class_UrlPic = data.cl.c.UrlPic,
                    Class_Desc = data.cl.c.Desc,
                    Class_TotalChapter = data.cl.c.TotalChapter,
                    Class_Price = data.cl.c.Price,
                    Class_Rating = data.cl.c.Rating,
                    Level_Id = data.cl.l.Id,
                    Level_Name = data.cl.l.Name,
                    Category_Id = data.ct.Id,
                    Category_Name = data.ct.Name,
                    Jumlah_Peserta = myContext.TakenClasses.Where(x => x.Class_Id == data.cl.c.Id && x.IsPaid == true).Count()
                }).ToList();
            return data;
        }

        //Get Semua data Master Class yang paling populer -> sorting jumlah_peserta descending
        public List<ClassVM> MasterPopuler()
        {
            var data = AllMasterClass().OrderByDescending(x => x.Jumlah_Peserta).ToList();
            return data;
        }

        //get semua data Master Clas by rating paling tinggi
        public List<ClassVM> MasterRating()
        {
            var data = AllMasterClass().OrderByDescending(x => x.Class_Rating).ToList();
            return data;
        }
     }
}
