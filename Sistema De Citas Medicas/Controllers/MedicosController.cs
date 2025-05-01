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
    public class MedicosController : Controller
    {
        private readonly Sistema_De_Citas_MedicasContextSQLServer _context;

        public MedicosController(Sistema_De_Citas_MedicasContextSQLServer context)
        {
            _context = context;
        }

        // GET: Medicos
        public async Task<IActionResult> Index()
        {
            var sistema_De_Citas_MedicasContextSQLServer = _context.Medico.Include(m => m.Usuario);
            return View(await sistema_De_Citas_MedicasContextSQLServer.ToListAsync());
        }

        // GET: Medicos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var medico = await _context.Medico
                .Include(m => m.Usuario)
                .FirstOrDefaultAsync(m => m.MedicoId == id);
            if (medico == null)
            {
                return NotFound();
            }

            return View(medico);
        }

        // GET: Medicos/Create
        public IActionResult Create()
        {
            ViewBag.UsuarioId = new SelectList(
                _context.Usuario
                    .Where(u => u.Rol == RolUsuario.Medico) // Filtrar solo usuarios con rol "Medico"
                    .Select(u => new { u.UsuarioId }), // Solo mostrar el UsuarioId
                "UsuarioId", // Valor del select
                "UsuarioId" // Texto visible en el select
            );

            return View();
        }

        // POST: Medicos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Medico medico)
        {
            // Validar que el UsuarioId corresponde a un usuario con rol "Medico"
            if (!_context.Usuario.Any(u => u.UsuarioId == medico.UsuarioId && u.Rol == RolUsuario.Medico))
            {
                ModelState.AddModelError("UsuarioId", "El Usuario seleccionado no es válido para un Médico.");
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Medico.Add(medico);
                    _context.SaveChanges();
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError(string.Empty, "Ocurrió un error al guardar el médico: " + ex.Message);
                }
            }

            // Volver a llenar el ViewBag en caso de error
            ViewBag.UsuarioId = new SelectList(
                _context.Usuario
                    .Where(u => u.Rol == RolUsuario.Medico)
                    .Select(u => new { u.UsuarioId }),
                "UsuarioId",
                "UsuarioId",
                medico?.UsuarioId
            );

            return View(medico);
        }

        // GET: Medicos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var medico = await _context.Medico.FindAsync(id);
            if (medico == null)
            {
                return NotFound();
            }
            ViewData["UsuarioId"] = new SelectList(_context.Usuario, "UsuarioId", "Contrasena", medico.UsuarioId);
            return View(medico);
        }

        // POST: Medicos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MedicoId,Nombre,Especialidad,Telefono,UbicacionConsultorio,UsuarioId")] Medico medico)
        {
            if (id != medico.MedicoId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(medico);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MedicoExists(medico.MedicoId))
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
            ViewData["UsuarioId"] = new SelectList(_context.Usuario, "UsuarioId", "Contrasena", medico.UsuarioId);
            return View(medico);
        }

        // GET: Medicos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var medico = await _context.Medico
                .Include(m => m.Usuario)
                .FirstOrDefaultAsync(m => m.MedicoId == id);
            if (medico == null)
            {
                return NotFound();
            }

            return View(medico);
        }

        // POST: Medicos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var medico = await _context.Medico.FindAsync(id);
            if (medico != null)
            {
                _context.Medico.Remove(medico);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MedicoExists(int id)
        {
            return _context.Medico.Any(e => e.MedicoId == id);
        }
    }
}
