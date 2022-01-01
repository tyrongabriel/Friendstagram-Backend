using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Configuration;

namespace Friendstagram_Backend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TestController : ControllerBase
    {
        [HttpGet]
        public string Get()
        {
            return ConfigurationManager.ConnectionStrings["default"].ConnectionString;
        }
    }
}
