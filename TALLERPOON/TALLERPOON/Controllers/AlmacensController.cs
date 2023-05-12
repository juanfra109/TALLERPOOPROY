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
    public class AlmacensController : Controller
    {
        private readonly ProyectofarmContext _context;

        public AlmacensController(ProyectofarmContext context)
        {
            _context = context;
        }

        // GET: Almacens
        public async Task<IActionResult> Index()
        {
              return _context.Almacens != null ? 
                          View(await _context.Almacens.ToListAsync()) :
                          Problem("Entity set 'ProyectofarmContext.Almacens'  is null.");
        }

        // GET: Almacens/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Almacens == null)
            {
                return NotFound();
            }

            var almacen = await _context.Almacens
                .FirstOrDefaultAsync(m => m.IdAlm == id);
            if (almacen == null)
            {
                return NotFound();
            }

            return View(almacen);
        }

        // GET: Almacens/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Almacens/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdAlm,NomAlm")] Almacen almacen)
        {
            if (ModelState.IsValid)
            {
                _context.Add(almacen);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(almacen);
        }

        // GET: Almacens/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Almacens == null)
            {
                return NotFound();
            }

            var almacen = await _context.Almacens.FindAsync(id);
            if (almacen == null)
            {
                return NotFound();
            }
            return View(almacen);
        }

        // POST: Almacens/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdAlm,NomAlm")] Almacen almacen)
        {
            if (id != almacen.IdAlm)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(almacen);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AlmacenExists(almacen.IdAlm))
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
            return View(almacen);
        }

        // GET: Almacens/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Almacens == null)
            {
                return NotFound();
            }

            var almacen = await _context.Almacens
                .FirstOrDefaultAsync(m => m.IdAlm == id);
            if (almacen == null)
            {
                return NotFound();
            }

            return View(almacen);
        }

        // POST: Almacens/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Almacens == null)
            {
                return Problem("Entity set 'ProyectofarmContext.Almacens'  is null.");
            }
            var almacen = await _context.Almacens.FindAsync(id);
            if (almacen != null)
            {
                _context.Almacens.Remove(almacen);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AlmacenExists(int id)
        {
          return (_context.Almacens?.Any(e => e.IdAlm == id)).GetValueOrDefault();
        }
    }
}
