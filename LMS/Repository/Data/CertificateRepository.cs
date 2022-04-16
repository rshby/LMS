using LMS.Models;
using LMS.ViewModels;
using LMS.Context;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LMS.Repository.Data
{
    public class CertificateRepository : GeneralRepository<MyContext, Certificate, int>
    {
        private readonly MyContext myContext;

        //Constructor
        public CertificateRepository(MyContext myContext) : base(myContext)
        {
            this.myContext = myContext;
        }

        //Cek Class_Id apakah ada di database
        public bool CekClass(int inputClassId)
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

        //Ambil semua data certificate lengkap, nanti bisa filter sesuai kebutuhan
        public List<CertificateVM> AllCerfiticate()
        {
            //Join Kan Data
            var data = myContext.Users
                .Join(myContext.TakenClasses, u => u.Email, t => t.Email, (u, t) => new { u, t })
                .Join(myContext.Classes, ut => ut.t.Class_Id, c => c.Id, (ut, c) => new { ut, c })
                .Join(myContext.Certificates, utc => utc.ut.t.Id, cr => cr.TakenClass_Id, (utc, cr) => new { utc, cr })
                .Select(x => new CertificateVM(){
                    Certificate_Id = x.cr.Id,
                    Certificate_Code = x.cr.Code,
                    TakenClass_Id = x.utc.ut.t.Id,
                    User_Email = x.utc.ut.u.Email,
                    User_FullName = $"{x.utc.ut.u.FirstName} {x.utc.ut.u.LastName}",
                    User_Gender = x.utc.ut.u.Gender.ToString(),
                    Class_Id = x.utc.c.Id,
                    Class_Name = x.utc.c.Name,
                    Class_Desc = x.utc.c.Desc
                }).ToList();

            return data;
        }

        //Get Certificate Berdasarkan Email dan Class_Id yang kita inputkan
        public CertificateVM GetCertificateByEmailClassId(TakenClassVM inputData)
        {
            //Filter Data berdasarkan Email dan Class_Id
            var data = AllCerfiticate().SingleOrDefault(x => x.User_Email == inputData.Email && x.Class_Id == inputData.Class_Id);
            return data;
        }

        //Get Certificate berdasarkan code_Certificate
        public CertificateVM GetCertificatebyCode(string certifCode)
        {
            //ambil datanya
            var data = AllCerfiticate().SingleOrDefault(x => x.Certificate_Code == certifCode);
            return data;
        }
    }
}