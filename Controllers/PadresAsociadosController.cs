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
    public class PadresAsociadosController : Controller
    {
        private readonly MvcMovieContext _context;

        public PadresAsociadosController(MvcMovieContext context)
        {
            _context = context;
        }

        // GET: PadresAsociados
        public async Task<IActionResult> Index()
        {
              return _context.PadresAsociado != null ? 
                          View(await _context.PadresAsociado.ToListAsync()) :
                          Problem("Entity set 'MvcMovieContext.PadresAsociado'  is null.");
        }

        // GET: PadresAsociados/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.PadresAsociado == null)
            {
                return NotFound();
            }

            var padresAsociado = await _context.PadresAsociado
                .FirstOrDefaultAsync(m => m.Id == id);
            if (padresAsociado == null)
            {
                return NotFound();
            }

            return View(padresAsociado);
        }

        // GET: PadresAsociados/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: PadresAsociados/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,IdAsociado,Nombre,LugarNacimiento,Escolaridad,Edad,Tipo,Parentesco,AcidoFolico,CitasMedicas,Seguro")] PadresAsociado padresAsociado)
        {
            if (ModelState.IsValid)
            {
                _context.Add(padresAsociado);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(padresAsociado);
        }

        // GET: PadresAsociados/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.PadresAsociado == null)
            {
                return NotFound();
            }

            var padresAsociado = await _context.PadresAsociado.FindAsync(id);
            if (padresAsociado == null)
            {
                return NotFound();
            }
            return View(padresAsociado);
        }

        // POST: PadresAsociados/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,IdAsociado,Nombre,LugarNacimiento,Escolaridad,Edad,Tipo,Parentesco,AcidoFolico,CitasMedicas,Seguro")] PadresAsociado padresAsociado)
        {
            if (id != padresAsociado.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(padresAsociado);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PadresAsociadoExists(padresAsociado.Id))
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
            return View(padresAsociado);
        }

        // GET: PadresAsociados/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.PadresAsociado == null)
            {
                return NotFound();
            }

            var padresAsociado = await _context.PadresAsociado
                .FirstOrDefaultAsync(m => m.Id == id);
            if (padresAsociado == null)
            {
                return NotFound();
            }

            return View(padresAsociado);
        }

        // POST: PadresAsociados/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.PadresAsociado == null)
            {
                return Problem("Entity set 'MvcMovieContext.PadresAsociado'  is null.");
            }
            var padresAsociado = await _context.PadresAsociado.FindAsync(id);
            if (padresAsociado != null)
            {
                _context.PadresAsociado.Remove(padresAsociado);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PadresAsociadoExists(int id)
        {
          return (_context.PadresAsociado?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
