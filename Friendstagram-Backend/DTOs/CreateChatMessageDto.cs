using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace Friendstagram_Backend.DTOs
{
    public partial class ChatMessageDto
    {
        [Required, MaxLength(1000)]
        public string content { get; set; }
        [Required]
        public string date { get; set; }
        [Required]
        public UserDto sender { get; set; }
    }
}
