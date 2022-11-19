using Microsoft.AspNetCore.Mvc;
using Todo_list.dal.Entities;
using Todo_list.dal;

namespace Todo_list.api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HomeController : ControllerBase
    {
        private readonly TaskDBContext _context;

        public HomeController(TaskDBContext context)
        {
            _context = context;
        }

        [HttpGet("/get/{id?}")]
        public MyTask GetTaskById(int id)
        {
            var resTask = _context.Tasks.FirstOrDefault(i => i.Id == id);
            if (resTask == null)
            {
                Response.StatusCode = 404;
            }
            return resTask;
        }
        [HttpGet("/get")]
        public IEnumerable<MyTask> GetTasks()
        {
            return _context.Tasks.ToArray();
        }
        [HttpPost("/create")]
        public void CreateTask([FromBody] string body)
        {
            _context.Tasks.Add(new MyTask() { Body = body });
            _context.SaveChanges();
        }
        [HttpPut("/update/{id?}")]
        public void UpdateTask(int id, [FromBody] string body)
        {
            var resTask = _context.Tasks.FirstOrDefault(i => i.Id == id);
            if (resTask == null)
            {
                Response.StatusCode = 404;
            }
            else
            {
                resTask.Body = body;
            }
            _context.SaveChanges();
        }
        [HttpPut("/complete/{id?}")]
        public void CompleteTask(int id)
        {
            var resTask = _context.Tasks.FirstOrDefault(i => i.Id == id);
            if (resTask == null)
            {
                Response.StatusCode = 404;
            }
            else
            {
                resTask.Completed = true;
            }
            _context.SaveChanges();
        }
        [HttpPut("/archive/{id?}")]
        public void ArchiveTask(int id)
        {
            var resTask = _context.Tasks.FirstOrDefault(i => i.Id == id);
            if (resTask == null)
            {
                Response.StatusCode = 404;
            }
            else
            {
                resTask.Archived = true;
            }
            _context.SaveChanges();
        }
        [HttpDelete("/delete/{id?}")]
        public void DeleteTask(int id)
        {
            var resTask = _context.Tasks.FirstOrDefault(i => i.Id == id);
            if (resTask == null)
            {
                Response.StatusCode = 404;
            }
            else
            {
                _context.Tasks.Remove(resTask); 
            }
            _context.SaveChanges();
        }
    }
}