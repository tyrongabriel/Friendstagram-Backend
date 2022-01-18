using System;
using System.Collections.Generic;

#nullable disable

namespace Friendstagram_Backend.Model
{
    public partial class Comment
    {
        public int CommentId { get; set; }
        public string Text { get; set; }
        public DateTime CreatedAt { get; set; }
        public int PostId { get; set; }
        public int UserId { get; set; }

        public virtual Post Post { get; set; }
        public virtual User User { get; set; }
    }
}
