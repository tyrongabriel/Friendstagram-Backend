using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Configuration;
using Friendstagram_Backend.Model;

namespace Friendstagram_Backend.Controllers
{
    [ApiController]
    [Route("api/{GroupCode}")]
    public class FriendstagramControllerBase : ControllerBase
    {
        [HttpGet]
        public Group Get(string GroupCode)
        {
            using (FriendstagramContext DBContext = new FriendstagramContext())
            {
                if (DBContext.Database.CanConnect())
                {
                    return DBContext.Groups.FirstOrDefault(g => g.Code == GroupCode);
                }
                else
                {
                    return null;
                }
            }
        }
    }
}
