using System;
using System.Collections.Generic;

#nullable disable

namespace Friendstagram_Backend.Model
{
    public partial class User
    {
        public User()
        {
            ChatMessages = new HashSet<ChatMessage>();
            Comments = new HashSet<Comment>();
            Posts = new HashSet<Post>();
        }

        public int UserId { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Salt { get; set; }
        public string VerificationCode { get; set; }
        public sbyte Verified { get; set; }
        public int GroupId { get; set; }
        public int ProfilePictureId { get; set; }

        public virtual Group Group { get; set; }
        public virtual Resource ProfilePicture { get; set; }
        public virtual ICollection<ChatMessage> ChatMessages { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
        public virtual ICollection<Post> Posts { get; set; }
    }
}
