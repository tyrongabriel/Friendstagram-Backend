using System;
using System.Collections.Generic;

#nullable disable

namespace Friendstagram_Backend.DTOs
{
    public partial class PostDto
    {
        public int id_post { get; set; }
        public string heading { get; set; }
        public string description { get; set; }
        public string created_at { get; set; }
        public string image_small { get; set; }
        public string? image { get; set; }
        public ICollection<CommentDto> comments { get; set; }
        public UserDto posted_by { get; set; }
    }
}
