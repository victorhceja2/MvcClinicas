using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

 namespace MvcClinicas.Models
{
    public class PadecimientoAsociado
    {
         public int Id { get; set; }
         
         public int IdAsociado {get; set;}

        [StringLength(100, MinimumLength = 10)]
        public string? Padecimiento { get; set;}   

        [StringLength(60, MinimumLength = 4)]
        public string? Hospital { get; set;}  

        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Fecha de Registro")]
        public DateTime FechaRegistro { get; set; }

        //SI o NO
        [StringLength(2, MinimumLength = 2)]  
         public string? Valvula {get; set;}
                 
        [StringLength(10, MinimumLength = 2)]  
         public string? Sangre {get; set;}

        [StringLength(100, MinimumLength = 10)]
        public string? Notas { get; set;}              







    }
}