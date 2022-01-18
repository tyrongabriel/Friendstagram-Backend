using Friendstagram_Backend.Interfaces;
using Friendstagram_Backend.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

using Friendstagram_Backend.DTOs;

namespace Friendstagram_Backend.Controllers
{
    [Authorize]
    [EnableCors]
    [Route("api/[controller]")]
    [ApiController]
    public class CommentController : FriendstagramControllerBase
    {

        public CommentController(FriendstagramContext dbContext, IJwtAuthenticationManager jwtAuthenticationManager) : base(dbContext, jwtAuthenticationManager)
        {

        }
        //GET api/comment/{postId}
        [HttpGet("{postId}")]
        public IActionResult GetComments(int postId)
        {
            User thisUser;
            this.User.GetUser(DBContext, out thisUser, true);

            Group group = thisUser.Group;

            List<Comment> comment = DBContext.Comments.Where(c => c.PostId == postId && group.GroupId == thisUser.GroupId).ToList();

            //throws this weird mysql errors when converted to DTO in upper line
            return Ok(comment.Select(x => x.AsDto()));

        }
        //POST api/comment
        [HttpPost("")]
        public IActionResult PostComment([FromBody] CreateCommentDto newComment)
        {
            User thisUser;
            this.User.GetUser(DBContext, out thisUser, true);


            Group group = thisUser.Group;
            Post post = DBContext.Posts.Where(p => p.PostId == newComment.postId).FirstOrDefault();

            Comment comment = new Comment()
            {
                PostId = newComment.postId,
                CreatedAt = DateTime.Now,
                Text = newComment.text,
                User = thisUser,
                Post = post,

            };

            DBContext.Comments.Add(comment);
            DBContext.SaveChanges();
            return Ok(comment.AsDto());

        }
    }
}
