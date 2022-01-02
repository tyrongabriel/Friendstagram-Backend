using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace Friendstagram_Backend.DTOs
{
    public partial class PostDto
    {
        [Required]
        public int id_post { get; set; }
        [Required, MaxLength(100)]
        public string heading { get; set; }
        [Required, MaxLength(200)]
        public string description { get; set; }
        [Required]
        public string created_at { get; set; }
        [Required]
        public string image_small { get; set; }
        public string? image { get; set; }
        [Required]
        public ICollection<CommentDto> comments { get; set; }
        [Required]
        public UserDto posted_by { get; set; }
    }
}
