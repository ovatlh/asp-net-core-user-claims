using System;
using System.Collections.Generic;

namespace aspApp.Models
{
    public partial class Rolclaims
    {
        public int Id { get; set; }
        public int IdRol { get; set; }
        public int IdClaims { get; set; }

        public Claims IdClaimsNavigation { get; set; }
        public Rol IdRolNavigation { get; set; }
    }
}
