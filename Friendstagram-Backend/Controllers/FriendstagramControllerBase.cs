using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Configuration;
using Friendstagram_Backend.Model;
using Microsoft.EntityFrameworkCore;
using Friendstagram_Backend.DTOs;

namespace Friendstagram_Backend.Controllers
{
    [ApiController]
    [Route("api/")]
    public class FriendstagramControllerBase : ControllerBase
    {
        protected FriendstagramContext DBContext;
        public FriendstagramControllerBase(FriendstagramContext dbContext)
        {
            DBContext = dbContext;
        }

        [HttpGet]
        public ActionResult<GroupDto> Get(string GroupCode)
        {
            using (FriendstagramContext DBContext = new FriendstagramContext())
            {
                if (DBContext.Database.CanConnect())
                {
                    return DBContext.Groups.FirstOrDefault(g => g.Code == GroupCode).AsDto();
                }
                else
                {
                    return null;
                }
            }
        }
    }
}
