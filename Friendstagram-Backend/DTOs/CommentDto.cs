using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace Friendstagram_Backend.DTOs
{
    public partial class CommentDto
    {
        public int? id_comment { get; set; }
        public int? id_post { get; set; }
        public int? id_user { get; set; }
        [Required, MaxLength(200)]
        public string comment { get; set; }
        [Required]
        public string created_at { get; set; }
        [Required]
        public UserDto user { get; set; }
    }
}
