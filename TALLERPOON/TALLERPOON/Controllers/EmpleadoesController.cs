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
    public class EmpleadoesController : Controller
    {
        private readonly ProyectofarmContext _context;

        public EmpleadoesController(ProyectofarmContext context)
        {
            _context = context;
        }

        // GET: Empleadoes
        public async Task<IActionResult> Index()
        {
            var proyectofarmContext = _context.Empleados.Include(e => e.TurnEmplNavigation);
            return View(await proyectofarmContext.ToListAsync());
        }

        // GET: Empleadoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Empleados == null)
            {
                return NotFound();
            }

            var empleado = await _context.Empleados
                .Include(e => e.TurnEmplNavigation)
                .FirstOrDefaultAsync(m => m.IdEmpl == id);
            if (empleado == null)
            {
                return NotFound();
            }

            return View(empleado);
        }

        // GET: Empleadoes/Create
        public IActionResult Create()
        {
            ViewData["TurnEmpl"] = new SelectList(_context.Turnos, "IdTurn", "IdTurn");
            return View();
        }

        // POST: Empleadoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(EmpleadoCreate Empleado)
        {
            if (ModelState.IsValid)
            {
                Empleado empleadonu = new Empleado();
                empleadonu.IdEmpl = Empleado.IdEmpl;
                empleadonu.NomEmpl = Empleado.NomEmpl;  
                empleadonu.TelEmp = Empleado.TelEmp;
                empleadonu.RfcEmpl = Empleado.RfcEmpl;
                empleadonu.DirEmpl = Empleado.DirEmpl;
                empleadonu.TurnEmpl = Empleado.TurnEmpl;
                empleadonu.Correo= Empleado.Correo;
                _context.Add(empleadonu);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["TurnEmpl"] = new SelectList(_context.Turnos, "IdTurn", "IdTurn", Empleado.TurnEmpl);
            return View(Empleado);
        }

        // GET: Empleadoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Empleados == null)
            {
                return NotFound();
            }

            var empleado = await _context.Empleados.FindAsync(id);
            if (empleado == null)
            {
                return NotFound();
            }
            ViewData["TurnEmpl"] = new SelectList(_context.Turnos, "IdTurn", "IdTurn", empleado.TurnEmpl);
            return View(empleado);
        }

        // POST: Empleadoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(EmpleadoUpdateDto Empleado)
        {
            

            if (ModelState.IsValid)
            {
                try
                {
                    Empleado empleadoup = new Empleado();
                    empleadoup.IdEmpl = Empleado.IdEmpl;
                    empleadoup.NomEmpl = Empleado.NomEmpl;
                    empleadoup.TelEmp = Empleado.TelEmp;
                    empleadoup.RfcEmpl = Empleado.RfcEmpl;
                    empleadoup.DirEmpl = Empleado.DirEmpl;
                    empleadoup.TurnEmpl = Empleado.TurnEmpl;
                    empleadoup.Correo = Empleado.Correo;
                    _context.Update(empleadoup);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EmpleadoExists(Empleado.IdEmpl))
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
            ViewData["TurnEmpl"] = new SelectList(_context.Turnos, "IdTurn", "IdTurn", Empleado.TurnEmpl);
            return View(Empleado);
        }

        // GET: Empleadoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Empleados == null)
            {
                return NotFound();
            }

            var empleado = await _context.Empleados
                .Include(e => e.TurnEmplNavigation)
                .FirstOrDefaultAsync(m => m.IdEmpl == id);
            if (empleado == null)
            {
                return NotFound();
            }

            return View(empleado);
        }

        // POST: Empleadoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Empleados == null)
            {
                return Problem("Entity set 'ProyectofarmContext.Empleados'  is null.");
            }
            var empleado = await _context.Empleados.FindAsync(id);
            if (empleado != null)
            {
                _context.Empleados.Remove(empleado);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EmpleadoExists(int id)
        {
          return (_context.Empleados?.Any(e => e.IdEmpl == id)).GetValueOrDefault();
        }
    }
}
