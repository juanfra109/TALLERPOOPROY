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
    public class DetalleapsController : Controller
    {
        private readonly ProyectofarmContext _context;

        public DetalleapsController(ProyectofarmContext context)
        {
            _context = context;
        }

        // GET: Detalleaps
        public async Task<IActionResult> Index()
        {
            var proyectofarmContext = _context.Detalleaps.Include(d => d.IdAlmNavigation).Include(d => d.IdDetalleapNavigation);
            return View(await proyectofarmContext.ToListAsync());
        }

        // GET: Detalleaps/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Detalleaps == null)
            {
                return NotFound();
            }

            var detalleap = await _context.Detalleaps
                .Include(d => d.IdAlmNavigation)
                .Include(d => d.IdDetalleapNavigation)
                .FirstOrDefaultAsync(m => m.IdDetalleap == id);
            if (detalleap == null)
            {
                return NotFound();
            }

            return View(detalleap);
        }

        // GET: Detalleaps/Create
        public IActionResult Create()
        {
            ViewData["IdAlm"] = new SelectList(_context.Almacens, "IdAlm", "IdAlm");
            ViewData["IdDetalleap"] = new SelectList(_context.Productos, "IdProd", "IdProd");
            return View();
        }

        // POST: Detalleaps/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdDetalleap,IdProd,IdAlm")] Detalleap detalleap)
        {
            if (ModelState.IsValid)
            {
                _context.Add(detalleap);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdAlm"] = new SelectList(_context.Almacens, "IdAlm", "IdAlm", detalleap.IdAlm);
            ViewData["IdDetalleap"] = new SelectList(_context.Productos, "IdProd", "IdProd", detalleap.IdDetalleap);
            return View(detalleap);
        }

        // GET: Detalleaps/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Detalleaps == null)
            {
                return NotFound();
            }

            var detalleap = await _context.Detalleaps.FindAsync(id);
            if (detalleap == null)
            {
                return NotFound();
            }
            ViewData["IdAlm"] = new SelectList(_context.Almacens, "IdAlm", "IdAlm", detalleap.IdAlm);
            ViewData["IdDetalleap"] = new SelectList(_context.Productos, "IdProd", "IdProd", detalleap.IdDetalleap);
            return View(detalleap);
        }

        // POST: Detalleaps/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdDetalleap,IdProd,IdAlm")] Detalleap detalleap)
        {
            if (id != detalleap.IdDetalleap)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(detalleap);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DetalleapExists(detalleap.IdDetalleap))
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
            ViewData["IdAlm"] = new SelectList(_context.Almacens, "IdAlm", "IdAlm", detalleap.IdAlm);
            ViewData["IdDetalleap"] = new SelectList(_context.Productos, "IdProd", "IdProd", detalleap.IdDetalleap);
            return View(detalleap);
        }

        // GET: Detalleaps/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Detalleaps == null)
            {
                return NotFound();
            }

            var detalleap = await _context.Detalleaps
                .Include(d => d.IdAlmNavigation)
                .Include(d => d.IdDetalleapNavigation)
                .FirstOrDefaultAsync(m => m.IdDetalleap == id);
            if (detalleap == null)
            {
                return NotFound();
            }

            return View(detalleap);
        }

        // POST: Detalleaps/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Detalleaps == null)
            {
                return Problem("Entity set 'ProyectofarmContext.Detalleaps'  is null.");
            }
            var detalleap = await _context.Detalleaps.FindAsync(id);
            if (detalleap != null)
            {
                _context.Detalleaps.Remove(detalleap);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DetalleapExists(int id)
        {
          return (_context.Detalleaps?.Any(e => e.IdDetalleap == id)).GetValueOrDefault();
        }
    }
}
