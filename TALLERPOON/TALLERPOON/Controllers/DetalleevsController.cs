using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TALLERPOON.Models.dbModels;
using TALLERPOON.Dto;
using System.Globalization;



namespace TALLERPOON.Controllers
{
    public class DetalleevsController : Controller
    {
        private readonly ProyectofarmContext _context;

        public DetalleevsController(ProyectofarmContext context)
        {
            _context = context;
        }

        // GET: Detalleevs
        public async Task<IActionResult> Index()
        {
            var proyectofarmContext = _context.Detalleevs.Include(d => d.IdEmplNavigation).Include(d => d.IdProvNavigation);
            return View(await proyectofarmContext.ToListAsync());
        }

        // GET: Detalleevs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Detalleevs == null)
            {
                return NotFound();
            }

            var detalleev = await _context.Detalleevs
                .Include(d => d.IdEmplNavigation)
                .Include(d => d.IdProvNavigation)
                .FirstOrDefaultAsync(m => m.IdDetalleEp == id);
            if (detalleev == null)
            {
                return NotFound();
            }

            return View(detalleev);
        }

        // GET: Detalleevs/Create
        public IActionResult Create()
        {
            ViewData["IdEmpl"] = new SelectList(_context.Empleados, "IdEmpl", "IdEmpl");
            ViewData["IdProv"] = new SelectList(_context.Proveedors, "IdProv", "IdProv");
            return View();
        }

        // POST: Detalleevs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(DetalleEVCreate DetalleEV)
        {
            if (ModelState.IsValid)
            {
                Detalleev detalleevnu = new Detalleev();
                detalleevnu.IdDetalleEp = DetalleEV.IdDetalleEp;
                detalleevnu.IdEmpl = DetalleEV.IdEmpl;
                detalleevnu.FechDetalleEp = DateTime.Now;
                detalleevnu.IdProv=DetalleEV.IdProv;
                _context.Add(detalleevnu);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdEmpl"] = new SelectList(_context.Empleados, "IdEmpl", "IdEmpl", DetalleEV.IdEmpl);
            ViewData["IdProv"] = new SelectList(_context.Proveedors, "IdProv", "IdProv", DetalleEV.IdProv);
            return View(DetalleEV);
        }

        // GET: Detalleevs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Detalleevs == null)
            {
                return NotFound();
            }

            var detalleev = await _context.Detalleevs.FindAsync(id);
            if (detalleev == null)
            {
                return NotFound();
            }
            ViewData["IdEmpl"] = new SelectList(_context.Empleados, "IdEmpl", "IdEmpl", detalleev.IdEmpl);
            ViewData["IdProv"] = new SelectList(_context.Proveedors, "IdProv", "IdProv", detalleev.IdProv);
            return View(detalleev);
        }

        // POST: Detalleevs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(DetalleEVUpdate DetalleEV)
        {
            

            if (ModelState.IsValid)
            {
                try
                {
                    Detalleev detalleevup = new Detalleev();
                    detalleevup.IdDetalleEp = DetalleEV.IdDetalleEp;
                    detalleevup.IdEmpl = DetalleEV.IdEmpl;
                    detalleevup.IdProv = DetalleEV.IdProv;
                    detalleevup.FechDetalleEp = DetalleEV.FechDetalleEp;
                    _context.Update(detalleevup);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DetalleevExists(DetalleEV.IdDetalleEp))
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
            ViewData["IdEmpl"] = new SelectList(_context.Empleados, "IdEmpl", "IdEmpl", DetalleEV.IdEmpl);
            ViewData["IdProv"] = new SelectList(_context.Proveedors, "IdProv", "IdProv", DetalleEV.IdProv);
            return View(DetalleEV);
        }

        // GET: Detalleevs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Detalleevs == null)
            {
                return NotFound();
            }

            var detalleev = await _context.Detalleevs
                .Include(d => d.IdEmplNavigation)
                .Include(d => d.IdProvNavigation)
                .FirstOrDefaultAsync(m => m.IdDetalleEp == id);
            if (detalleev == null)
            {
                return NotFound();
            }

            return View(detalleev);
        }

        // POST: Detalleevs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Detalleevs == null)
            {
                return Problem("Entity set 'ProyectofarmContext.Detalleevs'  is null.");
            }
            var detalleev = await _context.Detalleevs.FindAsync(id);
            if (detalleev != null)
            {
                _context.Detalleevs.Remove(detalleev);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DetalleevExists(int id)
        {
          return (_context.Detalleevs?.Any(e => e.IdDetalleEp == id)).GetValueOrDefault();
        }
    }
}
