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
    public class VentumsController : Controller
    {
        private readonly ProyectofarmContext _context;

        public VentumsController(ProyectofarmContext context)
        {
            _context = context;
        }

        // GET: Ventums
        public async Task<IActionResult> Index()
        {
            var proyectofarmContext = _context.Venta.Include(v => v.IdEmplNavigation);
            return View(await proyectofarmContext.ToListAsync());
        }

        // GET: Ventums/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Venta == null)
            {
                return NotFound();
            }

            var ventum = await _context.Venta
                .Include(v => v.IdEmplNavigation)
                .FirstOrDefaultAsync(m => m.IdVent == id);
            if (ventum == null)
            {
                return NotFound();
            }

            return View(ventum);
        }

        // GET: Ventums/Create
        public IActionResult Create()
        {
            ViewData["IdEmpl"] = new SelectList(_context.Empleados, "IdEmpl", "IdEmpl");
            return View();
        }

        // POST: Ventums/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(VentaCreate Venta)
        {
            if (ModelState.IsValid)
            {
                Ventum ventanu = new Ventum();
                ventanu.IdVent = Venta.IdVent;
                ventanu.TotalVent = Venta.TotalVent;
                ventanu.FechVent = Venta.FechVent;
                ventanu.IdEmpl = Venta.IdEmpl;
                _context.Add(ventanu);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdEmpl"] = new SelectList(_context.Empleados, "IdEmpl", "IdEmpl", Venta.IdEmpl);
            return View(Venta);
        }

        // GET: Ventums/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Venta == null)
            {
                return NotFound();
            }

            var ventum = await _context.Venta.FindAsync(id);
            if (ventum == null)
            {
                return NotFound();
            }
            ViewData["IdEmpl"] = new SelectList(_context.Empleados, "IdEmpl", "IdEmpl", ventum.IdEmpl);
            return View(ventum);
        }

        // POST: Ventums/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdVent,FechVent,TotalVent,IdEmpl")] Ventum ventum)
        {
            if (id != ventum.IdVent)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ventum);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VentumExists(ventum.IdVent))
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
            ViewData["IdEmpl"] = new SelectList(_context.Empleados, "IdEmpl", "IdEmpl", ventum.IdEmpl);
            return View(ventum);
        }

        // GET: Ventums/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Venta == null)
            {
                return NotFound();
            }

            var ventum = await _context.Venta
                .Include(v => v.IdEmplNavigation)
                .FirstOrDefaultAsync(m => m.IdVent == id);
            if (ventum == null)
            {
                return NotFound();
            }

            return View(ventum);
        }

        // POST: Ventums/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Venta == null)
            {
                return Problem("Entity set 'ProyectofarmContext.Venta'  is null.");
            }
            var ventum = await _context.Venta.FindAsync(id);
            if (ventum != null)
            {
                _context.Venta.Remove(ventum);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VentumExists(int id)
        {
          return (_context.Venta?.Any(e => e.IdVent == id)).GetValueOrDefault();
        }
    }
}
