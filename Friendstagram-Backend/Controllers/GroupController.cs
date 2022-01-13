using Friendstagram_Backend.Interfaces;
using Friendstagram_Backend.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Friendstagram_Backend.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class GroupController : FriendstagramControllerBase
    {
        public GroupController(FriendstagramContext dbContext, IJwtAuthenticationManager jwtAuthenticationManager) : base(dbContext, jwtAuthenticationManager)
        {

        }



        // GET api/{GroupCode}
        //[HttpGet]
        //public ActionResult<GroupDto> GetGroup(string GroupCode)
        //{
        //    using (FriendstagramContext DBContext = new FriendstagramContext())
        //    {
        //        if (DBContext.Database.CanConnect())
        //        {
        //            return DBContext.Groups.FirstOrDefault(g => g.Code == GroupCode).AsDto();
        //        }
        //        else
        //        {
        //            return null;
        //        }
        //    }
        //}
    }
}
