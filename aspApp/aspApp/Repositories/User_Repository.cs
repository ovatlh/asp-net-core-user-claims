using aspApp.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace aspApp.Repositories
{
    public class User_Repository : Repository<User>
    {
        public IEnumerable<User> GetUsers_With_Navigation()
        {
            return Context.User.Include(x => x.IdRolNavigation);
        }

        public User GetUserBy_Id_With_Navigation(int id_value)
        {
            return Context.User.Include(x => x.IdRolNavigation).FirstOrDefault(x => x.Id == id_value);
        }
    }
}