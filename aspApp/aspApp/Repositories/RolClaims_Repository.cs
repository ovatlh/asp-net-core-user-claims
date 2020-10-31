using aspApp.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace aspApp.Repositories
{
    public class RolClaims_Repository : Repository<Rolclaims>
    {
        public IEnumerable<Rolclaims> GetRolclaims_With_Navigation()
        {
            return Context.Rolclaims.Include(x => x.IdRolNavigation).Include(x => x.IdClaimsNavigation);
        }

        public IEnumerable<Rolclaims> GetRolclaimsBy_IdRol_With_Navigation(int idrol_value)
        {
            return Context.Rolclaims.Where(x => x.IdRol == idrol_value);
        }

        public Rolclaims GetRolclaimBy_Id_With_Navigation(int id_value)
        {
            return Context.Rolclaims.Include(x => x.IdRolNavigation).Include(x => x.IdClaimsNavigation).FirstOrDefault(x => x.Id == id_value);
        }
    }
}