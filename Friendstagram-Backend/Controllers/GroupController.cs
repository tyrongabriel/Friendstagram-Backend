using Friendstagram_Backend.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Friendstagram_Backend.Controllers
{
    [Route("/{GroupCode}")]
    [ApiController]
    public class GroupController : FriendstagramControllerBase
    {
        public GroupController(FriendstagramContext dbContext) : base(dbContext)
        {

        }
    }
}
