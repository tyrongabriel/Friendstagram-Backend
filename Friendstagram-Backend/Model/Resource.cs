using System;
using System.Collections.Generic;

#nullable disable

namespace Friendstagram_Backend.Model
{
    public partial class Resource
    {
        public Resource()
        {
            Posts = new HashSet<Post>();
            Users = new HashSet<User>();
        }

        public int ResourceId { get; set; }
        public string Filename { get; set; }
        public string Path { get; set; }
        public int FileTypeId { get; set; }

        public virtual FileType FileType { get; set; }
        public virtual ICollection<Post> Posts { get; set; }
        public virtual ICollection<User> Users { get; set; }
    }
}
