using LMS.Base;
using LMS.Models;
using LMS.Repository.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;

namespace LMS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SectionsController : BaseController<Section, SectionRepository, int>
    {
        private readonly SectionRepository repository;
        public IConfiguration configuration;

        //Constructor
        public SectionsController(SectionRepository repository, IConfiguration configuration) : base(repository)
        {
            this.repository = repository;
            this.configuration = configuration;
        }

        // Menampilkan Section Berdasarkan Class_Id yang diinputkan
        [HttpGet("byclassid/{inputClassId}")]
        public ActionResult GetSectionByClassId(int inputClassId)
        {
            try
            {
                //Cek Data inputClassId, apakah ada di tabel class dengan id tersebut
                if (repository.CekClassId(inputClassId))
                {
                    var data = repository.SectionByClassId(inputClassId);
                    if (data.Count != 0)
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
                        return NotFound(new
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
                        message = $"data class dengan id {inputClassId} tidak ada di database"
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
