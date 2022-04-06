using LMS.Context;
using LMS.Models;
using LMS.ViewModels;
using MailKit.Net.Smtp;
using Microsoft.EntityFrameworkCore;
using MimeKit;
using System;
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
                    Password = HashingPassword(inputData.Password),
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

        //Login
        public int Login(LoginVM inputData)
        {
            //Ambil Data Email dan Password
            var data = myContext.Accounts.SingleOrDefault(a => a.Email == inputData.Email);
            if (data.Email == inputData.Email && ValidatePassword(inputData.Password, data.Password))
            {
                return 1; //Password benar
            }
            else
            {
                return 0; //Password Salah
            }
        }

        // Forgot Password kirim ke email
        public int ForgotPassword(string inputEmail)
        {
            //data (Email dan Password) dari inputEmail
            var data = myContext.Accounts.SingleOrDefault(a => a.Email == inputEmail);

            //Siapkan Objek Untuk Update Ke Database Account
            var dataUpdate = new Account()
            {
                Email = data.Email.ToString(),
                Password = "123",
                OTP = new Random().Next(111111, 999999),
                ExpiredToken = DateTime.Now.AddMinutes(5),
                IsUsed = false,
                Role_Id = data.Role_Id
            };

            //Update ke database
            myContext.Entry(data).CurrentValues.SetValues(dataUpdate);
            myContext.SaveChanges();
            
            // Kirim Kode OTP Ke Email
            var email = new MimeMessage();
            email.From.Add(new MailboxAddress("LMS System", "rshby99@gmail.com"));
            email.To.Add(MailboxAddress.Parse(inputEmail));
            email.Subject = "Kode OTP LMS";
            email.Body = new TextPart("Plain") { Text = $"Kode OTP : {dataUpdate.OTP}" };
            
            SmtpClient smtp = new SmtpClient();
            smtp.Connect("smtp.gmail.com", 465, true);
            smtp.Authenticate("rshby99@gmail.com", "reo050299");
            smtp.Send(email);
            smtp.Disconnect(true);
            smtp.Dispose();
            
            return 1; // Cek Email   
        }

        //Change Password
        public int ChangePassword(ChangePasswordVM inputData)
        {
            //ambil data sesuai dengan Email yang dimasukkan
            var data = myContext.Accounts.SingleOrDefault(a => a.Email == inputData.Email);

            //Cek Password dan Confirm Password
            if (inputData.Password == inputData.ConfirmPassword)
            {
                //Cek OTP harus sesuai dengan yang diinput
                if (inputData.OTP == data.OTP)
                {
                    //Cek Waktu
                    if (DateTime.Now <= data.ExpiredToken)
                    {
                        //Siapkan Object Untuk Update Database Account
                        var dataUpdate = new Account()
                        {
                            Email = inputData.Email,
                            Password = HashingPassword(inputData.Password),
                            IsUsed = true,
                            Role_Id = data.Role_Id,
                            OTP = 0
                        };

                        //Update ke Database Account
                        myContext.Entry(data).CurrentValues.SetValues(dataUpdate);
                        myContext.SaveChanges();

                        //Sukses
                        return 1;
                    }
                    else
                    {
                        return -3; //waktu sudah habis
                    }
                }
                else
                {
                    return -2; //OTP Tidak sesuai
                }
            }
            else
            {
                return -1; // Confirm Password Tidak Sama
            }
        }
    }
}
