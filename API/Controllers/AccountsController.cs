using API.Base;
using API.Contexts;
using API.Models;
using API.Repository;
using API.Repository.Data;
using API.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountsController : BaseController<Accounts, AccountsRepository, string>
    {
        private readonly AccountsRepository accountsRepository;

        public IConfiguration configuration;
        private readonly MyContexts myContexts;
        public AccountsController(AccountsRepository accountsRepository, IConfiguration konfigurasi, MyContexts myContext) : base(accountsRepository)
        {
            this.accountsRepository = accountsRepository;
            this.configuration = konfigurasi;
            this.myContexts = myContext;
        }


        /*[HttpPost("/API/Accounts/Login")] //login w/o jwt
        public ActionResult Login(LoginVm loginVm)
        {
            int login = accountsRepository.Login(loginVm);
            switch (login)
            {
                case 1:
                    return BadRequest(new { status = HttpStatusCode.BadRequest, result = login, message = "Gagal Login" });
                case 2:
                    return BadRequest(new { status = HttpStatusCode.BadRequest, result = login, message = "Gagal Login" });
                case 3:
                    return Ok(new { status = HttpStatusCode.OK, result = login, message = "Login Berhasil" });
                default:
                    return BadRequest();
            }
        }*/

        [HttpPost("/API/Accounts/Login")] //login jwt
        public ActionResult Login(LoginVm loginVm)
        {
            Employees employee = new Employees();
            Accounts acc = new Accounts();

            var findAccount = myContexts.Accounts.Find(loginVm.NIK);

            var cocokAkun = myContexts.Accounts.FirstOrDefault(c => c.NIK == loginVm.NIK);
            if (findAccount != null)
            {
                if (cocokAkun != null)
                {
                    if (HashingPassword.ValidatePassword(loginVm.Password, cocokAkun.Password))
                    {
                        var email = myContexts.Employees.Find(cocokAkun.NIK);
                        var nik = myContexts.AccountRoles.FirstOrDefault(n => n.AccountsId == cocokAkun.NIK);
                        var role = myContexts.Roles.FirstOrDefault(r => r.RoleId == nik.RolesId);
                        var claims = new[]
                        {
                            new Claim("email", email.Email),
                            new Claim("Role", role.RoleName),
                        };

                        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:Key"]));
                        var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
                        var token = new JwtSecurityToken(configuration["Jwt:Issuer"], role.RoleName, claims, expires: DateTime.UtcNow.AddDays(1), signingCredentials: signIn);
                        var writeToken = new JwtSecurityTokenHandler().WriteToken(token);
                        return Ok(new { status = HttpStatusCode.OK, token = writeToken, message = "Login Berhasil!"} );
                    }
                    else
                    {
                        return BadRequest(new { status = HttpStatusCode.BadRequest, result = "failed", message = "Invalid credentials" });
                    }
                }
                else
                {
                    return BadRequest(new { status = HttpStatusCode.BadRequest, result = "failed", message = "Gagal Login" });
                }
            }
            else
            {
                return BadRequest(new { status = HttpStatusCode.BadRequest, result = "failed", message = "Gagal Login" });
            }
        }



        [HttpPost("/API/Accounts/ResetPassword")]
        public ActionResult ResetPassword(ResetPasswordVm resetPwdVm)
        {
            int reset = accountsRepository.ResetPassword(resetPwdVm);
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
