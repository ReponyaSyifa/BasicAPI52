using API.Contexts;
using API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Repository.Data
{
    public class UniversitiesRepository : GeneralRepository<MyContexts, Universities, string>
    {
        public UniversitiesRepository(MyContexts myContexts) : base(myContexts)
        {

        }
    }
}
