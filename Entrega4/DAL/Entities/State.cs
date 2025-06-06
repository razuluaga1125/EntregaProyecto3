using System.ComponentModel.DataAnnotations;

namespace _3ra_entrega.DAL.ENTITIES
{
    public class State : AuditBase
    {

        [Display(Name = "Estado/Departamento")] // para identificar el nombre más fácil
        [MaxLength(50, ErrorMessage = "el campo {0} debe tener máximo {1} caracteres.")] // longitud
        [Required(ErrorMessage = "Este campo es obligatorio.")] // campo requerido

        public string Name { get; set; }

        //Así es como relaciono dos tablas en EF Core:
        [Display(Name = "País")]
        public Country? Country { get; set; }

        //fk
        [Display(Name = "ID País")]
        public Guid CountryId { get; set; }

    }
}