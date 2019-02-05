using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using ToDo.Models;
using ToDo.Services;
using ToDo.ViewModels;

namespace ToDo.Controllers
{
    public class TaskController : Controller
    {
        private TaskRepository _repo;

        public TaskController(TaskRepository repo)
        {
            _repo = repo;
        }

        public IActionResult GetAll()
        {
            List<Task> tasks = _repo.GetAll();

            return View(tasks);
        }

        public IActionResult GetById(int id)
        {
            Task task = _repo.GetById(id);
            return View(task);
        }

        public IActionResult Index()
        {
            var vm = new TaskListVm();
            var list = new List<SelectListItem>();
            var tasks = _repo.GetAll();

            list = tasks.Select(x => new SelectListItem() { Value = x.Id.ToString(), Text = x.Name }).ToList();

            vm.AllTasks = list;
            return View(vm);
        }
    }
}
