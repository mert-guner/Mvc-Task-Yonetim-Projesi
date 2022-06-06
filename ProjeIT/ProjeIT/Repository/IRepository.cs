using ProjeIT.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjeIT.Repository
{
    public interface IRepository<T>
    {
       List<T> List();
        void Add(T p);
        void Delete(T p);
        void Update(T p);

    }
}
