using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

 namespace MvcClinicas.Models
{
    public class PadAsoComun
    {
         public int Id { get; set; }

         public int IdPadresAsociado {get; set;}  

         public int IdAsociado {get; set;}

        [StringLength(100, MinimumLength = 10)]
        public string? Adicciones { get; set;}  

        //SI o NO
        [StringLength(1, MinimumLength = 1)]  

        public string? HijosDTN {get; set;}

        //SI o NO
        [StringLength(1, MinimumLength = 1)]  

        public string? FamiliaresDTN {get; set;}

        //SI o NO
        [StringLength(1, MinimumLength = 1)]  

        public string? ExposicionToxinas {get; set;}      

        [StringLength(100, MinimumLength = 10)]
        public string? DescripcionToxinas { get; set;}            


    }
}
