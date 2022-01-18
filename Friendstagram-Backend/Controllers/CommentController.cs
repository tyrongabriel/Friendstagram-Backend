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
    public class CommentController : FriendstagramControllerBase
    {

        public CommentController(FriendstagramContext dbContext, IJwtAuthenticationManager jwtAuthenticationManager) : base(dbContext, jwtAuthenticationManager)
        {

        }
        //GET api/comment
        [HttpGet("")]
        public IActionResult GetComments([FromQuery] int index = 0, [FromQuery] int items = 5)
        {
            try
            {
                User thisUser;
                this.User.GetUser(DBContext, out thisUser, true);

                Group group = thisUser.Group;

                List<Comment> comment = DBContext.Comments.Where(c => c.PostId == group.GroupId).ToList();

                //throws this weird mysql errors when converted to DTO in upper line
                return Ok(comment.Select(x => x.AsDto()));

            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Something went wrong!");
            }

        }
    }
}
