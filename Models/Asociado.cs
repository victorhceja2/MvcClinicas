using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

 namespace MvcClinicas.Models
{
    public class Asociado
    {
         public int Id { get; set; }

        [StringLength(10, MinimumLength = 3)]
        [Required]
        [Display(Name = "Credencial")]
        public string?FolioCredencial {get; set;}

        [StringLength(60, MinimumLength = 3)]
        [Required]
        public string? Nombre { get; set;}

        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Fecha de alta")]
        public DateTime FechaAlta { get; set; }

        [StringLength(1, MinimumLength = 1)]
        [Required]
        public string? Sexo { get; set;}

        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Fecha de nacimiento")]
        public DateTime FechaNacimiento { get; set; }  

        [Required]
        public int? Edad { get; set; }

        [StringLength(60, MinimumLength = 3)]
        [Required]
        [Display(Name = "Nombre del padre")]
        public string? NombrePadre { get; set;}

        [StringLength(60, MinimumLength = 3)]
        [Required]
        [Display(Name = "Nombre de la madre")]
        public string? NombreMadre { get; set;}

        [StringLength(100, MinimumLength = 3)]
        [Required]
        public string? Direccion { get; set;}

        [StringLength(100, MinimumLength = 3)]
        [Required]
        public string? Ciudad { get; set;}

        [StringLength(100, MinimumLength = 3)]
        [Required]
        public string? Estado { get; set;}  
        [StringLength(100, MinimumLength = 3)]
        [Required]
        public string? Pais { get; set;}        

        [StringLength(10, MinimumLength = 3)]
        [Required]
        [Display(Name = "Codigo Postal")]
        public string? CP { get; set;}  

        [StringLength(15, MinimumLength = 3)]
        [Required]
        [Display(Name = "Telefono 1")]
        public string? Telefono1 { get; set;} 

        [StringLength(15, MinimumLength = 3)]
        [Required]
        [Display(Name = "Telefono 2")]
        public string? Telefono2 { get; set;} 

        [StringLength(15, MinimumLength = 3)]
        [Required]
        [Display(Name = "Telefono 3")]
        public string? Telefono3 { get; set;} 

        [StringLength(15, MinimumLength = 3)]
        [Required]
        [Display(Name = "Telefono 4")]
        public string? Telefono4 { get; set;}                 

        //[RegularExpression(@"/^[a-zA-Z0-9.!#$%&'*+/=?^_`{|}~-]+@[a-zA-Z0-9](?:[a-zA-Z0-9-]{0,61}[a-zA-Z0-9])?(?:\.[a-zA-Z0-9](?:[a-zA-Z0-9-]{0,61}[a-zA-Z0-9])?)*$/")]
        [Required]
        [StringLength(500)]
        [Display(Name = "Correo Electrónico")]
        public string? CorreoElectronico { get; set; }

        [StringLength(500, MinimumLength = 3)]
        [Required]
        public string? Emergencias { get; set;}   




        [Column(TypeName = "nvarchar(600)")]
        [Display(Name = "Nombre de imagen")]
        public string ImageName { get; set; }        

        [NotMapped]
        [Display(Name = "Imagen a cargar")]
        public IFormFile? ImageFile { get; set; }

        [Required]
        public int Activo { get; set; }

    }
}