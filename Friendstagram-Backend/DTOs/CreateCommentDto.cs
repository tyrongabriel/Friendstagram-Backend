using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace Friendstagram_Backend.DTOs
{
    public partial class CreateCommentDto
    {
        [Required, MaxLength(200)]
        public string text { get; set; }

        [Required]
        public int postId { get; set; }
    }
}
