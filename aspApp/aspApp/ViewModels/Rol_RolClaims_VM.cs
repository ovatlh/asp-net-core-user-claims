using aspApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace aspApp.ViewModels
{
    public class Rol_RolClaims_VM
    {
        public Rol Rol_Item { get; set; }
        public IEnumerable<Rolclaims> Rolclaims_List { get; set; }
    }
}