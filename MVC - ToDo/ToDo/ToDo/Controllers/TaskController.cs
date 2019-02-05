using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.IO;
using ToDo.Models;

namespace ToDo.Controllers
{
    public class TaskController : Controller
    {
        public IHostingEnvironment _env;

        public TaskController(IHostingEnvironment env)
        {
            _env = env;
        }

        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            string root = _env.ContentRootPath;
            string filename = Path.Combine(root, "Data", "tasks.txt");
            string[] taskArray = System.IO.File.ReadAllLines(filename);

            List<Task> tasks = new List<Task>();

            foreach (var item in taskArray)
            {
                Task task = new Task();
                string[] eachTaskArray = item.Split(",");
                task.Id = int.Parse(eachTaskArray[0]);
                task.Name = eachTaskArray[1];
                task.Description = eachTaskArray[2];
                task.Ranking = int.Parse(eachTaskArray[3]);
                tasks.Add(task);
            }

            return View(tasks);
        }
    }
}
