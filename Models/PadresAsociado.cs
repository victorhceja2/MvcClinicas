using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

 namespace MvcClinicas.Models
{
    public class PadresAsociado
    {
         public int Id { get; set; }
         
         public int IdAsociado {get; set;}

        [StringLength(60, MinimumLength = 10)]
        public string? Nombre { get; set;}

        [StringLength(60, MinimumLength = 10)]
        public string? LugarNacimiento { get; set;}

        [StringLength(60, MinimumLength = 10)]
        public string? Escolaridad { get; set;}   

        public int? Edad { get; set;}     

        //Madre o Padre
        [StringLength(10, MinimumLength = 6)]  
        public string? Tipo {get; set;}

        //SI o NO
        [StringLength(1, MinimumLength = 1)]  
        public string? Parentesco {get; set;}

        //SI o NO
        [StringLength(1, MinimumLength = 1)]  

        public string? AcidoFolico {get; set;}

        public int? CitasMedicas {get; set;}

        [StringLength(15, MinimumLength = 3)]  
        public string? Seguro {get; set;}

        

    }
}