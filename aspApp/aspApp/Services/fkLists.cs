using aspApp.Models;
using aspApp.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace aspApp.Services
{
    public class fkLists
    {
        public IEnumerable<Rol> GetRols_List()
        {
            Rol_Repository rol_Repository = new Rol_Repository();
            return rol_Repository.GetAll();
        }

        public IEnumerable<Claims> GetClaims_List()
        {
            Claims_Repository claims_Repository = new Claims_Repository();
            return claims_Repository.GetAll();
        }

        public IEnumerable<Rolclaims> GetRolclaims_List()
        {
            RolClaims_Repository rolClaims_Repository = new RolClaims_Repository();
            return rolClaims_Repository.GetAll();
        }
    }
}