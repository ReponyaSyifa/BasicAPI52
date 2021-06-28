using API.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc.NewtonsoftJson;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;

namespace API.Base
{
    [Route("api/[controller]")]
    //[EnableCors("AllowOrigin")]
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
        public ActionResult Get()
        {
            var cari = repository.Get();
            var result = new { status = HttpStatusCode.OK, result = cari, message = "Data Berhasil di get" };
            return Ok(result);
        }

        [HttpGet("{key}")] // Get By Id
        public ActionResult GetById(Key key)
        {
            var cari = repository.Get(key);
            if (cari == null)
            {
                return BadRequest(new { status = HttpStatusCode.BadRequest, result = "null", message = "Data Tidak Ada!" });
            }
            else
            {
                return Ok(new { status = HttpStatusCode.OK, result = cari, message = "Data Berhasil Ditemukan" });
            }
        }

        [HttpPost]
        public ActionResult Post(Entity e)
        {
            var post = repository.Insert(e);
            if (post == 1)
            {
                return Ok(new { status = HttpStatusCode.OK, result = post, message = "Insert Sukses!" });
            }
            else
            {
                return BadRequest(new { status = HttpStatusCode.BadRequest, result = "null", message = "Insert Gagal!" });
            }
        }

        [HttpDelete("{key}")]
        public ActionResult Delete(Key key)
        {
            var cari = repository.Get(key);
            var delete = repository.Delete(key);
            if (cari == null)
            {
                return BadRequest(new { status = HttpStatusCode.BadRequest, result = delete, message = "Delete Gagal!" });
            }
            else
            {
                return Ok(new { status = HttpStatusCode.OK, result = delete, message = "Delete Berhasil!" });
            }
        }

        [HttpPut("{key}")]
        public ActionResult Update(Entity e, Key key)
        {
            var cari = repository.Update(e, key);
            if (cari == 1)
            {
                return Ok(new { status = HttpStatusCode.OK, result = cari, message = "Data Berhasil Update" });
            }
            else
            {
                return BadRequest(new { status = HttpStatusCode.BadRequest, result = cari, message = "Data Gagal Update" });
            }
        }

    }
}
