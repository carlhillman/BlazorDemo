using System.ComponentModel.DataAnnotations;

namespace BlazorDemo.UI.Models
{
    public class DisplayPet
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Fältet får inte vara tomt")]
        [StringLength(20, ErrorMessage = "Namnet är för långt")]
        [MinLength(2, ErrorMessage = "Namnet är för kort")]
        public string Name { get; set; }
        public string Species { get; set; }
        //[Required(ErrorMessage = "Fältet får inte vara tomt")]
        //[EmailAddress]
        //public int PersonId { get; set; }
    }
}
