using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

 namespace MvcClinicas.Models
{
    public class Login
    {
        public int Id { get; set; }

        [Required]
        public int Id_Usuario {get; set;}

        [Required]
        [StringLength(50, MinimumLength = 3)]
        public string? Usuario { get; set; }

        [Required]
        [StringLength(15, MinimumLength = 3)]
        public string? Password { get; set; }

        
        [DataType(DataType.Date)]
        public DateTime FechaLogin { get; set; }

        [DataType(DataType.Date)]
        public DateTime? FechaLogout { get; set; }

        
        
        public int? Nivel { get; set; }
    }
}