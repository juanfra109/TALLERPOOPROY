using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TALLERPOON.Models.dbModels;
using TALLERPOON.Dto;


namespace TALLERPOON.Controllers
{
    public class DetalleeasController : Controller
    {
        private readonly ProyectofarmContext _context;

        public DetalleeasController(ProyectofarmContext context)
        {
            _context = context;
        }

        // GET: Detalleeas
        public async Task<IActionResult> Index()
        {
            var proyectofarmContext = _context.Detalleeas.Include(d => d.IdAlmNavigation).Include(d => d.IdEmplNavigation);
            return View(await proyectofarmContext.ToListAsync());
        }

        // GET: Detalleeas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Detalleeas == null)
            {
                return NotFound();
            }

            var detalleea = await _context.Detalleeas
                .Include(d => d.IdAlmNavigation)
                .Include(d => d.IdEmplNavigation)
                .FirstOrDefaultAsync(m => m.IdDetalleEa == id);
            if (detalleea == null)
            {
                return NotFound();
            }

            return View(detalleea);
        }

        // GET: Detalleeas/Create
        public IActionResult Create()
        {
            ViewData["IdAlm"] = new SelectList(_context.Almacens, "IdAlm", "IdAlm");
            ViewData["IdEmpl"] = new SelectList(_context.Empleados, "IdEmpl", "IdEmpl");
            return View();
        }

        // POST: Detalleeas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(DetalleEACreate DetalleEA)
        {
            if (ModelState.IsValid)
            {
                Detalleea detalleeanu = new Detalleea();
                detalleeanu.IdDetalleEa = DetalleEA.IdDetalleEa;
                detalleeanu.IdEmpl = DetalleEA.IdEmpl;
                detalleeanu.FechaDetalleEa = DetalleEA.FechaDetalleEa;
                detalleeanu.IdAlm = DetalleEA.IdAlm;
                _context.Add(detalleeanu);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdAlm"] = new SelectList(_context.Almacens, "IdAlm", "IdAlm", DetalleEA.IdAlm);
            ViewData["IdEmpl"] = new SelectList(_context.Empleados, "IdEmpl", "IdEmpl", DetalleEA.IdEmpl);
            return View(DetalleEA);
        }

        // GET: Detalleeas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Detalleeas == null)
            {
                return NotFound();
            }

            var detalleea = await _context.Detalleeas.FindAsync(id);
            if (detalleea == null)
            {
                return NotFound();
            }
            ViewData["IdAlm"] = new SelectList(_context.Almacens, "IdAlm", "IdAlm", detalleea.IdAlm);
            ViewData["IdEmpl"] = new SelectList(_context.Empleados, "IdEmpl", "IdEmpl", detalleea.IdEmpl);
            return View(detalleea);
        }

        // POST: Detalleeas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(DetalleEAUpdate DetalleEA)
        {
            

            if (ModelState.IsValid)
            {
                try
                {
                    Detalleea detalleeaup = new Detalleea();
                    detalleeaup.IdDetalleEa = DetalleEA.IdDetalleEa;
                    detalleeaup.FechaDetalleEa = DetalleEA.FechaDetalleEa;
                    detalleeaup.IdEmpl =DetalleEA.IdEmpl;
                    detalleeaup.IdAlm =DetalleEA.IdAlm;
                    _context.Update(detalleeaup);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DetalleeaExists(DetalleEA.IdDetalleEa))
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
            ViewData["IdAlm"] = new SelectList(_context.Almacens, "IdAlm", "IdAlm", DetalleEA.IdAlm);
            ViewData["IdEmpl"] = new SelectList(_context.Empleados, "IdEmpl", "IdEmpl", DetalleEA.IdEmpl);
            return View(DetalleEA);
        }

        // GET: Detalleeas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Detalleeas == null)
            {
                return NotFound();
            }

            var detalleea = await _context.Detalleeas
                .Include(d => d.IdAlmNavigation)
                .Include(d => d.IdEmplNavigation)
                .FirstOrDefaultAsync(m => m.IdDetalleEa == id);
            if (detalleea == null)
            {
                return NotFound();
            }

            return View(detalleea);
        }

        // POST: Detalleeas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Detalleeas == null)
            {
                return Problem("Entity set 'ProyectofarmContext.Detalleeas'  is null.");
            }
            var detalleea = await _context.Detalleeas.FindAsync(id);
            if (detalleea != null)
            {
                _context.Detalleeas.Remove(detalleea);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DetalleeaExists(int id)
        {
          return (_context.Detalleeas?.Any(e => e.IdDetalleEa == id)).GetValueOrDefault();
        }
    }
}
