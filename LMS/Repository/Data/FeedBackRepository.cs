using LMS.Context;
using LMS.Models;
using LMS.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LMS.Repository.Data
{
    public class FeedBackRepository : GeneralRepository<MyContext, FeedBack, float>
    {
        private readonly MyContext myContext;

        //Constructor
        public FeedBackRepository(MyContext myContext) : base(myContext)
        {
            this.myContext = myContext;
        }

        //Cek Email apakah Ada di Database
        public bool CekEmail(string inputEmail)
        {
            var cekData = myContext.Accounts.FirstOrDefault(c => c.Email == inputEmail);
            if (cekData != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        //Cek Class Id apakah Ada di Database
        public bool CekClass(int inputClassId)
        {
            var cekData = myContext.Classes.FirstOrDefault(x => x.Id == inputClassId);
            if (cekData != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        //Ambil Semua Data FeedBack yang Ada Berdasarkan Class Id
        public List<AllFeedBackVM> GetAllFeedBackByClass(int inputClassId)
        {
            var data = myContext.Classes.Where(x => x.Id == inputClassId)
                .Join(myContext.TakenClasses, c => c.Id, t => t.Class_Id, (c, t) => new { c, t })
                .Join(myContext.FeedBacks, ct => ct.t.Id, f => f.TakenClass_Id, (ct, f) => new { ct, f })
                .Select(data => new AllFeedBackVM()
                {
                    Class_Id = data.ct.c.Id,
                    Class_Name = data.ct.c.Name,
                    Class_Desc = data.ct.c.Desc,
                    Class_Rating = data.ct.c.Rating,
                    TakenClass_Id = data.ct.t.Id,
                    TakenClass_Email = data.ct.t.Email,
                    FeedBack_Id = data.f.Id,
                    FeedBack_Rating = data.f.Rating
                }).ToList();

            return data;
        }

        //Insert FeedBack
        //Menambah Feedback Oleh User
        public int AddFeedBack(InsertFeedBackVM inputData)
        {
            //Ambil Data TakenClass Berdasarkan Email dan Class_Id yang diinput
            var dataTC = myContext.TakenClasses.SingleOrDefault(x => (x.Email == inputData.Email) && (x.Class_Id == inputData.Class_Id));

            //Ambil data class yang diikuti berdasarkan dataTC
            var dataClass = myContext.Classes.SingleOrDefault(x => x.Id == dataTC.Class_Id);

            //Siapkan variabel untuk menampung data feedback yang akan diinsert
            FeedBack dataFeedBack = new FeedBack()
            {
                Rating = Convert.ToDouble(inputData.Rating),
                Review = inputData.Review,
                TakenClass_Id = dataTC.Id
            };

            //insert ke tabel feedback
            myContext.FeedBacks.Add(dataFeedBack);
            myContext.SaveChanges();

            // Ambil semua data feddback yang ada pada Class ini
            var dataFeedBackByClass = GetAllFeedBackByClass(dataClass.Id);

            //hitung jumlah data feedback pada class yang diikuti (pembagi)
            var jumlahDataFeedBack = dataFeedBackByClass.Count();

            //Ambil Data yang digunakan untuk pembilang
            var jumlahTotalFeedBack = dataFeedBackByClass.Select(d => d.FeedBack_Rating).Sum();

            //Siapkan variabel untuk menampung data class yang akan diupdate
            Class updateClass = new Class()
            {
                Id = dataClass.Id,
                Name = dataClass.Name,
                UrlPic = dataClass.UrlPic,
                Desc = dataClass.Desc,
                TotalChapter = dataClass.TotalChapter,
                Price = dataClass.Price,
                Rating = jumlahTotalFeedBack/jumlahDataFeedBack,
                Level_Id = dataClass.Level_Id,
                Category_Id = dataClass.Category_Id
            };

            //Proses update data class ke tabel
            myContext.Entry(dataClass).CurrentValues.SetValues(updateClass);
            myContext.SaveChanges();

            //Siapkan variabel untuk menampung data certificat yang akan diinsert
            Certificate dataSertif = new Certificate()
            {
                Code = new Random().Next(111111, 999999).ToString(),
                TakenClass_Id = dataTC.Id
            };

            //Proses Insert data certificate ke database
            myContext.Certificates.Add(dataSertif);
            myContext.SaveChanges();

            return 1;
        }
    }
}
