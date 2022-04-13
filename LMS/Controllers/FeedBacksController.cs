using LMS.Base;
using LMS.Models;
using LMS.Repository.Data;
using LMS.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;

namespace LMS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FeedBacksController : BaseController<FeedBack, FeedBackRepository, float>
    {
        private readonly FeedBackRepository feedBackRepo;
        private readonly IConfiguration configuration;

        //Constructor
        public FeedBacksController(FeedBackRepository feedBackRepo, IConfiguration configuration) : base(feedBackRepo)
        {
            this.configuration = configuration;
            this.feedBackRepo = feedBackRepo;
        }

        //Add FeedBack -> menambahkan data feedback
        [HttpPost("add")]
        public ActionResult AddFeedBack(InsertFeedBackVM inputData)
        {
            try
            {
                //Cek Email dan Kelas apakah ada di database
                if (feedBackRepo.CekEmail(inputData.Email) && feedBackRepo.CekClass(inputData.Class_Id))
                {
                    var addFeedback = feedBackRepo.AddFeedBack(inputData);

                    //Cek apabila sukses menambahkan feedback
                    if (addFeedback == 1)
                    {
                        return Ok(new
                        {
                            status = 200,
                            message = "sukses menambahkan feedback"
                        });
                    }
                    else
                    {
                        return BadRequest(new
                        {
                            status = 400,
                            message = "Data feedback pada kelas ini sudah pernah diinput"
                        });
                    }
                }
                else
                {
                    return NotFound(new
                    {
                        status = 404,
                        message = "data email dan kelas yang dimaksud tidak ada di database"
                    });
                }
            }
            catch (Exception e)
            {

                return BadRequest(new
                {
                    message = "gagal menambahkan feedback",
                    error = e.Message
                });
            }
        }

        //Get Feedback berdasarkan parameter Email dan Class_Id -> hasil 1 data aja
        [HttpPost("byemailclassid")]
        public ActionResult GetFeedBackByEmailClassId(TakenClassVM inputData)
        {
            try
            {
                //Cek Email dan Class_Id apakah ada di database
                if (feedBackRepo.CekEmail(inputData.Email) && feedBackRepo.CekClass(inputData.Class_Id))
                {
                    var data = feedBackRepo.GetFeedBackByEmailClassId(inputData);
                    if (data != null)
                    {
                        return Ok(new
                        {
                            status = 200,
                            message = "data ditemukan",
                            data = data
                        });
                    }
                    else
                    {
                        return Ok(new
                        {
                            status = 404,
                            message = "data tidak ditemukan"
                        });
                    }
                }
                else
                {
                    return NotFound(new
                    {
                        status = 404,
                        message = "data Email dan Class_Id tidak ada di database"
                    });
                }
            }
            catch (Exception e)
            {

                return BadRequest(new
                {
                    message = "gagal get data",
                    error = e.Message
                });
            }
        }
    }
}