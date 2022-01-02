using System;
using System.Collections.Generic;

#nullable disable

namespace Friendstagram_Backend.Model
{
    public partial class Group
    {
        public Group()
        {
            Users = new HashSet<User>();
        }

        public int GroupId { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }

        public virtual ICollection<User> Users { get; set; }
    }
}
