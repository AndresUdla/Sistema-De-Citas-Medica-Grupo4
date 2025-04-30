using Microsoft.AspNetCore.Mvc;
using Sistema_De_Citas_Medicas.Models;
using Sistema_De_Citas_Medicas.Data;
using System;
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

            // Intentar convertir el string a enum
            if (!Enum.TryParse<RolUsuario>(model.Rol, true, out var rolEnum))
            {
                ModelState.AddModelError("", "Rol inválido.");
                return View(model);
            }

            var usuario = _context.Usuario.FirstOrDefault(u =>
                u.Correo == model.Correo &&
                u.Contrasena == model.Contraseña &&
                u.Rol == rolEnum);

            if (usuario != null)
            {
                return rolEnum switch
                {
                    RolUsuario.Administrador => RedirectToAction("Index", "Usuarios"),
                    RolUsuario.Medico => RedirectToAction("Index", "Horarios"),
                    RolUsuario.Paciente => RedirectToAction("IndexCitaPaciente", "Citas"),
                    _ => View(model)
                };
            }


            ModelState.AddModelError("", "Correo, clave o rol incorrectos.");
            return View(model);
        }
    }
}
