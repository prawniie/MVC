using MVC02.Models.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC02.Models
{
    public class Product
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Du måste ange ett namn!")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Du måste ange ett pris!")]
        [Range(0, 1000, ErrorMessage = "Du måste ange ett värde mellan 0 och 1000")]
        public double Price { get; set; }
        
        public bool ForSale { get; set; }

        [Required(ErrorMessage = "Du måste ange lagerstatus!")]
        [Range(0, 1000, ErrorMessage = "Du måste ange ett värde mellan 0 och 1000")]
        public int Stock { get; set; }

        public int CategoryId { get; set; }
        public Category Category{ get; set; }
    }
}
