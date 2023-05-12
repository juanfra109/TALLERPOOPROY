using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TALLERPOON.Models.dbModels;

namespace TALLERPOON.Controllers
{
    public class DetalleppsController : Controller
    {
        private readonly ProyectofarmContext _context;

        public DetalleppsController(ProyectofarmContext context)
        {
            _context = context;
        }

        // GET: Detallepps
        public async Task<IActionResult> Index()
        {
            var proyectofarmContext = _context.Detallepps.Include(d => d.IdProdNavigation).Include(d => d.IdProvNavigation);
            return View(await proyectofarmContext.ToListAsync());
        }

        // GET: Detallepps/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Detallepps == null)
            {
                return NotFound();
            }

            var detallepp = await _context.Detallepps
                .Include(d => d.IdProdNavigation)
                .Include(d => d.IdProvNavigation)
                .FirstOrDefaultAsync(m => m.IdDetallepp == id);
            if (detallepp == null)
            {
                return NotFound();
            }

            return View(detallepp);
        }

        // GET: Detallepps/Create
        public IActionResult Create()
        {
            ViewData["IdProd"] = new SelectList(_context.Productos, "IdProd", "IdProd");
            ViewData["IdProv"] = new SelectList(_context.Proveedors, "IdProv", "IdProv");
            return View();
        }

        // POST: Detallepps/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdDetallepp,IdProd,NomProd,CantProd,IdProv")] Detallepp detallepp)
        {
            if (ModelState.IsValid)
            {
                _context.Add(detallepp);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdProd"] = new SelectList(_context.Productos, "IdProd", "IdProd", detallepp.IdProd);
            ViewData["IdProv"] = new SelectList(_context.Proveedors, "IdProv", "IdProv", detallepp.IdProv);
            return View(detallepp);
        }

        // GET: Detallepps/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Detallepps == null)
            {
                return NotFound();
            }

            var detallepp = await _context.Detallepps.FindAsync(id);
            if (detallepp == null)
            {
                return NotFound();
            }
            ViewData["IdProd"] = new SelectList(_context.Productos, "IdProd", "IdProd", detallepp.IdProd);
            ViewData["IdProv"] = new SelectList(_context.Proveedors, "IdProv", "IdProv", detallepp.IdProv);
            return View(detallepp);
        }

        // POST: Detallepps/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdDetallepp,IdProd,NomProd,CantProd,IdProv")] Detallepp detallepp)
        {
            if (id != detallepp.IdDetallepp)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(detallepp);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DetalleppExists(detallepp.IdDetallepp))
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
            ViewData["IdProd"] = new SelectList(_context.Productos, "IdProd", "IdProd", detallepp.IdProd);
            ViewData["IdProv"] = new SelectList(_context.Proveedors, "IdProv", "IdProv", detallepp.IdProv);
            return View(detallepp);
        }

        // GET: Detallepps/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Detallepps == null)
            {
                return NotFound();
            }

            var detallepp = await _context.Detallepps
                .Include(d => d.IdProdNavigation)
                .Include(d => d.IdProvNavigation)
                .FirstOrDefaultAsync(m => m.IdDetallepp == id);
            if (detallepp == null)
            {
                return NotFound();
            }

            return View(detallepp);
        }

        // POST: Detallepps/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Detallepps == null)
            {
                return Problem("Entity set 'ProyectofarmContext.Detallepps'  is null.");
            }
            var detallepp = await _context.Detallepps.FindAsync(id);
            if (detallepp != null)
            {
                _context.Detallepps.Remove(detallepp);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DetalleppExists(int id)
        {
          return (_context.Detallepps?.Any(e => e.IdDetallepp == id)).GetValueOrDefault();
        }
    }
}
