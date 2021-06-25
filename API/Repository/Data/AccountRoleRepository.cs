using API.Contexts;
using API.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace API.Repository.Data
{
    public class AccountRoleRepository : GeneralRepository<MyContexts, AccountRole, string>
    {
        private readonly MyContexts myContexts;
        private readonly DbSet<AccountRole> accRoles;
        public AccountRoleRepository(MyContexts myContexts) : base(myContexts)
        {
            this.myContexts = myContexts;
        }

        //di cek di tabel account role itu ada roleid 1 atau enggak, kalo ga ada, add, kalo ada return 0

        public int SetRole(AccountRole accRoles) // ga yakin disini....
        {
            var cekRole = myContexts.AccountRoles.Find(accRoles.AccountsId, accRoles.RolesId);
            var cekAcc = myContexts.AccountRoles.Find(accRoles.AccountsId, accRoles.RolesId);
            if (cekRole != null && cekAcc.Equals(1))
            {
                AccountRole accrole = new AccountRole();
                accrole.AccountsId = accRoles.AccountsId; //role sbg nik, acc sbg email
                accrole.RolesId = 2;
                myContexts.AccountRoles.Add(accrole);
                myContexts.SaveChanges();
                return 2;
            }
            else
            {
                AccountRole accrole = new AccountRole();
                accrole.AccountsId = accRoles.AccountsId;
                accrole.RolesId = 1;
                myContexts.AccountRoles.Add(accrole);
                myContexts.SaveChanges();
                return 1;
            }
        }

        /*public IEnumerable<AccountRole> Get()
        {
            var getAll = myContexts.AccountRoles.ToList();
            return getAll;
        }*/


    }

}
