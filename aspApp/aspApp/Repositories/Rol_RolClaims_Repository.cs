using aspApp.Models;
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

        public void AddRolClaims(int idrol_value, int idclaims_value)
        {
            RolClaims_Repository rolClaims_Repository = new RolClaims_Repository();

            Rolclaims new_rolclaims = new Rolclaims()
            {
                IdRol = idrol_value,
                IdClaims = idclaims_value
            };

            rolClaims_Repository.Insert(new_rolclaims);
        }

        public void DeleteRolClaims(int idrolclaims_value)
        {
            RolClaims_Repository rolClaims_Repository = new RolClaims_Repository();
            Rolclaims result_rolclaims = rolClaims_Repository.GetById(idrolclaims_value);

            rolClaims_Repository.Delete(result_rolclaims);
        }
    }
}