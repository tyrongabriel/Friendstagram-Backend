using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Configuration;
using Friendstagram_Backend.Model;
using Microsoft.EntityFrameworkCore;
using Friendstagram_Backend.DTOs;
using Friendstagram_Backend.Interfaces;

namespace Friendstagram_Backend.Controllers
{
    [ApiController]
    [Route("api/")]
    public class FriendstagramControllerBase : ControllerBase
    {
        protected FriendstagramContext DBContext;
        protected IJwtAuthenticationManager JwtAuthenticationManager;

        public FriendstagramControllerBase(FriendstagramContext dbContext, IJwtAuthenticationManager jwtAuthenticationManager)
        {
            DBContext = dbContext;
            JwtAuthenticationManager = jwtAuthenticationManager;
        }
        
    }
}
