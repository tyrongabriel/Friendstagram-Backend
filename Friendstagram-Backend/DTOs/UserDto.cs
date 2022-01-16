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
        [Required, MaxLength(64)]
        public string username { get; set; }
        [Required, MaxLength(64)]
        public string email { get; set; }
        public string profile_picture { get; set; }
    }
}
