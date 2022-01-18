using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Friendstagram_Backend.DTOs
{
    public class CreatePostDto
    {
        [Required, MaxLength(100)]
        public string heading { get; set; }
        [Required, MaxLength(200)]
        public string description { get; set; }
    }
}
