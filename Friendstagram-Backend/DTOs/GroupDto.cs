using System;
using System.Collections.Generic;

#nullable disable

namespace Friendstagram_Backend.DTOs
{
    public partial class GroupDto
    {
        public GroupDto()
        {
            Users = new HashSet<UserDto>();
        }

        public int GroupId { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }

        public virtual ICollection<UserDto> Users { get; set; }
    }
}
