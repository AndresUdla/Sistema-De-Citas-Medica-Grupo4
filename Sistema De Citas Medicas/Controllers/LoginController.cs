using Microsoft.AspNetCore.Mvc;
using Sistema_De_Citas_Medicas.Models;
using Sistema_De_Citas_Medicas.Data; // Asegúrate que esta sea tu ruta real
using System.Linq;

namespace Sistema_De_Citas_Medicas.Controllers
{
    public class LoginController : Controller
    {
        private readonly Sistema_De_Citas_MedicasContextSQLServer _context;

        public LoginController(Sistema_De_Citas_MedicasContextSQLServer context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(LoginViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var usuario = _context.Usuario.FirstOrDefault(u =>
                u.Correo == model.Email &&  
                u.Contrasena == model.Password &&  
                u.Rol.ToString().ToLower() == model.Rol.ToLower());  

            if (usuario != null)
            {
                if (usuario.Rol == RolUsuario.Paciente)
                    return RedirectToAction("Dashboard", "Paciente");
                else if (usuario.Rol == RolUsuario.Medico)
                    return RedirectToAction("Dashboard", "Medico");
                else if (usuario.Rol == RolUsuario.Administrador)
                    return RedirectToAction("Dashboard", "Administrador");
            }

            ModelState.AddModelError("", "Correo, clave o rol incorrectos.");
            return View(model);
        }

    }
}