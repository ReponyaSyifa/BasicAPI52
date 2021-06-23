﻿using API.Contexts;
using API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Repository.Data
{
    public class EducationRepository : GeneralRepository<MyContexts, Educations, string>
    {
        public EducationRepository(MyContexts myContexts) : base(myContexts)
        {

        }
    }
}
