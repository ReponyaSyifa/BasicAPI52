using API.Contexts;
using API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Repository.Data
{
    public class AccountsRepository : GeneralRepository<MyContexts, Accounts, string>
    {
        public AccountsRepository(MyContexts myContexts) : base(myContexts)
        {

        }
    }
}
