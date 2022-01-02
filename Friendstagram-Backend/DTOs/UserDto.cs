using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace Friendstagram_Backend.DTOs
{
    public partial class UserDto
    {
        [Required]
        public int? id_user { get; set; }
        [Required, MaxLength(40)]
        public string username { get; set; }
        [Required, MaxLength(60)]
        public string email { get; set; }
        public string profile_picture { get; set; }
    }
}
