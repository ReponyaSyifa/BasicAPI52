using API.Base;
using API.Contexts;
using API.Models;
using API.Repository.Data;
using API.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
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
    //[EnableCors("AllowOrigin")]
    public class EmployeesController : BaseController<Employees, EmployeeRepository, string>
    {
        private readonly EmployeeRepository employeeRepository;
        public EmployeesController(EmployeeRepository employeeRepository) : base(employeeRepository)
        {
            this.employeeRepository = employeeRepository;
        }

        [HttpPost("/API/Employees/Register")]
        //[EnableCors("AllowOrigin")]
        public ActionResult Register(RegisterVm registerVm)
        {
            int post = employeeRepository.Register(registerVm);
            switch (post)
            {
                case 1:
                    return BadRequest(new { status = HttpStatusCode.BadRequest, result = post, message = "NIK sudah terdaftar" }); //cekNIK != null && cekEmail == null
                case 2:
                    return BadRequest(new { status = HttpStatusCode.BadRequest, result = post, message = "Email sudah terdaftar" }); //cekNIK == null && cekEmail != null
                case 3:
                    return BadRequest(new { status = HttpStatusCode.BadRequest, result = post, message = "NIK dan Email sudah terdaftar" }); //cekNIK != null && cekEmail != null
                case 4:
                    return Ok(new { status = HttpStatusCode.OK, result = post, message = "Registrasi Berhasil" }); //cekNIK == null && cekEmail == null
                default:
                    return BadRequest(new { status = HttpStatusCode.BadRequest, result = post, message = "Registrasi Gagal" });
            }
        }

        [Authorize]
        [HttpGet("/API/Employees/GetAllRegister")]
        //[EnableCors("AllowOrigin")]
        public ActionResult GetAllRegister()
        {
            var get = employeeRepository.GetAllRegister();
            return Ok(new { status = HttpStatusCode.OK, result = get, message = "Data Berhasil di get" });
            //return Ok(User.FindFirst("Role"));
        }

        [Authorize] //setiap operasi butuh token otorisasi, kalo semisal daletakkan di atas controller
        [HttpGet("/API/Employees/GetOneList/{nik}")]
        //[EnableCors("AllowOrigin")]
        public ActionResult GetOneList(string nik)
        {
            var get = employeeRepository.GetOneList(nik);
            if (get != null)
            {
                //return Ok(new { status = HttpStatusCode.OK, result = get, message = "Data Berhasil di get" });
                return Ok(get);
            }
            else
            {
                return null;
            }

        }

    }

    
}
