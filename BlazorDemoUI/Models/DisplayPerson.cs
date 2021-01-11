using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorDemo.UI.Models
{
    public class DisplayPerson
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Fältet får inte vara tomt")]
        [StringLength(20, ErrorMessage = "Förnamnet är för långt")]
        [MinLength(2, ErrorMessage = "Förnamnet är för kort")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Fältet får inte vara tomt")]
        [StringLength(40, ErrorMessage = "Förnamnet är för långt")]
        [MinLength(2, ErrorMessage = "Förnamnet är för kort")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "Fältet får inte vara tomt")]
        [EmailAddress]
        public string EmailAddress { get; set; }
    }
}
