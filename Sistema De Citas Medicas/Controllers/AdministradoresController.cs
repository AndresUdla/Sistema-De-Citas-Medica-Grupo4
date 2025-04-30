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
    public class AdministradoresController : Controller
    {
        private readonly Sistema_De_Citas_MedicasContextSQLServer _context;

        public AdministradoresController(Sistema_De_Citas_MedicasContextSQLServer context)
        {
            _context = context;
        }

        // GET: Administradores
        public async Task<IActionResult> Index()
        {
            var sistema_De_Citas_MedicasContextSQLServer = _context.Administrador.Include(a => a.Usuario);
            return View(await sistema_De_Citas_MedicasContextSQLServer.ToListAsync());
        }

        // GET: Administradores/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var administrador = await _context.Administrador
                .Include(a => a.Usuario)
                .FirstOrDefaultAsync(m => m.AdministradorId == id);
            if (administrador == null)
            {
                return NotFound();
            }

            return View(administrador);
        }

        // GET: Administradores/Create
        public IActionResult Create()
        {
            ViewData["UsuarioId"] = new SelectList(_context.Set<Usuario>(), "UsuarioId", "Contrasena");
            return View();
        }

        // POST: Administradores/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AdministradorId,Nombre,Telefono,UsuarioId")] Administrador administrador)
        {
            if (ModelState.IsValid)
            {
                _context.Add(administrador);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["UsuarioId"] = new SelectList(_context.Set<Usuario>(), "UsuarioId", "Contrasena", administrador.UsuarioId);
            return View(administrador);
        }

        // GET: Administradores/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var administrador = await _context.Administrador.FindAsync(id);
            if (administrador == null)
            {
                return NotFound();
            }
            ViewData["UsuarioId"] = new SelectList(_context.Set<Usuario>(), "UsuarioId", "Contrasena", administrador.UsuarioId);
            return View(administrador);
        }

        // POST: Administradores/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("AdministradorId,Nombre,Telefono,UsuarioId")] Administrador administrador)
        {
            if (id != administrador.AdministradorId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(administrador);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AdministradorExists(administrador.AdministradorId))
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
            ViewData["UsuarioId"] = new SelectList(_context.Set<Usuario>(), "UsuarioId", "Contrasena", administrador.UsuarioId);
            return View(administrador);
        }

        // GET: Administradores/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var administrador = await _context.Administrador
                .Include(a => a.Usuario)
                .FirstOrDefaultAsync(m => m.AdministradorId == id);
            if (administrador == null)
            {
                return NotFound();
            }

            return View(administrador);
        }

        // POST: Administradores/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var administrador = await _context.Administrador.FindAsync(id);
            if (administrador != null)
            {
                _context.Administrador.Remove(administrador);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AdministradorExists(int id)
        {
            return _context.Administrador.Any(e => e.AdministradorId == id);
        }
    }
}
