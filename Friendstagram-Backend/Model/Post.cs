using System;
using System.Collections.Generic;

#nullable disable

namespace Friendstagram_Backend.Model
{
    public partial class Post
    {
        public Post()
        {
            Comments = new HashSet<Comment>();
        }

        public int PostId { get; set; }
        public string Heading { get; set; }
        public string Description { get; set; }
        public DateTime CreatedAt { get; set; }
        public int ResourceId { get; set; }
        public int UserId { get; set; }

        public virtual Resource Resource { get; set; }
        public virtual User User { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
    }
}
