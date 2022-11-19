using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Microsoft.EntityFrameworkCore;
using Todo_list.dal;
using Todo_list.dal.Entities;
using Todo_list.Models;
using System.Net;

namespace Todo_list.Controllers
{
    public class HomeController : Controller
    {
        private readonly HomeHelper _helper;

        public HomeController(TaskDBContext context)
        {
            _helper = new HomeHelper(context);
        }

        public IActionResult Index()
        {
            return View(_helper.GetTasks());
        }
        [HttpPost]
        public PartialViewResult AddTask(MyTask task)
        {
            _helper.AddTask(task);
            return PartialView("List", _helper.GetTasks());
        }
        [HttpPost]
        public PartialViewResult UpdateCompleted(bool completed, int id)
        {
            _helper.Update(completed, id);
            Response.StatusCode = (int)HttpStatusCode.OK;
            return PartialView("List", _helper.GetTasks());
        }
        [HttpPost]
        public PartialViewResult Archive(int id)
        {
            _helper.Archive(id);
            Response.StatusCode = (int)HttpStatusCode.OK;
            return PartialView("List", _helper.GetTasks());
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}