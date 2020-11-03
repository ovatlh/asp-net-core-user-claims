using aspApp.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace aspApp.Repositories
{
    public class Rol_Repository : Repository<Rol>
    {
        public void DeleteAllRolClaimsBy_IdRol(int idrol_value)
        {
            RolClaims_Repository rolClaims_Repository = new RolClaims_Repository();
            User_Repository user_Repository = new User_Repository();

            IEnumerable<Rolclaims> result_rolclaims = rolClaims_Repository.GetRolclaimsBy_IdRol(idrol_value);

            if (result_rolclaims != null)
            {
                rolClaims_Repository.Context.RemoveRange(result_rolclaims);
                rolClaims_Repository.Context.SaveChanges();
                //foreach (var item in result_rolclaims)
                //{
                //    //rolClaims_Repository.Delete(item);
                //    rolClaims_Repository.Context.RemoveRange(result_rolclaims);
                //    //rolClaims_Repository.Context.Remove(item);
                //}
                //rolClaims_Repository.Context.SaveChanges();
            }

            IEnumerable<User> result_users = user_Repository.GetUsersBy_IdRol(idrol_value);

            if (result_users != null)
            {
                user_Repository.Context.RemoveRange(result_users);
                user_Repository.Context.SaveChanges();
            }
        }

        public Rol GetRolBy_Id_With_Navigation(int idrol_value)
        {
            return Context.Rol.Include(x => x.IdStartPageNavigation).FirstOrDefault(x => x.Id == idrol_value);
        }

        public IEnumerable<Rol> GetRolsWith_Navigation()
        {
            return Context.Rol.Include(x => x.IdStartPageNavigation);
        }
    }
}