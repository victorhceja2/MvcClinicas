using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MvcClinicas.Data;
using MvcClinicas.Models;

namespace MvcClinicas.Controllers
{
    public class PadecimientoAsociadoController : Controller
    {
        private readonly MvcMovieContext _context;

        public PadecimientoAsociadoController(MvcMovieContext context)
        {
            _context = context;
        }

        // GET: PadecimientoAsociado
        public async Task<IActionResult> Index()
        {
              return _context.PadecimientoAsociado != null ? 
                          View(await _context.PadecimientoAsociado.ToListAsync()) :
                          Problem("Entity set 'MvcMovieContext.PadecimientoAsociado'  is null.");
        }

        // GET: PadecimientoAsociado/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.PadecimientoAsociado == null)
            {
                return NotFound();
            }

            var padecimientoAsociado = await _context.PadecimientoAsociado
                .FirstOrDefaultAsync(m => m.Id == id);
            if (padecimientoAsociado == null)
            {
                return NotFound();
            }

            return View(padecimientoAsociado);
        }

        // GET: PadecimientoAsociado/Create
        public IActionResult Create()
        {
            return View();
        }


        // POST: PadecimientoAsociado/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,IdAsociado,Padecimiento,Hospital,FechaRegistro,Valvula,Sangre,Notas")] PadecimientoAsociado padecimientoAsociado)
        {
            if (ModelState.IsValid)
            {
                if(TempData["IdAsociado"] != null)
                {padecimientoAsociado.IdAsociado = int.Parse(TempData["IdAsociado"].ToString());}
                
                _context.Add(padecimientoAsociado);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(padecimientoAsociado);
        }

        // GET: PadecimientoAsociado/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.PadecimientoAsociado == null)
            {
                return NotFound();
            }

            var padecimientoAsociado = await _context.PadecimientoAsociado.FindAsync(id);
            if (padecimientoAsociado == null)
            {
                return NotFound();
            }
            return View(padecimientoAsociado);
        }

        // POST: PadecimientoAsociado/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,IdAsociado,Padecimiento,Hospital,FechaRegistro,Valvula,Sangre,Notas")] PadecimientoAsociado padecimientoAsociado)
        {
            if (id != padecimientoAsociado.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(padecimientoAsociado);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PadecimientoAsociadoExists(padecimientoAsociado.Id))
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
            return View(padecimientoAsociado);
        }

        // GET: PadecimientoAsociado/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.PadecimientoAsociado == null)
            {
                return NotFound();
            }

            var padecimientoAsociado = await _context.PadecimientoAsociado
                .FirstOrDefaultAsync(m => m.Id == id);
            if (padecimientoAsociado == null)
            {
                return NotFound();
            }

            return View(padecimientoAsociado);
        }

        // POST: PadecimientoAsociado/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.PadecimientoAsociado == null)
            {
                return Problem("Entity set 'MvcMovieContext.PadecimientoAsociado'  is null.");
            }
            var padecimientoAsociado = await _context.PadecimientoAsociado.FindAsync(id);
            if (padecimientoAsociado != null)
            {
                _context.PadecimientoAsociado.Remove(padecimientoAsociado);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PadecimientoAsociadoExists(int id)
        {
          return (_context.PadecimientoAsociado?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
