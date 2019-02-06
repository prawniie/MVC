using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using ToDo.Models;

namespace ToDo.Services
{
    public class TaskRepository
    {
        private IHostingEnvironment _env;

        public TaskRepository(IHostingEnvironment env)
        {
            _env = env;
        }

        public List<Task> GetAll()
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

            return tasks.OrderByDescending(t => t.Ranking).ToList();
        }

        internal Task GetById(int id)
        {
            Task task = GetAll().Single(t => t.Id == id);
            return task;
        }

        internal void Add(Task task)
        {
            string root = _env.ContentRootPath;
            string filename = Path.Combine(root, "Data", "tasks.txt");

            int count = GetAll().Count();
            string input = $"{count + 1},{task.Name},{task.Description},{task.Ranking}\n";
            File.AppendAllText(filename, input);

        }
    }
}
