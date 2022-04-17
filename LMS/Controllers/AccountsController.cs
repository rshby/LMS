using LMS.Base;
using LMS.Models;
using LMS.Repository.Data;
using LMS.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace LMS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountsController : BaseController<Account, AccountRepository, string>
    {
        private readonly AccountRepository accountRepo;
        public IConfiguration configuration;

        //Costructor
        public AccountsController(AccountRepository accountRepo, IConfiguration configuration) : base(accountRepo)
        {
            this.accountRepo = accountRepo;
            this.configuration = configuration;
        }

        //Mendaftar Akun
        [HttpPost("register")]
        public ActionResult Register(RegisterVM inputData)
        {
            try
            {
                //cek inputData tidak kosong
                if (inputData != null)
                {
                    //Cek Email Apakah sudah pernah didaftarkan di database
                    if (accountRepo.CekEmail(inputData.Email) == 0)
                    {
                        var hasilRegister = accountRepo.Register(inputData);
                        if (hasilRegister == 1)
                        {
                            return Ok(new
                            {
                                status = 200,
                                message = "Sukses Register Berhasil"
                            });
                        }
                        else
                        {
                            return Ok(new
                            {
                                status = 400,
                                message = "maaf, nomor telepon sudah ada"
                            });
                        }
                    }
                    else
                    {
                        return Ok(new
                        {
                            status = 400,
                            message = "email yang digunakan sudah pernah mendaftar"
                        });
                    }
                }
                else
                {
                    return Ok(new
                    {
                        status = 400,
                        message = "data register tidak terisi"
                    });
                }
            }
            catch (Exception e)
            {

                return Ok(new
                {
                    status = 500,
                    message = "gagal insert",
                    error = e.Message
                });
            }
        }

        //Login
        [HttpPost("login")]
        public ActionResult Login(LoginVM inputData)
        {
            try
            {
                //Cek Apakah Email Ada di Database
                if (accountRepo.CekEmail(inputData.Email) == 1)
                {
                    var hasilLogin = accountRepo.Login(inputData);
                    if (hasilLogin == 1)
                    {
                        var roleName = accountRepo.GetRoleName(inputData.Email);

                        var claims = new List<Claim>
                        {
                            new Claim("Email", inputData.Email),
                            new Claim("roles", roleName)
                        };

                        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:Key"]));
                        var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
                        var token = new JwtSecurityToken(
                            configuration["Jwt:Issuer"],
                            configuration["Jwt:Audience"],
                            claims,
                            expires: DateTime.UtcNow.AddMinutes(10),
                            signingCredentials: signIn
                            );

                        var idToken = new JwtSecurityTokenHandler().WriteToken(token);

                        claims.Add(new Claim("TokenSecurity", idToken.ToString()));

                        return Ok(new
                        {
                            status = 200,
                            message = "login berhasil",
                            token = idToken
                        });
                    }
                    else
                    {
                        return Ok(new
                        {
                            status = 400,
                            message = "password anda salah"
                        });
                    }
                }
                else
                {
                    return Ok(new
                    {
                        status = 404,
                        message = "data email tidak ditemukan di database"
                    });
                }
            }
            catch (Exception e)
            {

                return Ok(new
                {
                    status = 500,
                    message = "gagal login",
                    error = e.Message
                });
            }
        }

        //Forgot Password
        [HttpPost("forgotpassword")]
        public ActionResult ForgotPassword(LoginVM inputData)
        {
            try
            {
                //Cek Apakah Data Dengan Email Tersebut Ada di Database
                if (accountRepo.CekEmail(inputData.Email) == 1)
                {
                    //Lakukan Update ForgotPassword (panggil dari accountRepo)
                    var hasilForgotPassword = accountRepo.ForgotPassword(inputData.Email);

                    if (hasilForgotPassword == 1)
                    {
                        return Ok(new
                        {
                            status = 200,
                            message = "berhasil, silahkan cek email"
                        });
                    }
                    else
                    {
                        return Ok(new
                        {
                            status = 400,
                            message = "gagal kirim otp ke email"
                        });
                    }
                }
                else
                {
                    return Ok(new
                    {
                        status = 404,
                        message = $"data dengan email {inputData.Email} tidak ada di database"
                    });
                }
            }
            catch (Exception e)
            {

                return Ok(new
                {
                    status = 400,
                    message = "gagal kirim kode otp",
                    error = e.Message
                });
            }
        }

        //Change Password
        [HttpPost("changepassword")]
        public ActionResult ChangePassword(ChangePasswordVM inputData)
        {
            try
            {
                //Cek Data dengan Email Apakah Ada di Database
                if (accountRepo.CekEmail(inputData.Email) == 1)
                {
                    //Hasil Change Password (panggil method dari Repo)
                    var hasilChangePassword = accountRepo.ChangePassword(inputData);
                    if (hasilChangePassword == 1)
                    {
                        //Sukses
                        return Ok(new
                        {
                            status = 200,
                            message = "sukses mengganti password"
                        });
                    }
                    else if (hasilChangePassword == -1)
                    {
                        //Password dan ConfirmPassword Tidak Sama
                        return Ok(new
                        {
                            status = 400,
                            message = "Password dan ConfirmPassword Tidak Sama"
                        });
                    }
                    else if (hasilChangePassword == -2)
                    {
                        //Kode OTP Tidak Sesuai
                        return Ok(new
                        {
                            status = 400,
                            message = "kode OTP tidak sesuai"
                        });
                    }
                    else
                    {
                        //Waktu Habis
                        return Ok(new
                        {
                            status = 400,
                            message = "Kode OTP sudah tidak berlaku"
                        });
                    }
                }
                else
                {
                    return Ok(new
                    {
                        status = 404,
                        message = $"data dengan email {inputData.Email} tidak ditemukan"
                    });
                }
            }
            catch (Exception e)
            {

                return Ok(new
                {
                    status = 500,
                    message = "gagal change password",
                    error = e.Message
                });
            }
        }
    }
}