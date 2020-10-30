using aspApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace aspApp.Repositories
{
    public class Repository<T> where T : class
    {
        public dbloginclaimsContext Context { get; set; }

        public Repository()
        {
            Context = new dbloginclaimsContext();
        }

        public Repository(dbloginclaimsContext dbloginclaimsContext)
        {
            Context = dbloginclaimsContext;
        }

        public IEnumerable<T> GetAll()
        {
            return Context.Set<T>();
        }

        public T GetById(object id)
        {
            return Context.Find<T>(id);
        }

        public void Insert(T entity)
        {
            Context.Add(entity);
            Save();
        }

        public void Update(T entity)
        {
            Context.Update(entity);
            Save();
        }

        public void Delete(T entity)
        {
            Context.Remove(entity);
            Save();
        }

        private void Save()
        {
            Context.SaveChanges();
        }
    }
}