using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MVC02.Models.ViewModels
{
    public class ContactVm
    {
        [Required(ErrorMessage = "Du måste ett namn.")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Du måste ange en email.")]
        [EmailAddress(ErrorMessage = "Du har ej angett en korrekt email.")]
        public string Email { get; set; }
        public string Subject { get; set; }
        [Required(ErrorMessage = "Du måste ange meddelande.")]
        public string Message { get; set; }

    }
}
