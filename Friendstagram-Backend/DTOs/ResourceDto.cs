using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace Friendstagram_Backend.DTOs
{
    public partial class ResourceDto
    {
        public int id_resource { get; set; }
        public string filename { get; set; }
        public string path { get; set; }
        public string path_compressed { get; set; }
        public FileTypeDto fileType { get; set; }
    }
}
