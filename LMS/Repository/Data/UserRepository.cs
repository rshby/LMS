using LMS.Context;
using LMS.Models;
using LMS.ViewModels;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace LMS.Repository.Data
{
    public class UserRepository : GeneralRepository<MyContext, User, string>
    {
        private readonly MyContext myContext;
        public IEnumerable<User> User { get; set; }

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
                .Join(myContext.Addresses, u => u.Address_Id, a => a.Id, (u, a) => new { u, a })
                .Join(myContext.SubDistricts, ua => ua.a.Subdistrict_Id, sd => sd.Id, (ua, sd) => new { ua, sd })
                .Join(myContext.Districts, uasd => uasd.sd.District_Id, d => d.Id, (uasd, d) => new { uasd, d })
                .Join(myContext.Cities, uasdd => uasdd.d.City_Id, c => c.Id, (uasdd, c) => new { uasdd, c })
                .Join(myContext.Provinces, uasddc => uasddc.c.Province_Id, p => p.Id, (uasddc, p) => new { uasddc, p })
                .Join(myContext.Educations, uasddcp => uasddcp.uasddc.uasdd.uasd.ua.u.Education_Id, e => e.Id, (uasddcp, e) => new { uasddcp, e })
                .Join(myContext.Universities, uasddcpe => uasddcpe.e.University_Id, univ => univ.Id, (uasddcpe, univ) => new { uasddcpe, univ })
                .Select(data => new
                {
                    Email = data.uasddcpe.uasddcp.uasddc.uasdd.uasd.ua.u.Email,
                    FirstName = data.uasddcpe.uasddcp.uasddc.uasdd.uasd.ua.u.FirstName,
                    LastName = data.uasddcpe.uasddcp.uasddc.uasdd.uasd.ua.u.LastName,
                    FullName = $"{data.uasddcpe.uasddcp.uasddc.uasdd.uasd.ua.u.FirstName} {data.uasddcpe.uasddcp.uasddc.uasdd.uasd.ua.u.LastName}",
                    Gender = data.uasddcpe.uasddcp.uasddc.uasdd.uasd.ua.u.Gender.ToString(),
                    Phone = data.uasddcpe.uasddcp.uasddc.uasdd.uasd.ua.u.Phone,
                    BirthDate = data.uasddcpe.uasddcp.uasddc.uasdd.uasd.ua.u.BirthDate.ToString("dd MMMM yyyy"),
                    Address = $"{data.uasddcpe.uasddcp.uasddc.uasdd.uasd.ua.a.Street}, Kelurahan {data.uasddcpe.uasddcp.uasddc.uasdd.uasd.sd.Name}, Kecamatan {data.uasddcpe.uasddcp.uasddc.uasdd.d.Name}, Kota {data.uasddcpe.uasddcp.uasddc.c.Name}, Provinsi {data.uasddcpe.uasddcp.p.Name}, Kode Pos {data.uasddcpe.uasddcp.uasddc.uasdd.uasd.sd.ZipCode}",
                    University = data.univ.Name,
                    Major = data.uasddcpe.e.Major
                });

            return data;
        }

        //Cek Email Apakah Ada di Database
        public int CekEmail(string inputEmail)
        {
            var cek = myContext.Users.SingleOrDefault(u => u.Email == inputEmail);
            if (cek != null)
            {
                return 1;
            }
            else
            { 
                return 0;
            }
        }

        //Get Master Data By Email
        public MasterUserVM GetMasterUserByEmail(string inputEmail)
        {
            var data = myContext.Users
                .Join(myContext.Addresses, u => u.Address_Id, a => a.Id, (u, a) => new { u, a })
                .Join(myContext.SubDistricts, ua => ua.a.Subdistrict_Id, sd => sd.Id, (ua, sd) => new { ua, sd })
                .Join(myContext.Districts, uasd => uasd.sd.District_Id, d => d.Id, (uasd, d) => new { uasd, d })
                .Join(myContext.Cities, uasdd => uasdd.d.City_Id, c => c.Id, (uasdd, c) => new { uasdd, c })
                .Join(myContext.Provinces, uasddc => uasddc.c.Province_Id, p => p.Id, (uasddc, p) => new { uasddc, p })
                .Join(myContext.Educations, uasddcp => uasddcp.uasddc.uasdd.uasd.ua.u.Education_Id, e => e.Id, (uasddcp, e) => new { uasddcp, e })
                .Join(myContext.Universities, uasddcpe => uasddcpe.e.University_Id, univ => univ.Id, (uasddcpe, univ) => new { uasddcpe, univ })
                .Select(data => new MasterUserVM()
                {
                    Email = data.uasddcpe.uasddcp.uasddc.uasdd.uasd.ua.u.Email,
                    FirstName = data.uasddcpe.uasddcp.uasddc.uasdd.uasd.ua.u.FirstName,
                    LastName = data.uasddcpe.uasddcp.uasddc.uasdd.uasd.ua.u.LastName,
                    FullName = $"{data.uasddcpe.uasddcp.uasddc.uasdd.uasd.ua.u.FirstName} {data.uasddcpe.uasddcp.uasddc.uasdd.uasd.ua.u.LastName}",
                    Gender = data.uasddcpe.uasddcp.uasddc.uasdd.uasd.ua.u.Gender.ToString(),
                    Phone = data.uasddcpe.uasddcp.uasddc.uasdd.uasd.ua.u.Phone,
                    BirthDate = data.uasddcpe.uasddcp.uasddc.uasdd.uasd.ua.u.BirthDate.ToString("dd MMMM yyyy"),
                    Address = $"{data.uasddcpe.uasddcp.uasddc.uasdd.uasd.ua.a.Street}, Kelurahan {data.uasddcpe.uasddcp.uasddc.uasdd.uasd.sd.Name}, Kecamatan {data.uasddcpe.uasddcp.uasddc.uasdd.d.Name}, Kota {data.uasddcpe.uasddcp.uasddc.c.Name}, Provinsi {data.uasddcpe.uasddcp.p.Name}, Kode Pos {data.uasddcpe.uasddcp.uasddc.uasdd.uasd.sd.ZipCode}",
                    University = data.univ.Name,
                    Major = data.uasddcpe.e.Major
                }).ToList().Find(x => x.Email == inputEmail);

            return data;
        }

        //Update Data User
        public int UpdateMasterUser(RegisterVM inputData)
        {
            //ambil data User
            var data = myContext.Users.SingleOrDefault(x => x.Email == inputData.Email);

            //Siapkan Object Untuk Update Tabel Address
            Address updateAddress = new Address()
            {
                Id = data.Address_Id,
                Street = inputData.Street,
                Subdistrict_Id = inputData.Subdistrict_Id
            };

            //Update Data Adress ke Database
            var dataAdress = myContext.Addresses.SingleOrDefault(x => x.Id == updateAddress.Id);
            myContext.Entry(dataAdress).CurrentValues.SetValues(updateAddress);
            myContext.SaveChanges();

            //Siapkan Object Untuk Update Data Education
            Education updateEducation = new Education()
            {
                Id = data.Education_Id,
                Major = inputData.Major,
                University_Id = inputData.University_Id
            };

            //Update Data Education ke Database
            var dataEducation = myContext.Educations.SingleOrDefault(x => x.Id == updateEducation.Id);
            myContext.Entry(dataEducation).CurrentValues.SetValues(updateEducation);
            myContext.SaveChanges();

            // Siapkan Object User untuk Update Data User
            User updateUser = new User()
            {
                Email = data.Email,
                FirstName = inputData.FirstName,
                LastName = inputData.LastName,
                Gender = inputData.Gender,
                Phone = inputData.Phone,
                BirthDate = inputData.BirthDate,
                Education_Id = data.Education_Id,
                Address_Id = data.Address_Id
            };

            //Update data User ke Database
            myContext.Entry(data).CurrentValues.SetValues(updateUser);
            myContext.SaveChanges();

            //Sukses Update Data Master User
            return 1;
        }

        public List<DaftarPembayaranVM> AllDaftarPembayaran()
        {
            var data = myContext.Users
                .Join(myContext.TakenClasses, u => u.Email, t => t.Email, (u, t) => new { u, t })
                .Join(myContext.Classes, ut => ut.t.Class_Id, c => c.Id, (ut, c) => new { ut, c })
                .Join(myContext.Levels, utc => utc.c.Level_Id, l => l.Id, (utc, l) => new { utc, l })
                .Join(myContext.Categories, utcl => utcl.utc.c.Category_Id, ct => ct.Id, (utcl, ct) => new { utcl, ct })
                .Select(data => new DaftarPembayaranVM()
                {
                    User_Email = data.utcl.utc.ut.u.Email,
                    User_FirstName = data.utcl.utc.ut.u.FirstName,
                    User_LastName = data.utcl.utc.ut.u.LastName,
                    User_FullName = $"{data.utcl.utc.ut.u.FirstName} {data.utcl.utc.ut.u.LastName}",
                    User_Gender = data.utcl.utc.ut.u.LastName.ToString(),
                    user_Phone = data.utcl.utc.ut.u.Phone,
                    TakenCLass_Id = data.utcl.utc.ut.t.Id,
                    TakenClass_ProgressChapter = data.utcl.utc.ut.t.ProgressChapter,
                    TakenClass_IsDone = data.utcl.utc.ut.t.IsDone,
                    TakenClass_OrderId = data.utcl.utc.ut.t.OrderId,
                    TakenClass_Expired = data.utcl.utc.ut.t.Expired.ToString("dddd, dd MMMM yyyy HH:mm:ss"),
                    TakenClass_IsPaid = data.utcl.utc.ut.t.IsPaid,
                    Class_Id = data.utcl.utc.c.Id,
                    Class_Name = data.utcl.utc.c.Name,
                    Class_Desc = data.utcl.utc.c.Desc,
                    Class_UrlPic = data.utcl.utc.c.UrlPic,
                    Class_Price = data.utcl.utc.c.Price,
                    Class_Rating = data.utcl.utc.c.Rating,
                    Class_TotalChapter = data.utcl.utc.c.TotalChapter,
                    Level_Name = data.utcl.l.Name,
                    Category_Name = data.ct.Name
                }).ToList();
            return data;
        }
    }
}
