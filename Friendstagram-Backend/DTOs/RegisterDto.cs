using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Friendstagram_Backend.DTOs
{
    public class RegisterDto
    {
        [Required, MaxLength(16)]
        public string groupCode { get; set; }
        [Required, MaxLength(40)]
        public string username { get; set; }
        [Required, MaxLength(60)]
        public string email { get; set; }
        [Required]
        public string password { get; set; }
    }
}
