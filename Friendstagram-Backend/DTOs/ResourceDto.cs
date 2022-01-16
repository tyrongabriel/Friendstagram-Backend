using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace Friendstagram_Backend.DTOs
{
    public partial class ResourceDto
    {
        [Required]
        public int id_resource { get; set; }
        [Required, MaxLength(64)]
        public string filename { get; set; }
        [Required, MaxLength(250)]
        public string path { get; set; }
        [Required, MaxLength(250)]
        public string path_compressed { get; set; }
        [Required]
        public FileTypeDto fileType { get; set; }
    }
}
