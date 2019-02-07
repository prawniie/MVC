using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC_Repetition.Models
{
    public class Dog
    {
        public int Id { get; set; }

        [Required(ErrorMessage="Obligatoriskt")]
        [StringLength(20, ErrorMessage="Namnet måste vara mellan 0 och 20 bokstäver långt")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Obligatoriskt")]
        public string Breed { get; set; }

        public bool IsCute { get; set; }
        public Owner Owner { get; set; }
        public int OwnerId { get; set; }
    }
}
