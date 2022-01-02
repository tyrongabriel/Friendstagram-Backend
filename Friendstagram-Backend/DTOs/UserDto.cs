using System;
using System.Collections.Generic;

#nullable disable

namespace Friendstagram_Backend.DTOs
{
    public partial class UserDto
    {
        public int? id_user { get; set; }
        public string username { get; set; }
        public string email { get; set; }
        public string profile_picture { get; set; }
    }
}
