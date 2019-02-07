using Microsoft.AspNetCore.Mvc.Rendering;
using MVC_Repetition.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC_Repetition.Views.ViewModels
{
    public class AddOwnerToDogVm
    {
        public List<SelectListItem> AllOwners { get; set; }
        public Dog Dog { get; set; }
    }
}
