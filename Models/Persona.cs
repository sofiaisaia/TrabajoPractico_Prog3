using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace CrudMVCApp.Models
{
    public class Persona
    {
        public int Id { get; set; } // Clave primaria necesaria para EF

        [Required(ErrorMessage = "El nombre es obligatorio")]
        [StringLength(100, ErrorMessage = "El nombre no puede superar los 100 caracteres")]
        public string Nombre { get; set; } = string.Empty;

        [Required(ErrorMessage = "El apellido es obligatorio")]
        [StringLength(100, ErrorMessage = "El apellido no puede superar los 100 caracteres")]
        public string Apellido { get; set; } = string.Empty;

        [Required(ErrorMessage = "El DNI es obligatorio")]
        [Range(1000000, 99999999, ErrorMessage = "El DNI debe tener entre 7 y 8 dígitos")]
        public int Dni { get; set; }

        [Required(ErrorMessage = "El CUIT es obligatorio")]
        [RegularExpression(@"^\d{2}-\d{8}-\d{1}$", ErrorMessage = "El CUIT debe tener el formato 00-00000000-0")]
        [StringLength(13, ErrorMessage = "El CUIT debe tener 13 caracteres incluyendo los guiones")]
        public string Cuit { get; set; } = string.Empty;

        public bool Futbol { get; set; }
        public bool Basquet { get; set; }
        public bool Otros { get; set; }

        [Required(ErrorMessage = "El género es obligatorio")]
        public char Genero { get; set; }

        // Propiedad de navegación
        [ValidateNever]
        public ICollection<Direccion> Direcciones { get; set; } = new List<Direccion>();

        public Persona() { }
        public Persona(int id, string nombre, string apellido, int dni, string cuit,
                       bool futbol, bool basquet, bool otros, char genero)
        {
            this.Id = id;
            this.Nombre = nombre;
            this.Apellido = apellido;
            this.Dni = dni;
            this.Cuit = cuit;
            this.Futbol = futbol;
            this.Basquet = basquet;
            this.Otros = otros;
            this.Genero = genero;
        }
    }
}