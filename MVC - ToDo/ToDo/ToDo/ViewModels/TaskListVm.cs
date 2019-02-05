using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ToDo.Models;

namespace ToDo.ViewModels
{
    public class TaskListVm
    {
        public List<SelectListItem> AllTasks { get; set; }
        public Task Task { get; set; }
    }
}
