using System;
using System.Collections.Generic;

namespace aspApp.Models
{
    public partial class Claims
    {
        public Claims()
        {
            Rolclaims = new HashSet<Rolclaims>();
        }

        public int Id { get; set; }
        public string DisplayName { get; set; }
        public string Content { get; set; }

        public ICollection<Rolclaims> Rolclaims { get; set; }
    }
}
