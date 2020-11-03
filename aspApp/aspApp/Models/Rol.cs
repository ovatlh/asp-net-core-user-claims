using System;
using System.Collections.Generic;

namespace aspApp.Models
{
    public partial class Rol
    {
        public Rol()
        {
            Rolclaims = new HashSet<Rolclaims>();
            User = new HashSet<User>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int IdStartPage { get; set; }

        public Startpage IdStartPageNavigation { get; set; }
        public ICollection<Rolclaims> Rolclaims { get; set; }
        public ICollection<User> User { get; set; }
    }
}
