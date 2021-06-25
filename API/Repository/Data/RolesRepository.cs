using API.Contexts;
using API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Repository.Data
{
    public class RolesRepository : GeneralRepository<MyContexts, Roles, int>
    {
        public RolesRepository(MyContexts myContexts) : base(myContexts)
        {

        }
    }
}
