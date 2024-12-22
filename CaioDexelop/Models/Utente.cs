using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CaioDexelop.Models
{
    public class Utente
    {
        public int Id { get; set; }
        [StringLength(50, MinimumLength = 2)]
        [Required]
        public required string Nome { get; set; }
        [StringLength(50, MinimumLength = 2)]
        [Required]
        public required string Cognome { get; set; }
        [EmailAddress]
        [Required]
        [Display(Name = "E-mail")]
        public required string Email { get; set; }
    }
}
