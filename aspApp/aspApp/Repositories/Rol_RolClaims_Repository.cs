using aspApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace aspApp.Repositories
{
    public class Rol_RolClaims_Repository
    {
        public Rol_RolClaims_VM GetRolClaims_VM(int idrol_value)
        {
            Rol_Repository rol_Repository = new Rol_Repository();
            RolClaims_Repository rolClaims_Repository = new RolClaims_Repository();

            Rol_RolClaims_VM rol_RolClaims_VM = new Rol_RolClaims_VM()
            {
                Rol_Item = rol_Repository.GetById(idrol_value),
                Rolclaims_List = rolClaims_Repository.GetRolclaimsBy_IdRol_With_Navigation(idrol_value)
            };

            return rol_RolClaims_VM;
        }
    }
}