using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Mvc02.Models.Entities
{
    public class Admin
    {
        public int Id { get; set; }

        [EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessage = "Obligatoriskt")]
        public string Role { get; set; }
    }
}
