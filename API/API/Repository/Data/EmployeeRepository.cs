using API.Contexts;
using API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Repository.Data
{
    public class EmployeeRepository : GeneralRepository<MyContexts, Employees, string>
    {
        public EmployeeRepository(MyContexts myContexts) : base(myContexts)
        {

        }
    }
}
