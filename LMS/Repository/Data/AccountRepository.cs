using LMS.Context;
using LMS.Models;
using LMS.ViewModels;
using System.Collections.Generic;
using System.Linq;

namespace LMS.Repository.Data
{
    public class AccountRepository : GeneralRepository<MyContext,Account, string>
    {
        private readonly MyContext myContext;
        public IEnumerable<object> Account { get; set; }

        //Constructor
        public AccountRepository(MyContext myContext) : base(myContext)
        {
            this.myContext = myContext;
        }

        //Generate Salt
        public static string GetRandomSalt()
        {
            return BCrypt.Net.BCrypt.GenerateSalt(12);
        }

        // Hasing Password
        public string HashingPassword(string inputPassword)
        {
            return BCrypt.Net.BCrypt.HashPassword(inputPassword, GetRandomSalt());
        }

        // Validate Password
        public bool ValidatePassword(string inputPassword, string passwordBenar)
        {
            return BCrypt.Net.BCrypt.Verify(inputPassword, passwordBenar);
        }

        //Insert Register Account
        public int Register(RegisterVM inputData)
        {
            //Cek Phone Harus Beda
            var cekPhone = myContext.Users.SingleOrDefault(u => u.Phone == inputData.Phone);

            if (cekPhone == null)
            {
                //save data ke tabel Address
                Address address = new Address()
                {
                    Street = inputData.Street,
                    Subdistrict_Id = inputData.Subdistrict_Id
                };
                myContext.Addresses.Add(address);
                myContext.SaveChanges();

                //save data ke tabel Education
                Education education = new Education()
                {
                    Major = inputData.Major,
                    University_Id = inputData.University_Id
                };
                myContext.Educations.Add(education);
                myContext.SaveChanges();

                //save data ke tabel User
                User user = new User()
                {
                    Email = inputData.Email,
                    FirstName = inputData.FirstName,
                    LastName = inputData.LastName,
                    Gender = inputData.Gender,
                    Phone = inputData.Phone,
                    BirthDate = inputData.BirthDate,
                    Education_Id = education.Id,
                    Address_Id = address.Id
                };
                myContext.Users.Add(user);
                myContext.SaveChanges();

                //save data ke tabel Account
                Account account = new Account()
                {
                    Email = user.Email,
                    Password = inputData.Password,
                    Role_Id = 1
                };
                myContext.Accounts.Add(account);
                myContext.SaveChanges();

                return 1;
            }
            else
            {
                return 0;
            }
        }
    }
}
