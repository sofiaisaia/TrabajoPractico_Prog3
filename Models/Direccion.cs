using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace CrudMVCApp.Models
{
    public class Direccion
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "La calle es obligatoria")]
        [StringLength(150, ErrorMessage = "La calle no puede superar los 150 caracteres")]
        public required string Calle { get; set; }

        [Required(ErrorMessage = "La ciudad es obligatoria")]
        [StringLength(150, ErrorMessage = "La ciudad no puede superar los 150 caracteres")]
        public required string Ciudad { get; set; }

        [Required(ErrorMessage = "El código postal es obligatorio")]
        [RegularExpression(@"^\d{4,5}$", ErrorMessage = "El código postal debe tener 4 o 5 dígitos")]
        public required string CodigoPostal { get; set; }

        [Required(ErrorMessage = "Debe seleccionar una persona")]
        public int PersonaId { get; set; }

        [ValidateNever]
        public Persona? Persona { get; set; }
    }
}