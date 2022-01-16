using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace Friendstagram_Backend.DTOs
{
    public partial class GroupDto
    {
        [Required]
        public int id_group { get; set; }
        [Required, MaxLength(64)]
        public string name { get; set; }
        [Required, MaxLength(16)]
        public string code { get; set; }
        [Required]
        public ICollection<UserDto> users { get; set; }
    }
}
