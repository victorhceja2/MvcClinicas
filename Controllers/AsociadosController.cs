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
    public class AsociadosController : Controller
    {
        private readonly MvcMovieContext _context;
        private readonly IWebHostEnvironment _hostEnvironment;

        public AsociadosController(MvcMovieContext context, IWebHostEnvironment hostEnvironment)
        {
            _context = context;
            this._hostEnvironment = hostEnvironment;
        }

        // GET: Asociados
        public async Task<IActionResult> Index()
        {
              return _context.Asociado != null ? 
                          View(await _context.Asociado.ToListAsync()) :
                          Problem("Entity set 'MvcMovieContext.Asociado'  is null.");
        }

        // GET: Asociados/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Asociado == null)
            {
                return NotFound();
            }

            var asociado = await _context.Asociado
                .FirstOrDefaultAsync(m => m.Id == id);
            if (asociado == null)
            {
                return NotFound();
            }

            return View(asociado);
        }

        


        // GET: Asociados/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Asociados/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,FolioCredencial,Nombre,FechaAlta,Sexo,FechaNacimiento,Edad,NombrePadre,NombreMadre,Direccion,Ciudad,Estado,Pais,CP,Telefono1,Telefono2,Telefono3,Telefono4,CorreoElectronico,Emergencias,Activo")] Asociado asociado)
        {
            if (ModelState.IsValid)
            {
                            //Save image to wwwroot/image
            // string wwwRootPath = _hostEnvironment.WebRootPath;
            // string fileName = Path.GetFileNameWithoutExtension(asociado.ImageFile.FileName);
            // string extension = Path.GetExtension(asociado.ImageFile.FileName);
            // asociado.ImageName=fileName =  fileName + DateTime.Now.ToString("yymmssfff") + extension;
            // string path = Path.Combine(wwwRootPath + "/Image/", fileName);
            // using (var fileStream = new FileStream(path,FileMode.Create))
            // {
            //     await asociado.ImageFile.CopyToAsync(fileStream);
            // }
                _context.Add(asociado);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(asociado);
        }

        // GET: Asociados/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Asociado == null)
            {
                return NotFound();
            }

            var asociado = await _context.Asociado.FindAsync(id);
            if (asociado == null)
            {
                return NotFound();
            }
            return View(asociado);
        }

        // POST: Asociados/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,FolioCredencial,Nombre,FechaAlta,Sexo,FechaNacimiento,Edad,NombrePadre,NombreMadre,Direccion,Ciudad,Estado,Pais,CP,Telefono1,Telefono2,Telefono3,Telefono4,CorreoElectronico,Emergencias,Activo")] Asociado asociado)
        {
            if (id != asociado.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(asociado);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AsociadoExists(asociado.Id))
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
            return View(asociado);
        }

        // GET: Asociados/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Asociado == null)
            {
                return NotFound();
            }

            var asociado = await _context.Asociado
                .FirstOrDefaultAsync(m => m.Id == id);
            if (asociado == null)
            {
                return NotFound();
            }

            return View(asociado);
        }

        // POST: Asociados/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Asociado == null)
            {
                return Problem("Entity set 'MvcMovieContext.Asociado'  is null.");
            }
            var asociado = await _context.Asociado.FindAsync(id);
            if (asociado != null)
            {
                _context.Asociado.Remove(asociado);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AsociadoExists(int id)
        {
          return (_context.Asociado?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
