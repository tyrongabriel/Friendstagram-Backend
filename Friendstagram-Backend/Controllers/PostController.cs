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
using Friendstagram_Backend.DTOs;

namespace Friendstagram_Backend.Controllers
{
    [Authorize]
    [EnableCors]
    [Route("api/[controller]")]
    [ApiController]
    public class PostController : FriendstagramControllerBase
    {
        public PostController(FriendstagramContext dbContext, IJwtAuthenticationManager jwtAuthenticationManager) : base(dbContext, jwtAuthenticationManager)
        {

        }

        //GET api/post
        [HttpGet("")]
        public IActionResult GetPost([FromQuery] int index = 0, [FromQuery] int items = 5)
        {
            User thisUser;
            this.User.GetUser(DBContext, out thisUser, true);

            Group group = thisUser.Group;

            List<Post> posts = DBContext.Posts.Where(p => p.User.GroupId == group.GroupId).OrderByDescending(p => p.CreatedAt).Skip(index).Take(items).ToList();

            //throws this weird mysql errors when converted to DTO in upper line
            return Ok(posts.Select(x => x.AsDto()));

        }

        //POST api/post
        [HttpPost("")]
        public IActionResult CreatePost()
        {
            User thisUser;
            this.User.GetUser(DBContext, out thisUser, true);
            Group group = thisUser.Group;

            return Ok();

        }
    }
}
