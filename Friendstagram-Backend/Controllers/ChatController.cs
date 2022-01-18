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
    public class ChatController : FriendstagramControllerBase
    {

        public ChatController(FriendstagramContext dbContext, IJwtAuthenticationManager jwtAuthenticationManager) : base(dbContext, jwtAuthenticationManager)
        {

        }
        //GET api/comment/{postId}
        [HttpGet("")]
        public IActionResult GetChat()
        {
            try
            {
                User thisUser;
                this.User.GetUser(DBContext, out thisUser, true);

                Group group = thisUser.Group;

                List<ChatMessage> chatMessages = DBContext.ChatMessages.Where(c => c.User.Group.GroupId == thisUser.GroupId).OrderByDescending(c => c.CreatedAt).ToList();
               

                //throws this weird mysql errors when converted to DTO in upper line
                return Ok(chatMessages.Select(x => x.AsDto()));

            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Something went wrong!");
            }

        }
        [HttpPost("")]
        public IActionResult PostChat([FromBody] CreateChatMessageDto incommingChatMessage)
        {
            try
            {
                User thisUser;
                this.User.GetUser(DBContext, out thisUser, true);
                Group group = thisUser.Group;

                ChatMessage newChatMessage = new ChatMessage()
                {
                    Content = incommingChatMessage.content,
                    User = thisUser,
                };

                DBContext.ChatMessages.Add(newChatMessage);
                DBContext.SaveChanges();
                return Ok(newChatMessage);
              

            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Something went wrong!");
            }

        }

    }
}
