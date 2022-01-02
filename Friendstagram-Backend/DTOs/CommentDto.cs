using System;
using System.Collections.Generic;

#nullable disable

namespace Friendstagram_Backend.DTOs
{
    public partial class CommentDto
    {
        public int? id_comment { get; set; }
        public int? id_post { get; set; }
        public int? id_user { get; set; }
        public string comment { get; set; }
        public string created_at { get; set; }
        public UserDto user { get; set; }
    }
}
