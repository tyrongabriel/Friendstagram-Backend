using Friendstagram_Backend.DTOs;
using Friendstagram_Backend.Interfaces;
using Friendstagram_Backend.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using System.Diagnostics;

namespace Friendstagram_Backend.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : FriendstagramControllerBase
    {
        private SecurityHelper SecurityManager;
        public UserController(FriendstagramContext dbContext, IJwtAuthenticationManager jwtAuthenticationManager, SecurityHelper securityManager) : base(dbContext, jwtAuthenticationManager)
        {
            SecurityManager = securityManager;
        }

        // GET api/user/{username}
        [HttpGet("{username}")]
        public IActionResult GetUser(string username)
        {
            try
            {
                User gottenUser;
                this.User.GetUser(DBContext, out gottenUser);
                if (gottenUser == null)
                {
                    return NotFound($"Could not find a user with the username \"{username}\" in your group");
                }
                return Ok(gottenUser.AsDto());
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Something went wrong!");
            }
        }

        // GET api/user
        [HttpGet]
        public IActionResult GetLoggedInUser()
        {
            try
            {
                User thisUser;
                this.User.GetUser(DBContext, out thisUser, true);
                return Ok(thisUser.AsDto());
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Something went wrong!");
            }
        }

        // POST api/user/changeUsername
        [HttpPost("changeUsername")]
        public IActionResult ChangeUsername([FromBody] ChangeUsernameDto changeUser)
        {
            
            try
            {
                User newUser;
                this.User.GetUser(DBContext, out newUser);
                newUser.Username = changeUser.usernameNew;
                DBContext.SaveChanges();

                UserDto newUserDto = DBContext.Users.Include(u => u.ProfilePicture).FirstOrDefault(u => u.UserId == newUser.UserId).AsDto();

                return CreatedAtAction(nameof(GetUser), new { newUserDto.username }, newUserDto);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Something went wrong!");
            }
        }

        // POST api/user/authenticate
        [AllowAnonymous]
        [HttpPost("authenticate")]
        public IActionResult Authenticate([FromBody] AuthenticationDto userCredits)
        {
            var token = JwtAuthenticationManager.Authenticate(userCredits.Email, userCredits.Password);

            if (string.IsNullOrEmpty(token))
            {
                return Unauthorized();
            }

            return Ok(token);
        }

        // POST api/user/register
        [AllowAnonymous]
        [HttpPost("register")]
        public ActionResult<UserDto> Register([FromBody] RegisterDto userCredits)
        {
            Group registerIntoGroup = DBContext.Groups.FirstOrDefault(g => g.Code == userCredits.groupCode);

            if (registerIntoGroup == null)
            {
                return NotFound("Could not find Group with code: " + userCredits.groupCode);
            }
            else if (DBContext.Users.Any(u => u.Email == userCredits.email))
            {
                return StatusCode(StatusCodes.Status405MethodNotAllowed, "User with that email already exists");
            }
            else if (DBContext.Users.Any(u => u.Username == userCredits.username))
            {
                return StatusCode(StatusCodes.Status405MethodNotAllowed, "User with that username already exists");
            }

            string salt = SecurityManager.CreateSalt();

            User RegisteredUser = new User()
            {
                Username = userCredits.username,
                Email = userCredits.email,
                Password = SecurityManager.CreateSha256Hash(userCredits.password, salt),
                Salt = salt,
                GroupId = registerIntoGroup.GroupId,
                VerificationCode = SecurityManager.CreateVerifcationCode(),
                ProfilePictureId = 1
            };
            DBContext.Users.Add(RegisteredUser);
            DBContext.SaveChanges();
            return CreatedAtAction(nameof(GetUser), new { userCredits.username }, DBContext.Users.Include(u => u.ProfilePicture).FirstOrDefault(u => u.UserId == RegisteredUser.UserId).AsDto());
        }
    }
}
