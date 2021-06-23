using API.Base;
using API.Models;
using API.Repository.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UniversitiesController : BaseController<Universities, UniversitiesRepository, string>
    {
        public UniversitiesController(UniversitiesRepository universitiesRepository) : base(universitiesRepository)
        {

        }
    }
}
