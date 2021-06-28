using API.Base;
using API.Models;
using API.Repository.Data;
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

    public class AccountRoleController : BaseController<AccountRole, AccountRoleRepository, string>
    {
        private readonly AccountRoleRepository accountRoleRepository;
        public AccountRoleController(AccountRoleRepository accountRoleRepository) : base(accountRoleRepository)
        {
            this.accountRoleRepository = accountRoleRepository;
        }

        [HttpPost("/API/AccountRole/SetRole")]
        public ActionResult SetRole(AccountRole accRoles)
        {
            int setRole = accountRoleRepository.SetRole(accRoles);
            switch (setRole)
            {
                case 1:
                    return Ok(new { status = HttpStatusCode.OK, result = setRole, message = "Berhasil! Role Anda: Admin" });
                case 2:
                    return Ok(new { status = HttpStatusCode.OK, result = setRole, message = "Berhasil! Role Anda: Repository" });
                default:
                    return BadRequest();
            }
        }

        [HttpGet("/API/AccountRole/GetRole")]
        public ActionResult GetRole()
        {
            var getAll = accountRoleRepository.Get();
            return Ok(new { status = HttpStatusCode.OK, result = getAll, message = "Data Berhasil di get" });
        }
    }
}
