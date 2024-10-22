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
    public class PaquetesHospedajesController : Controller
    {
        private readonly MedellinSalvajeContext _context;

        public PaquetesHospedajesController(MedellinSalvajeContext context)
        {
            _context = context;
        }

        // GET: PaquetesHospedajes
        public async Task<IActionResult> Index()
        {
            var medellinSalvajeContext = _context.PaquetesHospedajes.Include(p => p.IdHabitacionNavigation).Include(p => p.IdServicioNavigation);
            return View(await medellinSalvajeContext.ToListAsync());
        }

        // GET: PaquetesHospedajes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var paquetesHospedaje = await _context.PaquetesHospedajes
                .Include(p => p.IdHabitacionNavigation)
                .Include(p => p.IdServicioNavigation)
                .FirstOrDefaultAsync(m => m.IdPaquete == id);
            if (paquetesHospedaje == null)
            {
                return NotFound();
            }

            return View(paquetesHospedaje);
        }

        // GET: PaquetesHospedajes/Create
        public IActionResult Create()
        {
            ViewData["IdHabitacion"] = new SelectList(_context.Habitaciones, "IdHabitacion", "IdHabitacion");
            ViewData["IdServicio"] = new SelectList(_context.Servicios, "IdServicio", "IdServicio");
            return View();
        }

        // POST: PaquetesHospedajes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdPaquete,Nombre,Descripcion,PrecioTotal,Duracion,IdServicio,IdHabitacion")] PaquetesHospedaje paquetesHospedaje)
        {
            if (ModelState.IsValid)
            {
                _context.Add(paquetesHospedaje);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdHabitacion"] = new SelectList(_context.Habitaciones, "IdHabitacion", "IdHabitacion", paquetesHospedaje.IdHabitacion);
            ViewData["IdServicio"] = new SelectList(_context.Servicios, "IdServicio", "IdServicio", paquetesHospedaje.IdServicio);
            return View(paquetesHospedaje);
        }

        // GET: PaquetesHospedajes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var paquetesHospedaje = await _context.PaquetesHospedajes.FindAsync(id);
            if (paquetesHospedaje == null)
            {
                return NotFound();
            }
            ViewData["IdHabitacion"] = new SelectList(_context.Habitaciones, "IdHabitacion", "IdHabitacion", paquetesHospedaje.IdHabitacion);
            ViewData["IdServicio"] = new SelectList(_context.Servicios, "IdServicio", "IdServicio", paquetesHospedaje.IdServicio);
            return View(paquetesHospedaje);
        }

        // POST: PaquetesHospedajes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdPaquete,Nombre,Descripcion,PrecioTotal,Duracion,IdServicio,IdHabitacion")] PaquetesHospedaje paquetesHospedaje)
        {
            if (id != paquetesHospedaje.IdPaquete)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(paquetesHospedaje);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PaquetesHospedajeExists(paquetesHospedaje.IdPaquete))
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
            ViewData["IdHabitacion"] = new SelectList(_context.Habitaciones, "IdHabitacion", "IdHabitacion", paquetesHospedaje.IdHabitacion);
            ViewData["IdServicio"] = new SelectList(_context.Servicios, "IdServicio", "IdServicio", paquetesHospedaje.IdServicio);
            return View(paquetesHospedaje);
        }

        // GET: PaquetesHospedajes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var paquetesHospedaje = await _context.PaquetesHospedajes
                .Include(p => p.IdHabitacionNavigation)
                .Include(p => p.IdServicioNavigation)
                .FirstOrDefaultAsync(m => m.IdPaquete == id);
            if (paquetesHospedaje == null)
            {
                return NotFound();
            }

            return View(paquetesHospedaje);
        }

        // POST: PaquetesHospedajes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var paquetesHospedaje = await _context.PaquetesHospedajes.FindAsync(id);
            if (paquetesHospedaje != null)
            {
                _context.PaquetesHospedajes.Remove(paquetesHospedaje);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PaquetesHospedajeExists(int id)
        {
            return _context.PaquetesHospedajes.Any(e => e.IdPaquete == id);
        }
    }
}
