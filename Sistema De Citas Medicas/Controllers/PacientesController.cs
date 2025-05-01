using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Sistema_De_Citas_Medicas.Data;
using Sistema_De_Citas_Medicas.Models;

namespace Sistema_De_Citas_Medicas.Controllers
{
    public class PacientesController : Controller
    {
        private readonly Sistema_De_Citas_MedicasContextSQLServer _context;

        public PacientesController(Sistema_De_Citas_MedicasContextSQLServer context)
        {
            _context = context;
        }

        // GET: Pacientes
        public IActionResult Index()
        {
            var pacientes = _context.Paciente.Include(p => p.Usuario).ToList();
            return View(pacientes);
        }

        // GET: Pacientes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var paciente = await _context.Paciente
                .Include(p => p.Usuario)
                .FirstOrDefaultAsync(m => m.PacienteId == id);

            if (paciente == null)
            {
                return NotFound();
            }

            return View(paciente);
        }

        // GET: Pacientes/Create
        public IActionResult Create()
        {
            ViewBag.UsuarioId = new SelectList(
                _context.Usuario
                    .Where(u => u.Rol == RolUsuario.Paciente) // Filtrar solo usuarios con rol "Paciente"
                    .Select(u => new { u.UsuarioId }), // Solo mostrar el UsuarioId
                "UsuarioId", // Valor del select
                "UsuarioId" // Texto visible en el select
            );

            return View();
        }

        // POST: Pacientes/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Paciente paciente)
        {
            // Validar que el UsuarioId corresponde a un usuario con rol "Paciente"
            if (!_context.Usuario.Any(u => u.UsuarioId == paciente.UsuarioId && u.Rol == RolUsuario.Paciente))
            {
                ModelState.AddModelError("UsuarioId", "El Usuario seleccionado no es válido para un Paciente.");
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Paciente.Add(paciente);
                    _context.SaveChanges();
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError(string.Empty, "Ocurrió un error al guardar el paciente: " + ex.Message);
                }
            }

            // Volver a llenar el ViewBag en caso de error
            ViewBag.UsuarioId = new SelectList(
                _context.Usuario
                    .Where(u => u.Rol == RolUsuario.Paciente)
                    .Select(u => new { u.UsuarioId }),
                "UsuarioId",
                "UsuarioId",
                paciente?.UsuarioId
            );

            return View(paciente);
        }





        // GET: Pacientes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var paciente = await _context.Paciente.FindAsync(id);
            if (paciente == null)
            {
                return NotFound();
            }

            ViewBag.UsuarioId = new SelectList(
                _context.Usuario
                    .Where(u => u.Rol == RolUsuario.Paciente)
                    .Select(u => new { u.UsuarioId, u.Correo }),
                "UsuarioId",
                "Correo",
                paciente.UsuarioId
            );

            return View(paciente);
        }

        // POST: Pacientes/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PacienteId,Nombres,Apellidos,Cedula,Edad,Altura,Peso,Direccion,Telefono,UsuarioId")] Paciente paciente)
        {
            if (id != paciente.PacienteId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(paciente);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PacienteExists(paciente.PacienteId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }

            ViewBag.UsuarioId = new SelectList(
                _context.Usuario
                    .Where(u => u.Rol == RolUsuario.Paciente)
                    .Select(u => new { u.UsuarioId, u.Correo }),
                "UsuarioId",
                "Correo",
                paciente?.UsuarioId
            );


            return View(paciente);
        }

        // GET: Pacientes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var paciente = await _context.Paciente
                .Include(p => p.Usuario)
                .FirstOrDefaultAsync(m => m.PacienteId == id);

            if (paciente == null)
            {
                return NotFound();
            }

            return View(paciente);
        }

        // POST: Pacientes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var paciente = await _context.Paciente.FindAsync(id);
            if (paciente != null)
            {
                _context.Paciente.Remove(paciente);
                await _context.SaveChangesAsync();
            }

            return RedirectToAction(nameof(Index));
        }

        private bool PacienteExists(int id)
        {
            return _context.Paciente.Any(e => e.PacienteId == id);
        }
    }
}
