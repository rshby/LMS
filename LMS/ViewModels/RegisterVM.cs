using LMS.Models;
using System;

namespace LMS.ViewModels
{
    public class RegisterVM
    {
        //masuk ke tabel user
        public string Email { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Gender Gender { get; set; }
        public string Phone { get; set; }
        public DateTime BirthDate { get; set; }

        //masuk ke tabel address
        public string Street { get; set; }
        public int Subdistrict_Id { get; set; }

        //masuk ke tabel university
        public string Major { get; set; }
        public int University_Id { get; set; }
    }
}
