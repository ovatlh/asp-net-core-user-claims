using System;
using System.Collections.Generic;

namespace aspApp.Models
{
    public partial class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public int IdRol { get; set; }

        public Rol IdRolNavigation { get; set; }
    }
}
