using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace Friendstagram_Backend.DTOs
{
    public partial class FileTypeDto
    {
        [Required]
        public int id_fileType { get; set; }
        [Required, MaxLength(64)]
        public string name { get; set; }
    }
}
