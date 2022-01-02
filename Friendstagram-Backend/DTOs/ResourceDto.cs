using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace Friendstagram_Backend.DTOs
{
    public partial class ResourceDto
    {
        public ResourceDto()
        {
            Posts = new HashSet<PostDto>();
            Users = new HashSet<UserDto>();
        }

        public int ResourceId { get; set; }
        public string Filename { get; set; }
        public string Path { get; set; }
        public int FileTypeId { get; set; }

        public virtual FileTypeDto FileType { get; set; }
        public virtual ICollection<PostDto> Posts { get; set; }
        public virtual ICollection<UserDto> Users { get; set; }
    }
}
