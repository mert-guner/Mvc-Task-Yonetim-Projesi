using ProjeIT.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjeIT.Repository
{
    public class taskManager
    {
        taskRepository<task> repo = new taskRepository<task>();


        public List<task> GetAll()
        {
            return repo.List();
        }

        public void TaskAdd(task task)
        {
            repo.Add(task);
        }

        public void TaskDelete(task task)
        {
            repo.Delete(task);
        }
    }
}