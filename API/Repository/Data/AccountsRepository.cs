﻿using API.Contexts;
using API.Models;
using API.ViewModel;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace API.Repository.Data
{
    public class AccountsRepository : GeneralRepository<MyContexts, Accounts, string>
    {
        private readonly MyContexts myContexts;
        public AccountsRepository(MyContexts myContexts) : base(myContexts)
        {
            this.myContexts = myContexts;
        }

        public int Login(LoginVm loginVm)
        {
            
            Employees employee = new Employees();
            Accounts acc = new Accounts();

            var findAccount = myContexts.Accounts.Find(loginVm.NIK);

            var cocokAkun = myContexts.Accounts.FirstOrDefault(c => c.NIK == loginVm.NIK);
            
            if (findAccount != null)
            {
                if (cocokAkun != null && HashingPassword.ValidatePassword(loginVm.Password, cocokAkun.Password))
                {
                    return 1;
                }
                else
                {
                    return 2;
                }
            }
            else
            {
                return 0;
            }               

        }

        public string Guid() //
        {
            System.Guid guid = System.Guid.NewGuid();
            string newguid = guid.ToString();

            return newguid;
        }

        public int ResetPassword(LoginVm loginVm)
        {
            string guid = Guid();

            LoginVm log = new LoginVm();
            Employees emp = new Employees();
            var accs = new Accounts();
            var mailEmp = emp.Email;

            var accConfirm = myContexts.Accounts.Find(loginVm.Email);
            var accMatch = myContexts.Employees.FirstOrDefault(c => c.Email == loginVm.Email);

            if (accMatch != null)
            {
                accs.NIK = accMatch.NIK;
                accs.Password = guid;
                myContexts.Entry(accs).State = EntityState.Modified;
                var updt = myContexts.SaveChanges();

                using (MailMessage message = new MailMessage("trianingsih.syifa@gmail.com", loginVm.Email))
                {
                    message.Subject = "[No Reply] Reset Password";
                    string bodyMail = "Hi There!, ";
                    bodyMail += "\n\nPlease copy of these following hash code and paste to your login form:\n\n";
                    bodyMail += guid;
                    bodyMail += "\n\nThanks!\n\n";
                    bodyMail += "\n\nRegards,\nMe!\n";
                    message.Body = bodyMail;

                    SmtpClient smtp = new SmtpClient();
                    smtp.Host = "smtp.gmail.com";
                    smtp.UseDefaultCredentials = false;
                    NetworkCredential NetworkCred = new NetworkCredential("trianingsih.syifa@gmail.com", "raha,sia.");
                    smtp.Credentials = NetworkCred;
                    smtp.EnableSsl = true;
                    smtp.Port = 587;
                    smtp.Send(message);
                }

                return 2;
            }
            else
            {
                return 1;
            }

        }     


        public int ChangePassword(ChangePasswordVm chgPasswordVm)
        {
            //Accounts accs = new Accounts();
            var acc = myContexts.Accounts.Find(chgPasswordVm.NIK);
            if (acc != null)
            {
                if (acc.Password == chgPasswordVm.PasswordLama)
                {
                    acc.NIK = chgPasswordVm.NIK;
                    acc.Password = HashingPassword.HashPassword(chgPasswordVm.PasswordBaru);
                    myContexts.Entry(acc).State = EntityState.Modified;
                    myContexts.SaveChanges();

                    return 3;
                }
                else
                {
                    return 2;
                }
            }
            else
            {
                return 1;
            }

        }
    }

            
    
}
