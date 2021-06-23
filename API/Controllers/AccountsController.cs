using API.Base;
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
    public class AccountsController : BaseController<Accounts, AccountsRepository, string>
    {
        private readonly AccountsRepository accountsRepository;
        public AccountsController(AccountsRepository accountsRepository) : base(accountsRepository)
        {
            this.accountsRepository = accountsRepository;
        }

        [HttpPost("/API/Accounts/Login")]
        public ActionResult Login(LoginVm loginVm)
        {
            int login = accountsRepository.Login(loginVm);
            switch (login)
            {
                case 1:
                    return Ok(new { status = HttpStatusCode.OK, result = login, message = "Login Berhasil" });
                case 2:
                    return BadRequest(new { status = HttpStatusCode.BadRequest, result = login, message = "Gagal Login" });
                default:
                    return BadRequest();
            }
        }

        [HttpPost("/API/Accounts/ResetPassword")]
        public ActionResult ResetPassword(LoginVm loginVm)
        {
            int reset = accountsRepository.ResetPassword(loginVm);
            switch (reset)
            {
                case 1:
                    return BadRequest(new { status = HttpStatusCode.BadRequest, result = reset, message = "Reset Password Gagal"});
                case 2:
                    return Ok(new { status = HttpStatusCode.OK, result = reset, message = "Reset Password Berhasil! Sila Cek Email Anda" });
                default:
                    return BadRequest();
            }            
        }

        [HttpPost("/API/Accounts/ChangePassword")]
        public ActionResult ChangePassword(ChangePasswordVm chgPasswordVm)
        {
            int reset = accountsRepository.ChangePassword(chgPasswordVm);
            switch (reset)
            {
                case 1:
                case 2:
                    return BadRequest(new { status = HttpStatusCode.BadRequest, result = reset, message = "Ganti Password Gagal!" });
                case 3:
                    return Ok(new { status = HttpStatusCode.OK, result = reset, message = "Ganti Password Berhasil" });
                default:
                    return BadRequest();
            }
        }
    }
}
