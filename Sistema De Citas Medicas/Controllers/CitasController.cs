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
    public class CitasController : Controller
    {
        private readonly Sistema_De_Citas_MedicasContextSQLServer _context;

        public CitasController(Sistema_De_Citas_MedicasContextSQLServer context)
        {
            _context = context;
        }

        // GET: Citas
        public async Task<IActionResult> Index()
        {
            ViewData["ActiveTab"] = "Citas";
            var citas = _context.Cita.Include(c => c.Horario).Include(c => c.Medico).Include(c => c.Paciente);
            return View(await citas.ToListAsync());
        }


        // GET: Citas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cita = await _context.Cita
                .Include(c => c.Horario)
                .Include(c => c.Medico)
                .Include(c => c.Paciente)
                .FirstOrDefaultAsync(m => m.CitaId == id);
            if (cita == null)
            {
                return NotFound();
            }

            return View(cita);
        }

        // GET: Citas/Create
        public IActionResult Create()
        {
            ViewData["HorarioId"] = new SelectList(_context.Set<Horario>(), "HorarioId", "HorarioId");
            ViewData["MedicoId"] = new SelectList(_context.Set<Medico>(), "MedicoId", "Especialidad");
            ViewData["PacienteId"] = new SelectList(_context.Set<Paciente>(), "PacienteId", "Apellidos");
            return View();
        }

        // POST: Citas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CitaId,FechaCita,PacienteId,MedicoId,HorarioId,FechaCreacion")] Cita cita)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cita);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["HorarioId"] = new SelectList(_context.Set<Horario>(), "HorarioId", "HorarioId", cita.HorarioId);
            ViewData["MedicoId"] = new SelectList(_context.Set<Medico>(), "MedicoId", "Especialidad", cita.MedicoId);
            ViewData["PacienteId"] = new SelectList(_context.Set<Paciente>(), "PacienteId", "Apellidos", cita.PacienteId);
            return View(cita);
        }

        // GET: Citas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cita = await _context.Cita.FindAsync(id);
            if (cita == null)
            {
                return NotFound();
            }
            ViewData["HorarioId"] = new SelectList(_context.Set<Horario>(), "HorarioId", "HorarioId", cita.HorarioId);
            ViewData["MedicoId"] = new SelectList(_context.Set<Medico>(), "MedicoId", "Especialidad", cita.MedicoId);
            ViewData["PacienteId"] = new SelectList(_context.Set<Paciente>(), "PacienteId", "Apellidos", cita.PacienteId);
            return View(cita);
        }

        // POST: Citas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CitaId,FechaCita,PacienteId,MedicoId,HorarioId,FechaCreacion")] Cita cita)
        {
            if (id != cita.CitaId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cita);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CitaExists(cita.CitaId))
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
            ViewData["HorarioId"] = new SelectList(_context.Set<Horario>(), "HorarioId", "HorarioId", cita.HorarioId);
            ViewData["MedicoId"] = new SelectList(_context.Set<Medico>(), "MedicoId", "Especialidad", cita.MedicoId);
            ViewData["PacienteId"] = new SelectList(_context.Set<Paciente>(), "PacienteId", "Apellidos", cita.PacienteId);
            return View(cita);
        }

        // GET: Citas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cita = await _context.Cita
                .Include(c => c.Horario)
                .Include(c => c.Medico)
                .Include(c => c.Paciente)
                .FirstOrDefaultAsync(m => m.CitaId == id);
            if (cita == null)
            {
                return NotFound();
            }

            return View(cita);
        }

        // POST: Citas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var cita = await _context.Cita.FindAsync(id);
            if (cita != null)
            {
                _context.Cita.Remove(cita);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CitaExists(int id)
        {
            return _context.Cita.Any(e => e.CitaId == id);
        }
    }
}
