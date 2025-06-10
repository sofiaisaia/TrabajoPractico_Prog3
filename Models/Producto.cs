using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;


namespace CrudMVCApp.Models
{
    public class Producto
    {
        public int Id { get; set; } // Clave primaria necesaria para EF
        [Required(ErrorMessage = "El nombre del producto es obligatorio")]
        [StringLength(100, ErrorMessage = "El nombre no puede superar los 100 caracteres")]
        public required string Nombre { get; set; }
        [Required(ErrorMessage = "La descripción del producto es obligatoria")]
        [StringLength(500, ErrorMessage = "La descripción no puede superar los 500 caracteres")]
        public required string Descripcion { get; set; }
        [Required(ErrorMessage = "El precio del producto es obligatorio")]
        [Range(0.01, double.MaxValue, ErrorMessage = "El precio debe ser mayor que cero")]
        public required decimal PrecioCompra { get; set; }
        [Required(ErrorMessage = "Debe seleccionar una categoría")]
        public required double PrecioVenta { get; set; }
        public required int Stock { get; set; }

        public Producto()
        {
            // Constructor por defecto necesario para Entity Framework
        }

    }
}
