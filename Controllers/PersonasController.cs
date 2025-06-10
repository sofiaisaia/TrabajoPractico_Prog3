using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CrudMVCApp.Data;
using CrudMVCApp.Models;

namespace CrudMVCApp.Controllers
{
    // Este controlador se encarga de todas las operaciones CRUD para la entidad Persona.
    public class PersonasController : Controller
    {
        // Aquí guardamos el contexto de la base de datos para poder acceder a las personas.
        private readonly AppDbContext _context;

        // El constructor recibe el contexto de la base de datos (lo inyecta el sistema).
        public PersonasController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Personas
        // Muestra la lista de todas las personas guardadas en la base de datos.
        public async Task<IActionResult> Index()
        {
            return View(await _context.Persona.ToListAsync());
        }

        // GET: Personas/Details/5
        // Muestra los detalles de una persona específica, buscando por su id.
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                // Si no se pasa un id, devolvemos "no encontrado".
                return NotFound();
            }

            // Buscamos la persona con el id indicado.
            var persona = await _context.Persona
                .FirstOrDefaultAsync(m => m.Id == id);
            if (persona == null)
            {
                // Si no existe, devolvemos "no encontrado".
                return NotFound();
            }

            // Si la encontramos, mostramos la vista con los datos de la persona.
            return View(persona);
        }

        // GET: Personas/Create
        // Muestra el formulario para crear una nueva persona.
        public IActionResult Create()
        {
            // Simplemente devolvemos la vista con un objeto Persona vacío.
            return View(new Persona());
        }

        // POST: Personas/Create
        // Recibe los datos del formulario para crear una nueva persona.
        [HttpPost] //el metodo q sigue es un POST, no GET
        [ValidateAntiForgeryToken] // Protege contra ataques CSRF (Cross-Site Request Forgery).
        public async Task<IActionResult> Create([Bind("Id,Nombre,Apellido,Dni,Cuit,Futbol,Basquet,Otros,Genero")] Persona persona)
        {
            // Si los datos del formulario son válidos...
            if (ModelState.IsValid)
            {
                // ...agregamos la persona a la base de datos y guardamos los cambios.
                _context.Add(persona);
                await _context.SaveChangesAsync();
                // Después de guardar, volvemos al listado principal.
                return RedirectToAction(nameof(Index));
            }
            // Si hay algún error de validación, volvemos a mostrar el formulario con los datos ingresados.
            return View(persona);
        }

        // GET: Personas/Edit/5
        // Muestra el formulario para editar una persona existente.
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                // Si no se pasa un id, devolvemos "no encontrado".
                return NotFound();
            }

            // Buscamos la persona a editar.
            var persona = await _context.Persona.FindAsync(id);
            if (persona == null)
            {
                // Si no existe, devolvemos "no encontrado".
                return NotFound();
            }
            // Mostramos la vista de edición con los datos actuales de la persona.
            return View(persona);
        }

        // POST: Personas/Edit/5
        // Recibe los datos del formulario para actualizar una persona.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nombre,Apellido,Dni,Cuit,Futbol,Basquet,Otros,Genero")] Persona persona)
        {
            // Si el id de la URL no coincide con el de la persona, devolvemos "no encontrado".
            if (id != persona.Id)
            {
                return NotFound();
            }

            // Si los datos son válidos...
            if (ModelState.IsValid)
            {
                try
                {
                    // ...actualizamos la persona y guardamos los cambios.
                    _context.Update(persona);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    // Si la persona ya no existe, devolvemos "no encontrado".
                    if (!PersonaExists(persona.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        // Si es otro error, lo lanzamos.
                        throw;
                    }
                }
                // Volvemos al listado principal.
                return RedirectToAction(nameof(Index));
            }
            // Si hay errores de validación, volvemos a mostrar el formulario.
            return View(persona);
        }

        // GET: Personas/Delete/5
        // Muestra la confirmación para eliminar una persona.
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            // Buscamos la persona a eliminar.
            var persona = await _context.Persona
                .FirstOrDefaultAsync(m => m.Id == id);
            if (persona == null)
            {
                return NotFound();
            }

            // Mostramos la vista de confirmación.
            return View(persona);
        }

        // POST: Personas/Delete/5
        // Elimina la persona seleccionada de la base de datos.
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            // Buscamos la persona por id.
            var persona = await _context.Persona.FindAsync(id);
            if (persona != null)
            {
                // Si existe, la eliminamos.
                _context.Persona.Remove(persona);
            }

            // Guardamos los cambios en la base de datos.
            await _context.SaveChangesAsync();
            // Volvemos al listado principal.
            return RedirectToAction(nameof(Index));
        }

        // Método privado para verificar si una persona existe en la base de datos.
        private bool PersonaExists(int id)
        {
            return _context.Persona.Any(e => e.Id == id);
        }
    }
}