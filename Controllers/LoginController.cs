using Microsoft.AspNetCore.Mvc;
using CrudMVCApp.Data;
using CrudMVCApp.Models;
using System.Linq;
using Microsoft.AspNetCore.Session;
using System.Web.Providers.Entities;

namespace CrudMVCApp.Controllers
{
    public class LoginController : Controller
    {
        private readonly AppDbContext _context;

        public LoginController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Login
        public IActionResult Login()
        {
            return View();
        }

        // POST: Login
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Login(string user, string clave)
        {
            var usuario = _context.Usuario.FirstOrDefault(u => u.User == user && u.Clave == clave);
            if (usuario != null)
            {
                HttpContext.Session.SetString("Usuario", usuario.User); // Correctly set session value
                return RedirectToAction("Index", "Home");
            }
            ViewBag.Error = "Usuario o clave incorrectos";
            return View();
        }

        public ActionResult logout ()
        {
            Session.clear();
            return RedirectToAction("Login");
        }
    }
}