using Microsoft.AspNetCore.Mvc;
using Sistema_De_Citas_Medicas.Models;

namespace Sistema_De_Citas_Medicas.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                // Aquí puedes validar las credenciales del usuario
                // Ejemplo: Buscar en la base de datos
                var usuario = /* Lógica para buscar el usuario en la base de datos */;
                if (usuario != null && usuario.Contrasena == model.Contrasena)
                {
                    // Autenticar al usuario
                    return RedirectToAction("Index", "Home");
                }

                ModelState.AddModelError(string.Empty, "Correo o contraseña incorrectos.");
            }

            return View(model);
        }

        public IActionResult Logout()
        {
            // Lógica para cerrar sesión
            return RedirectToAction("Login");
        }
    }
}
