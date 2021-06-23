using API.Base;
using API.Contexts;
using API.Models;
using API.Repository.Data;
using API.ViewModel;
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
    public class EmployeesController : BaseController<Employees, EmployeeRepository, string>
    {
        private readonly EmployeeRepository employeeRepository;
        public EmployeesController(EmployeeRepository employeeRepository) : base(employeeRepository)
        {
            this.employeeRepository = employeeRepository;
        }

        [HttpPost("/API/Employees/Register")]
        public ActionResult Register(RegisterVm registerVm)
        {
            int post = employeeRepository.Register(registerVm);
            switch (post)
            {
                case 1:
                    return BadRequest(new { status = HttpStatusCode.BadRequest, result = post, message = "NIK sudah terdaftar" });
                case 2:
                    return BadRequest(new { status = HttpStatusCode.BadRequest, result = post, message = "Email sudah terdaftar" });
                case 3:
                    return BadRequest(new { status = HttpStatusCode.BadRequest, result = post, message = "NIK dan Email sudah terdaftar" });
                case 4:
                    return Ok(new { status = HttpStatusCode.OK, result = post, message = "Registrasi Berhasil" });
                default:
                    return BadRequest(new { status = HttpStatusCode.BadRequest, result = post, message = "Registrasi Gagal" });
            }
        }
    }
}
