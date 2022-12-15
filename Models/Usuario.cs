using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

 namespace MvcClinicas.Models
{
    public class Usuario
    {
        public int Id { get; set; }

        [StringLength(60, MinimumLength = 3)]
        [Required]
        public string? Nombre { get; set; }


        //[RegularExpression(@"/^[a-zA-Z0-9.!#$%&'*+/=?^_`{|}~-]+@[a-zA-Z0-9](?:[a-zA-Z0-9-]{0,61}[a-zA-Z0-9])?(?:\.[a-zA-Z0-9](?:[a-zA-Z0-9-]{0,61}[a-zA-Z0-9])?)*$/")]
        [Required]
        [StringLength(500)]
        public string? CorreoElectronico { get; set; }

        [Required]
        [StringLength(8)]
        public string? Password { get; set; }
        
        [Required]
        [DataType(DataType.Date)]
        public DateTime FechaAlta { get; set; }


        [Required]
        public int Nivel { get; set; }

    }
}