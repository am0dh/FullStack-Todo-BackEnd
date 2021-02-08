using CRUD_API.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRUD_API.Repository
{
   public interface ITaskRepository
    {
        TodoTask Find(int id);
        List<TodoTask> GetAll();
        TodoTask Add(TodoTask tdTsk);
        TodoTask Update(TodoTask tdTsk);
        void Remove(int id);



    }
}
