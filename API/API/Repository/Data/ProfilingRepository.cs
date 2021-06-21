using API.Contexts;
using API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Repository.Data
{
    public class ProfilingRepository : GeneralRepository<MyContexts, Profilings, string>
    {
        public ProfilingRepository(MyContexts myContexts) : base(myContexts)
        {

        }
    }
}
