using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Mvc02.Models.Entities
{
    public class Product
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Name cannot be empty")]
        public string Name { get; set; }
        [Range(0,1000, ErrorMessage = "Price cannot be negative or higher than 1000")]
        public decimal Price { get; set; }
        public bool ForSale { get; set; }
        public Category Category { get; set; }
        public int CategoryId { get; set; }
    }
}
