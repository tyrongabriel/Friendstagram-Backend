using System;
using System.Collections.Generic;

#nullable disable

namespace Friendstagram_Backend.DTOs
{
    public partial class FileTypeDto
    {
        public FileTypeDto()
        {
            Resources = new HashSet<ResourceDto>();
        }

        public int TypeId { get; set; }
        public string Name { get; set; }

        public virtual ICollection<ResourceDto> Resources { get; set; }
    }
}
