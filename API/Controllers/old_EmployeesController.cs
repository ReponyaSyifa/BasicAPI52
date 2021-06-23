using API.Models;
using API.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class old_EmployeesController : ControllerBase
    {
        private old_EmployeeRepository employeeRepository;
        public old_EmployeesController(old_EmployeeRepository employeeRepository)
        {
            this.employeeRepository = employeeRepository;
        }

        [HttpGet("{nik}")] // Get By Id
        public ActionResult GetById(string nik)
        {
            var cari = employeeRepository.GetById(nik);
            if (cari == null)
            {
                return BadRequest(new { status = HttpStatusCode.BadRequest, result = "null", message = "Data Tidak Ada!" });
            }
            else
            {
                return Ok(new { status = HttpStatusCode.OK, result = cari, message = "Data Berhasil Ditemukan" });
            }
        }

        //tambahan: - return dibuat objek, - ada status code, result, dan message -done
                  //- yang GetAll dan GetById dipisah -done
                  //- entitystatemodified -done

        [HttpGet]
        public ActionResult Get()
        {
            var cari = employeeRepository.Get();
            if (true)
            {
                var result = new { status = HttpStatusCode.OK, result = cari, message = "Data Berhasil di get" };
                return Ok(result);
            }
            else
            {
            }            
        }
        
        [HttpPost]
        public ActionResult Post(Employees employee)
        {
            var insert = employeeRepository.Insert(employee);
            if (insert == 1)
            {
                return Ok(new { status = HttpStatusCode.OK, result = insert, message = "Insert Sukses!" });
            }
            else 
            {
                return BadRequest(new { status = HttpStatusCode.BadRequest, result = "null", message = "Insert Gagal!" });
            }            
        }
        
        [HttpDelete]
        public ActionResult Delete(string nik)
        {
            var cari = employeeRepository.Get(nik);
            var delete = employeeRepository.Delete(nik);
            if (cari == null)
            {
                return BadRequest(new { status = HttpStatusCode.BadRequest, result = delete, message = "Delete Gagal!" });
            }
            else
            {
                return Ok(new { status = HttpStatusCode.OK, result = delete, message = "Delete Berhasil!" });
            }
        }

        [HttpPut]
        public ActionResult Update(Employees employees, string nik)
        {
            var cari = employeeRepository.Update(employees, nik);
            if (nik == null)
            {
                return BadRequest(new { status = HttpStatusCode.BadRequest, result = nik, message = "Primary Key tidak ada" });
            }
            else
            {
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
}

