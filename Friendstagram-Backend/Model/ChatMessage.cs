using System;
using System.Collections.Generic;

#nullable disable

namespace Friendstagram_Backend.Model
{
    public partial class ChatMessage
    {
        public int ChatMessageId { get; set; }
        public string Content { get; set; }
        public DateTime CreatedAt { get; set; }
        public int SenderId { get; set; }
    }
}
