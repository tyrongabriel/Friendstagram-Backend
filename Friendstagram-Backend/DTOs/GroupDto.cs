using System;
using System.Collections.Generic;

#nullable disable

namespace Friendstagram_Backend.DTOs
{
    public partial class GroupDto
    {
        public int id_group { get; set; }
        public string name { get; set; }
        public string code { get; set; }
        public ICollection<UserDto> users { get; set; }
    }
}
