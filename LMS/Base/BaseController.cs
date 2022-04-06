using LMS.Repository.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;

namespace LMS.Base
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseController<Entity, Repository, Key> : ControllerBase
        where Entity : class
        where Repository : IRepository<Entity, Key>
    {
        private readonly Repository repository;

        public BaseController(Repository repository)
        {
            this.repository = repository;
        }

        [HttpGet]
        public ActionResult<Entity> Get()
        {
            var result = repository.GET();
            return Ok(new { 
                status = 200,
                message = "data ditemukan",
                data = result
            });
        }

        [HttpGet("{Key}")]
        public ActionResult<Entity> Get(Key key)
        {
            try
            {
                var result = repository.Get(key);
                return Ok(result);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                "Error deleting data");
            }

        }

        [HttpPost]
        public ActionResult<Entity> Insert(Entity entities)
        {
            try
            {
                var insert = repository.Insert(entities);
                if (insert == 0)
                {
                    return BadRequest("Gagal Input");
                }
                else
                {
                    return Ok("Berhasil Input");
                }
            }
            catch
            {
                return BadRequest("Eror Data Input");
            }
        }

        [HttpDelete("{Key}")]
        public ActionResult<Entity> Delete(Key key)
        {
            var result = repository.Delete(key);
            return Ok("Berhasil terhapus");
        }

        [HttpPut]
        public ActionResult<Entity> Update(Entity entities)
        {
            var result = repository.Update(entities);
            return Ok("Berhasil di update");
        }

    }
}
