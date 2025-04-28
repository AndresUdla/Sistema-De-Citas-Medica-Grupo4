using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Sistema_De_Citas_Medicas.Models;

namespace Sistema_De_Citas_Medicas.Controllers
{
    public class HistorialMedicoesController : Controller
    {
        private readonly Sistema_De_Citas_MedicasContextSQLServer _context;

        public HistorialMedicoesController(Sistema_De_Citas_MedicasContextSQLServer context)
        {
            _context = context;
        }

        // GET: HistorialMedicoes
        public async Task<IActionResult> Index()
        {
            var sistema_De_Citas_MedicasContextSQLServer = _context.HistorialMedico.Include(h => h.Cita);
            return View(await sistema_De_Citas_MedicasContextSQLServer.ToListAsync());
        }

        // GET: HistorialMedicoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var historialMedico = await _context.HistorialMedico
                .Include(h => h.Cita)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (historialMedico == null)
            {
                return NotFound();
            }

            return View(historialMedico);
        }

        // GET: HistorialMedicoes/Create
        public IActionResult Create()
        {
            ViewData["CitaId"] = new SelectList(_context.Set<Cita>(), "Id", "Estado");
            return View();
        }

        // POST: HistorialMedicoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Diagnostico,Tratamiento,Observaciones,CitaId")] HistorialMedico historialMedico)
        {
            if (ModelState.IsValid)
            {
                _context.Add(historialMedico);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CitaId"] = new SelectList(_context.Set<Cita>(), "Id", "Estado", historialMedico.CitaId);
            return View(historialMedico);
        }

        // GET: HistorialMedicoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var historialMedico = await _context.HistorialMedico.FindAsync(id);
            if (historialMedico == null)
            {
                return NotFound();
            }
            ViewData["CitaId"] = new SelectList(_context.Set<Cita>(), "Id", "Estado", historialMedico.CitaId);
            return View(historialMedico);
        }

        // POST: HistorialMedicoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Diagnostico,Tratamiento,Observaciones,CitaId")] HistorialMedico historialMedico)
        {
            if (id != historialMedico.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(historialMedico);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HistorialMedicoExists(historialMedico.Id))
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
            ViewData["CitaId"] = new SelectList(_context.Set<Cita>(), "Id", "Estado", historialMedico.CitaId);
            return View(historialMedico);
        }

        // GET: HistorialMedicoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var historialMedico = await _context.HistorialMedico
                .Include(h => h.Cita)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (historialMedico == null)
            {
                return NotFound();
            }

            return View(historialMedico);
        }

        // POST: HistorialMedicoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var historialMedico = await _context.HistorialMedico.FindAsync(id);
            if (historialMedico != null)
            {
                _context.HistorialMedico.Remove(historialMedico);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool HistorialMedicoExists(int id)
        {
            return _context.HistorialMedico.Any(e => e.Id == id);
        }
    }
}
