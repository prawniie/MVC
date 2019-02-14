using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC02.Models.ViewModels
{
    public class CreateProductVm
    {
        public IEnumerable<SelectListItem> AllCategories { get; set; }
        public Product Product { get; set; }
    }
}
