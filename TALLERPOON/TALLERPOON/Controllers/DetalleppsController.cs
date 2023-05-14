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
        public async Task<IActionResult> Create(DetallePPCreate DetallePP)
        {
            if (ModelState.IsValid)
            {
                Detallepp detalleppnu = new Detallepp();
                detalleppnu.IdDetallepp = DetallePP.IdDetallepp;
                detalleppnu.IdProd = DetallePP.IdProd;
                detalleppnu.NomProd = DetallePP.NomProd;
                detalleppnu.CantProd = DetallePP.CantProd;
                detalleppnu.IdProv = DetallePP.IdProv;
                _context.Add(detalleppnu);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdProd"] = new SelectList(_context.Productos, "IdProd", "IdProd", DetallePP.IdProd);
            ViewData["IdProv"] = new SelectList(_context.Proveedors, "IdProv", "IdProv", DetallePP.IdProv);
            return View(DetallePP);
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
        public async Task<IActionResult> Edit(DetallePPUpdate DetallePP)
        {
            

            if (ModelState.IsValid)
            {
                try
                {
                    Detallepp detalleppup = new Detallepp();
                    detalleppup.IdDetallepp = DetallePP.IdDetallepp;
                    detalleppup.NomProd = DetallePP.NomProd;
                    detalleppup.IdProd = DetallePP.IdProd;
                    detalleppup.CantProd = DetallePP.CantProd;
                    detalleppup.IdProv = DetallePP.IdProv;
                    _context.Update(detalleppup);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DetalleppExists(DetallePP.IdDetallepp))
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
            ViewData["IdProd"] = new SelectList(_context.Productos, "IdProd", "IdProd", DetallePP.IdProd);
            ViewData["IdProv"] = new SelectList(_context.Proveedors, "IdProv", "IdProv", DetallePP.IdProv);
            return View(DetallePP);
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
