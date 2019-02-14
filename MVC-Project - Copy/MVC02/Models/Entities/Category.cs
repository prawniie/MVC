using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC02.Models.Entities
{
    public class Category
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "You must enter a Name!")]
        public string Name { get; set; }
        [Required(ErrorMessage = "You must enter a description!")]
        public string Description { get; set; }
    }
}
