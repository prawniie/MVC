using Microsoft.AspNetCore.Mvc.Rendering;
using Mvc02.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mvc02.Models.ViewModels
{
    public class CreateProductVm
    {
        public IEnumerable<SelectListItem> AllCategories { get; set; }
        public Product Product { get; set; }
    }
}
