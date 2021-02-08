using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CRUD_API.Model;
using CRUD_API.Repository;

namespace CRUD_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoController : ControllerBase
    {
        private readonly ITaskRepository _tskRepo;

        public TodoController(ITaskRepository tskRepo)
        {
            _tskRepo = tskRepo;
        }

        // get request api/Todo
        [HttpGet]
        public ActionResult<IEnumerable<TodoTask>> GettodoTask()
        {
            return  _tskRepo.GetAll();
        }

        [HttpPost]
        //post request api/Todo
        public ActionResult<TodoTask> PostTodoTask(TodoTask tdTsk)
        {
            _tskRepo.Add(tdTsk);
            return tdTsk;
        }


        //delete request api/Todo/{id}
        [HttpDelete("{id}")]
        public IActionResult DeleteTodoTask(int id)
        {
            _tskRepo.Remove(id);

            return NoContent();
        }

        [HttpPut]
        public IActionResult UpdateTodoTask(TodoTask tdtsk)
        {
            _tskRepo.Update(tdtsk);

            return NoContent();
        }
    }
}
