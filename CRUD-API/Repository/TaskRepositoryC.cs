using CRUD_API.Model;
using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;


namespace CRUD_API.Repository
{
    public class TaskRepositoryC : ITaskRepository
    {
        private IDbConnection db;
        

        public TaskRepositoryC(IConfiguration configuration)
        {
            this.db=new SqlConnection(configuration.GetConnectionString("DefaultConnection"));
        }
        TodoTask ITaskRepository.Add(TodoTask tdTsk)
        {
            var sql = "INSERT INTO todoTask(todoTask,done) VALUES(@todoTask, @done); SELECT CAST(SCOPE_IDENTITY() as int);";
            var id = db.Query<int>(sql, new { @todoTask = tdTsk.todoTask, @done = tdTsk.done }).Single();
            return tdTsk;
        }

        TodoTask ITaskRepository.Find(int id)
        {
            var sql = "SELECT * FROM todoTask WHERE id= @isd";
            return db.Query<TodoTask>(sql, new { @isd=id }).Single();
        }

        List<TodoTask> ITaskRepository.GetAll()
        {
            var sql = "SELECT * FROM todoTask";
            return (List<TodoTask>)db.Query<TodoTask>(sql);
        }

        void ITaskRepository.Remove(int id)
        {
            var sql = "DELETE FROM todoTask WHERE id=@id";
            db.Execute(sql, new { @id = id });
            
        }

        TodoTask ITaskRepository.Update(TodoTask tdTsk)
        {
            var sql = "UPDATE todoTask SET todoTask=@todoTask,done=@done WHERE id=@id";
            db.Execute(sql, tdTsk);
            return tdTsk;
        }
    }
}
