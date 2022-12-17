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
    public class PadAsoComunController : Controller
    {
        private readonly MvcMovieContext _context;

        public PadAsoComunController(MvcMovieContext context)
        {
            _context = context;
        }

        // GET: PadAsoComun
        public async Task<IActionResult> Index()
        {
              return _context.PadAsoComun != null ? 
                          View(await _context.PadAsoComun.ToListAsync()) :
                          Problem("Entity set 'MvcMovieContext.PadAsoComun'  is null.");
        }

        // GET: PadAsoComun/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.PadAsoComun == null)
            {
                return NotFound();
            }

            var padAsoComun = await _context.PadAsoComun
                .FirstOrDefaultAsync(m => m.Id == id);
            if (padAsoComun == null)
            {
                return NotFound();
            }

            return View(padAsoComun);
        }

        // GET: PadAsoComun/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: PadAsoComun/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,IdPadresAsociado,IdAsociado,Adicciones,HijosDTN,FamiliaresDTN,ExposicionToxinas,DescripcionToxinas")] PadAsoComun padAsoComun)
        {
            if (ModelState.IsValid)
            {
                _context.Add(padAsoComun);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(padAsoComun);
        }

        // GET: PadAsoComun/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.PadAsoComun == null)
            {
                return NotFound();
            }

            var padAsoComun = await _context.PadAsoComun.FindAsync(id);
            if (padAsoComun == null)
            {
                return NotFound();
            }
            return View(padAsoComun);
        }

        // POST: PadAsoComun/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,IdPadresAsociado,IdAsociado,Adicciones,HijosDTN,FamiliaresDTN,ExposicionToxinas,DescripcionToxinas")] PadAsoComun padAsoComun)
        {
            if (id != padAsoComun.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(padAsoComun);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PadAsoComunExists(padAsoComun.Id))
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
            return View(padAsoComun);
        }

        // GET: PadAsoComun/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.PadAsoComun == null)
            {
                return NotFound();
            }

            var padAsoComun = await _context.PadAsoComun
                .FirstOrDefaultAsync(m => m.Id == id);
            if (padAsoComun == null)
            {
                return NotFound();
            }

            return View(padAsoComun);
        }

        // POST: PadAsoComun/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.PadAsoComun == null)
            {
                return Problem("Entity set 'MvcMovieContext.PadAsoComun'  is null.");
            }
            var padAsoComun = await _context.PadAsoComun.FindAsync(id);
            if (padAsoComun != null)
            {
                _context.PadAsoComun.Remove(padAsoComun);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PadAsoComunExists(int id)
        {
          return (_context.PadAsoComun?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
