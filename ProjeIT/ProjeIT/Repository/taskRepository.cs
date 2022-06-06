using ProjeIT.Models.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ProjeIT.Repository
{
    public class taskRepository<T> : IRepository<T> where T : class
    {
        ProjeIT_DbEntities db = new ProjeIT_DbEntities();

        DbSet<T> _object;

        public taskRepository()
        {
            _object = db.Set<T>();
        }

        public void Add(T p)
        {
            _object.Add(p);
            db.SaveChanges();
        }

        public void Delete(T p)
        {
            _object.Remove(p);
            db.SaveChanges();
        }

        public List<T> List()
        {
            return _object.ToList();
        }

        public void Update(T p)
        {
            db.SaveChanges();
        }

    }
}