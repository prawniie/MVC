using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
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
            string[] tasks = System.IO.File.ReadAllLines(filename);

            foreach (var item in tasks)
            {
                Task task = new Task();
                string[] taskArray = tasks.Split(",");
            }

            return View();
        }
    }
}
