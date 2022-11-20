using Microsoft.AspNetCore.Mvc;
using Todo_list.dal.Entities;
using Todo_list.dal;
using System.Threading.Tasks;

namespace TodoListNg.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TasksController : ControllerBase
    {
        private readonly TaskDBContext _context;

        public TasksController(TaskDBContext context)
        {
            _context = context;
        }

        //[HttpGet("/get/{id?}")]
        //public MyTask GetTaskById(int id)
        //{
        //    var resTask = _context.Tasks.FirstOrDefault(i => i.Id == id);
        //    if (resTask == null)
        //    {
        //        Response.StatusCode = 404;
        //    }
        //    return resTask;
        //}
        [HttpGet]
        public IEnumerable<MyTask> Get()
        {
            return _context.Tasks.Where(i => i.Archived == false).ToArray();
        }
        [HttpPost]
        public MyTask Post(MyTask task)
        {
            _context.Tasks.Add(task);
            _context.SaveChanges();
            return task;
        }
        [HttpPut]
        public void Put(MyTask task)
        {
            var resTask = _context.Tasks.FirstOrDefault(i => i.Id == task.Id);
            if (resTask == null)
            {
                Response.StatusCode = 404;
            }
            else
            {
                resTask.Completed = task.Completed;
                resTask.Archived = task.Archived;
            }
            _context.SaveChanges();
        }
        //[HttpPut("/update/{id?}")]
        //public void UpdateTask(int id, [FromBody] string body)
        //{
        //    var resTask = _context.Tasks.FirstOrDefault(i => i.Id == id);
        //    if (resTask == null)
        //    {
        //        Response.StatusCode = 404;
        //    }
        //    else
        //    {
        //        resTask.Body = body;
        //    }
        //    _context.SaveChanges();
        //}

        //[HttpPut("/archive/{id?}")]
        //public void ArchiveTask(int id)
        //{
        //    var resTask = _context.Tasks.FirstOrDefault(i => i.Id == id);
        //    if (resTask == null)
        //    {
        //        Response.StatusCode = 404;
        //    }
        //    else
        //    {
        //        resTask.Archived = true;
        //    }
        //    _context.SaveChanges();
        //}
        //[HttpDelete("/delete/{id?}")]
        //public void DeleteTask(int id)
        //{
        //    var resTask = _context.Tasks.FirstOrDefault(i => i.Id == id);
        //    if (resTask == null)
        //    {
        //        Response.StatusCode = 404;
        //    }
        //    else
        //    {
        //        _context.Tasks.Remove(resTask); 
        //    }
        //    _context.SaveChanges();
        //}
    }
}