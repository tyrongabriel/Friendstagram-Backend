﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace Friendstagram_Backend.DTOs
{
    public partial class CreateChatMessageDto
    {
        [Required, MaxLength(1000)]
        public string content { get; set; }
        
        
    }
}
