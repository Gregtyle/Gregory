using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Gregory.Models;

namespace Gregory.Controllers
{
    public class HabitacionesController : Controller
    {
        private readonly MedellinSalvajeContext _context;

        public HabitacionesController(MedellinSalvajeContext context)
        {
            _context = context;
        }

        // GET: Habitaciones
        public async Task<IActionResult> Index()
        {
            var medellinSalvajeContext = _context.Habitaciones.Include(h => h.IdInmuebleNavigation).Include(h => h.IdTipoHabitacionNavigation);
            return View(await medellinSalvajeContext.ToListAsync());
        }

        // GET: Habitaciones/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var habitacione = await _context.Habitaciones
                .Include(h => h.IdInmuebleNavigation)
                .Include(h => h.IdTipoHabitacionNavigation)
                .FirstOrDefaultAsync(m => m.IdHabitacion == id);
            if (habitacione == null)
            {
                return NotFound();
            }

            return View(habitacione);
        }

        // GET: Habitaciones/Create
        public IActionResult Create()
        {
            ViewData["IdInmueble"] = new SelectList(_context.Inmuebles, "IdInmueble", "IdInmueble");
            ViewData["IdTipoHabitacion"] = new SelectList(_context.TipoHabitaciones, "IdTipoHabitacion", "IdTipoHabitacion");
            return View();
        }

        // POST: Habitaciones/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdHabitacion,Nombre,IdTipoHabitacion,Estado,Descripcion,Precio,IdInmueble")] Habitacione habitacione)
        {
            if (ModelState.IsValid)
            {
                _context.Add(habitacione);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdInmueble"] = new SelectList(_context.Inmuebles, "IdInmueble", "IdInmueble", habitacione.IdInmueble);
            ViewData["IdTipoHabitacion"] = new SelectList(_context.TipoHabitaciones, "IdTipoHabitacion", "IdTipoHabitacion", habitacione.IdTipoHabitacion);
            return View(habitacione);
        }

        // GET: Habitaciones/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var habitacione = await _context.Habitaciones.FindAsync(id);
            if (habitacione == null)
            {
                return NotFound();
            }
            ViewData["IdInmueble"] = new SelectList(_context.Inmuebles, "IdInmueble", "IdInmueble", habitacione.IdInmueble);
            ViewData["IdTipoHabitacion"] = new SelectList(_context.TipoHabitaciones, "IdTipoHabitacion", "IdTipoHabitacion", habitacione.IdTipoHabitacion);
            return View(habitacione);
        }

        // POST: Habitaciones/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdHabitacion,Nombre,IdTipoHabitacion,Estado,Descripcion,Precio,IdInmueble")] Habitacione habitacione)
        {
            if (id != habitacione.IdHabitacion)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(habitacione);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HabitacioneExists(habitacione.IdHabitacion))
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
            ViewData["IdInmueble"] = new SelectList(_context.Inmuebles, "IdInmueble", "IdInmueble", habitacione.IdInmueble);
            ViewData["IdTipoHabitacion"] = new SelectList(_context.TipoHabitaciones, "IdTipoHabitacion", "IdTipoHabitacion", habitacione.IdTipoHabitacion);
            return View(habitacione);
        }

        // GET: Habitaciones/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var habitacione = await _context.Habitaciones
                .Include(h => h.IdInmuebleNavigation)
                .Include(h => h.IdTipoHabitacionNavigation)
                .FirstOrDefaultAsync(m => m.IdHabitacion == id);
            if (habitacione == null)
            {
                return NotFound();
            }

            return View(habitacione);
        }

        // POST: Habitaciones/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var habitacione = await _context.Habitaciones.FindAsync(id);
            if (habitacione != null)
            {
                _context.Habitaciones.Remove(habitacione);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool HabitacioneExists(int id)
        {
            return _context.Habitaciones.Any(e => e.IdHabitacion == id);
        }
    }
}
