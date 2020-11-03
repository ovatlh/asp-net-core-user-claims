using System;
using System.Collections.Generic;

namespace aspApp.Models
{
    public partial class Startpage
    {
        public Startpage()
        {
            Rol = new HashSet<Rol>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }

        public ICollection<Rol> Rol { get; set; }
    }
}
