using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Friendstagram_Backend.DTOs
{
    public class ChangePasswordDto
    {
        [MaxLength(64)]
        public string password { get; set; }

        [MaxLength(64)]
        public string newPassword { get; set; }
    }
}
