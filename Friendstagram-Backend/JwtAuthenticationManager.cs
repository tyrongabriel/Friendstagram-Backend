using System;
using System.Collections.Generic;
using System.Configuration;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Friendstagram_Backend.Interfaces;
using Microsoft.IdentityModel.Tokens;

namespace Friendstagram_Backend.Model
{
    public class JwtAuthenticationManager : IJwtAuthenticationManager
    {
        private readonly string Key;
        private FriendstagramContext DBContext;
        private SecurityHelper SecurityManager;
        public JwtAuthenticationManager(SecurityHelper securityManager, FriendstagramContext dbContext)
        {
            SecurityManager = securityManager;
            DBContext = dbContext;
            Key = ConfigurationManager.AppSettings["Private Key"];
        }

        public string Authenticate(string email, string password)
        {
            User authUser = DBContext.Users.ToList().FirstOrDefault(u => u.Email == email && u.Password == this.SecurityManager.CreateSha256Hash(password, u.Salt));
            if (authUser == null)
            {
                return null;
            }
            if (authUser.Verified == 0) return null;

            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenKey = Convert.FromBase64String(Key);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]{
                    new Claim("UserId", Convert.ToString(authUser.UserId))
                }),
                Expires = DateTime.UtcNow.AddYears(1),
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(tokenKey),
                    SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }


    }
}
