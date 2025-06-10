using System.ComponentModel.DataAnnotations;

namespace CrudMVCApp.Models
{
    public class Usuario
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El usuario es obligatorio")]
        [StringLength(50, ErrorMessage = "El usuario no puede superar los 50 caracteres")]
        public string User { get; set; } = string.Empty;

        [Required(ErrorMessage = "La clave es obligatoria")]
        [StringLength(100, ErrorMessage = "La clave no puede superar los 100 caracteres")]
        public string Clave { get; set; } = string.Empty;

        public Usuario()
        {
        }   
    }
}
