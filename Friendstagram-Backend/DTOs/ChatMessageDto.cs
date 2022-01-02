using System;
using System.Collections.Generic;

#nullable disable

namespace Friendstagram_Backend.DTOs
{
    public partial class ChatMessageDto
    {
        public string content { get; set; }
        public string date { get; set; }
        public UserDto sender { get; set; }
    }
}
