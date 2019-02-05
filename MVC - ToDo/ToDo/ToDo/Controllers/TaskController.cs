using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.IO;
using ToDo.Models;
using ToDo.Services;

namespace ToDo.Controllers
{
    public class TaskController : Controller
    {
        private TaskRepository _repo;

        public TaskController(TaskRepository repo)
        {
            _repo = repo;
        }

        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            List<Task> tasks = _repo.GetAll();

            return View(tasks);
        }
    }
}
