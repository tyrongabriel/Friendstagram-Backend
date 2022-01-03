using Friendstagram_Backend.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Friendstagram_Backend.Controllers
{
    [Route("{GroupCode}/[controller]")]
    [ApiController]
    public class UserController : FriendstagramControllerBase
    {
        public UserController(FriendstagramContext dbContext) : base(dbContext)
        {

        }
    }
}
