using Friendstagram_Backend.Interfaces;
using Friendstagram_Backend.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Friendstagram_Backend.Controllers
{
    [Authorize]
    [EnableCors]
    [Route("api/[controller]")]
    [ApiController]
    public class GroupController : FriendstagramControllerBase
    {
        public GroupController(FriendstagramContext dbContext, IJwtAuthenticationManager jwtAuthenticationManager) : base(dbContext, jwtAuthenticationManager)
        {

        }



        // GET api/group/{username}
        [HttpGet("{username}")]
        public IActionResult GetGroup(string username)
        {
            User thisUser;
            User.GetUser(DBContext, out thisUser, true);
            if (thisUser.Username == username)
            {
                Group returnGroup = DBContext.Groups.FirstOrDefault(g => g.GroupId == thisUser.GroupId);
                return Ok(returnGroup.AsDto());
            }
            else
            {
                return Unauthorized("Not authorized for group of this User");
            }
        }


        // PATCH api/group/code
        [HttpPatch("code")]
        public IActionResult GenerateNewCode()
        {
            User thisUser;
            User.GetUser(DBContext, out thisUser);
            Random rndGen = new Random();
            string code = "";
            for (int i = 0; i < 16; i++)
            {
                code += rndGen.Next(10);
            }
            thisUser.Group.Code = code;
            DBContext.SaveChanges();
            return Ok(new { code = code });
        }
    }
}
