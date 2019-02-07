using Microsoft.AspNetCore.Mvc.Rendering;
using Mvc02.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mvc02.ViewModel
{
    public class AddRoleVm
    {
        public IEnumerable<SelectListItem> AllAdmins { get; set; }
        public Admin Admin { get; set; }
    }
}
