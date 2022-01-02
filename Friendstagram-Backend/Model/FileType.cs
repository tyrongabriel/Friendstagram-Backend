using System;
using System.Collections.Generic;

#nullable disable

namespace Friendstagram_Backend.Model
{
    public partial class FileType
    {
        public FileType()
        {
            Resources = new HashSet<Resource>();
        }

        public int TypeId { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Resource> Resources { get; set; }
    }
}
