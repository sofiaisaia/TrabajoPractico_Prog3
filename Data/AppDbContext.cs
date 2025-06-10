using CrudMVCApp.Models;
using Microsoft.EntityFrameworkCore;

namespace CrudMVCApp.Data
{
    // Contexto principal de la base de datos para la aplicación
    // Hereda de DbContext y gestiona las entidades y su mapeo a la base de datos
    public class AppDbContext : DbContext
    {
        public AppDbContext()
        {
        }

        // Constructor que recibe las opciones de configuración del contexto
        public AppDbContext(DbContextOptions<AppDbContext> options)
             : base(options)
        {
        }

        // DbSet que representa la tabla de Personas en la base de datos
        // Permite realizar consultas y operaciones CRUD sobre la entidad Persona
        public DbSet<Persona> Persona { get; set; }

        // DbSet que representa la tabla de Direcciones en la base de datos
        // Permite realizar consultas y operaciones CRUD sobre la entidad Direccion
        public DbSet<Direccion> Direccion { get; set; }
        public DbSet<Producto> Producto { get; set; }
        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<Producto> Productos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configuración de la relación uno a muchos entre Persona y Direccion
            modelBuilder.Entity<Persona>()
                .HasMany(p => p.Direcciones) // Una persona puede tener muchas direcciones
                .WithOne(d => d.Persona)      // Cada dirección pertenece a una persona
                .HasForeignKey(d => d.PersonaId); // Clave foránea en Direccion que referencia a Persona
        }
    }
}