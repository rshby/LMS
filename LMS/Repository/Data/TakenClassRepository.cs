using LMS.Context;
using LMS.Models;
using LMS.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LMS.Repository.Data
{
    public class TakenClassRepository : GeneralRepository<MyContext, TakenClass, int>
    {
        private readonly MyContext myContext;

        //Constructor
        public TakenClassRepository(MyContext myContext) : base(myContext)
        {
            this.myContext = myContext;
        }

        //Cek Email Apakah Ada di Database
        public int CekEmail(string inputEmail)
        {
            var cek = myContext.Accounts.SingleOrDefault(u => u.Email == inputEmail);
            if (cek != null)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }

        //Cek Id Class Apakah Ada di Database
        public bool CekClassId(int id)
        {
            var cek = myContext.Classes.SingleOrDefault(x => x.Id == id);
            if (cek != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        //Register DaftarKelas
        public int RegisterTakenClass(RegisterTakenClassVM inputData)
        {
            //Cek Data TakenClass dengan Email dan Class_Id yang diinput apakah sudah ada
            var cek = myContext.TakenClasses.FirstOrDefault(x => (x.Email == inputData.Email) && (x.Class_Id == inputData.Class_Id));

            if (cek == null)
            {
                //Siapkan Object Untuk Menampung Data TakenClass
                TakenClass dataTakenClass = new TakenClass()
                {
                    Email = inputData.Email,
                    ProgressChapter = 0,
                    IsDone = false,
                    OrderId =  inputData.OrderId,
                    Expired = DateTime.Now.AddDays(1),
                    IsPaid = false,
                    Class_Id = inputData.Class_Id
                };

                //Insert Ke Database TakenClass
                myContext.TakenClasses.Add(dataTakenClass);
                myContext.SaveChanges();

                //Sukses Register TakenClass
                return 1;
            }
            else
            {
                return 0;
            }
        }

        //Get TakenClassLengkap
        public List<TakenClassVM> GetTakenClassLengkap()
        {
            var data = myContext.TakenClasses
                .Join(myContext.Classes, t => t.Class_Id, c => c.Id, (t, c) => new { t, c })
                .Join(myContext.Levels, tc => tc.c.Level_Id, l => l.Id, (tc, l) => new { tc, l })
                .Join(myContext.Categories, tcl => tcl.tc.c.Category_Id, ct => ct.Id, (tcl, ct) => new { tcl, ct })
                .Select(dt => new TakenClassVM()
                {
                    Id = dt.tcl.tc.t.Id,
                    Email = dt.tcl.tc.t.Email,
                    ProgressChapter = dt.tcl.tc.t.ProgressChapter,
                    TotalChapter = dt.tcl.tc.c.TotalChapter,
                    IsDone = dt.tcl.tc.t.IsDone,
                    Class_Id = dt.tcl.tc.t.Class_Id,
                    ClassName = dt.tcl.tc.c.Name,
                    Desc = dt.tcl.tc.c.Desc,
                    Level = dt.tcl.l.Name,
                    Category = dt.ct.Name,
                    Price = dt.tcl.tc.c.Price,
                    Rating = dt.tcl.tc.c.Rating,
                    OrderId = dt.tcl.tc.t.OrderId,
                    Expired = dt.tcl.tc.t.Expired,
                    IsPaid = dt.tcl.tc.t.IsPaid
                }).ToList();
            return data;
        }

        //Get TakenClass By Email
        public List<TakenClassVM> GetTakenClassByEmail(string inputEmail)
        {
            var data = GetTakenClassLengkap().Where(d => (d.Email == inputEmail) && (d.IsPaid == true)).ToList();
            return data;
        }

        //Get Taken Class By Email and IsDone
        public List<TakenClassVM> GetTakenClassByIsDone(TakenClassIsDoneVM inputData)
        {
            var data = GetTakenClassByEmail(inputData.Email).Where(d => d.IsDone == Convert.ToBoolean(inputData.IsDone) && (d.IsPaid == true)).ToList();
            return data;
        }

        //Get Taken Class By Class_Id
        public List<TakenClassVM> GetTakenClassByClassId(int id)
        {
            var data = GetTakenClassLengkap().Where(x => x.Class_Id == id).ToList();
            return data;
        }

        //Get Taken Class By Email and Class_Id
        public TakenClassVM GetTakenClassByEmailClassId(string inputEmail, int inputId)
        {
            var data = GetTakenClassLengkap().FirstOrDefault(x => x.Class_Id == inputId && x.Email == inputEmail);
            return data;
        }

        //Next Chapter
        public int NextChapter(RegisterTakenClassVM inputData)
        {
            //Ambil data TakenClass By Email dan ClassId
            var dataTakenClass = GetTakenClassByEmail(inputData.Email).Where(x => x.Class_Id == inputData.Class_Id).FirstOrDefault();
            //var dataClass = myContext.Classes.FirstOrDefault(x => x.Id == dataTakenClass.Class_Id);
            var dataTC = myContext.TakenClasses.SingleOrDefault(x => x.Id == dataTakenClass.Id);

            //Cek Apakah ProgressChapter < TotalChapter
            if (dataTakenClass.ProgressChapter < dataTakenClass.TotalChapter) 
            {
                //Siapkan Object Untuk Menampung Data Update TakenClass
                TakenClass updateTakenClass = new TakenClass()
                {
                    Id = dataTakenClass.Id,
                    Email = inputData.Email,
                    ProgressChapter = dataTakenClass.ProgressChapter + 1,
                    IsDone = false,
                    OrderId = dataTakenClass.OrderId,
                    Expired = dataTakenClass.Expired,
                    IsPaid = dataTakenClass.IsPaid,
                    Class_Id = dataTakenClass.Class_Id
                };

                //Proses Update 
                myContext.Entry(dataTC).CurrentValues.SetValues(updateTakenClass);
                myContext.SaveChanges();

                // Sukses Chapter Bertambah
                return 1;
            }
            else
            {
                //Siapkan Object Untuk Update Data TakenClass
                TakenClass updateTakenClass = new TakenClass()
                {
                    Id = dataTakenClass.Id,
                    Email = inputData.Email,
                    ProgressChapter = dataTakenClass.ProgressChapter,
                    IsDone = true,
                    OrderId = dataTakenClass.OrderId,
                    Expired = dataTakenClass.Expired,
                    IsPaid = dataTakenClass.IsPaid,
                    Class_Id = dataTakenClass.Class_Id,
                };

                //Proses Update 
                myContext.Entry(dataTC).CurrentValues.SetValues(updateTakenClass);
                myContext.SaveChanges();

                // Chapter Terselesaikan semua
                return -1;
            }
        }

        // Get Taken Class By email Yang Belum Bayar
        //Mendapatkan Daftar TakenClass Berdasarkan Usernya siapa dan Belum Bayar
        public List<TakenClassVM> GetTakenClassByIsPaidFalse(TakenClassVM inputData)
        {
            //Ambil Data
            var data = GetTakenClassLengkap().Where(d => (d.Email == inputData.Email) && (d.IsPaid == false)).ToList();
            return data;
        }

        //Get Taken Class By Order_Id
        //Mendapatkan Data TakenClass Berdasarkan Order_Id TakenClass -> hasil 1 data saja
        public TakenClassVM GetTakenClassByOrderId(TakenClassVM inputData)
        {
            //Ambil Data
            var data = GetTakenClassLengkap().FirstOrDefault(d => d.OrderId == inputData.OrderId);
            return data;
        }
    }
}
