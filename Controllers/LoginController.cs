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
    public class LoginController : Controller
    {
        private readonly MvcMovieContext _context;

        public LoginController(MvcMovieContext context)
        {
            _context = context;
        }

        // GET: Login
        public async Task<IActionResult> Index()
        {
            var loginsesion= HttpContext.Session.GetObject<Login>("ObjetoComplejo");
            if(loginsesion == null)
             {
                return RedirectToAction("Create","Login");
             }         
             if(loginsesion.Nivel == 5)
             {return RedirectToAction("Create","Login");}
             if(loginsesion.Nivel <= 1){               
              return _context.Usuario != null ? 
                          View(await _context.Usuario.ToListAsync()) :
                          Problem("Entity set 'MvcMovieContext.Usuario'  is null.");
             }
            else{
                    return RedirectToAction("Index","Home");}   
        }

        // GET: Login/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Login == null)
            {
                return NotFound();
            }

            var login = await _context.Login
                .FirstOrDefaultAsync(m => m.Id == id);
            if (login == null)
            {
                return NotFound();
            }

            return View(login);
        }

        // GET: Login/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Login/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Id_Usuario,Usuario,Password,FechaLogin,FechaLogout,Nivel")] Login login)
        {
            if (ModelState.IsValid)
            {
                                var sQuery = from m in _context.Usuario
                                        where m.Nombre == login.Usuario
                                        && m.Password == login.Password
                                        orderby m.Nombre
                                    select new
                                    {
                                        m.Id,
                                        m.Nivel,
                                        m.Nombre,
                                        m.Password
                                    };
                    if(sQuery.Count() > 0){
                        foreach(var reg in sQuery)
                        {
                            login.Id_Usuario = reg.Id; //Jalar el valor de usuario
                            login.FechaLogin = DateTime.Now;
                            login.Nivel = reg.Nivel; //Jalar el valor de usuario
                            login.Usuario = reg.Nombre;
                            login.Password = reg.Password;
                            HttpContext.Session.Clear();
                            HttpContext.Session.SetObject("ObjetoComplejo", login);
                        }
                    }
                    else{
                        return View(login);
                    }
                    _context.Add(login);
                    await _context.SaveChangesAsync();
                    TempData["Message"] = "Activo";
                   return RedirectToAction("Index","Home");
            }
            return View(login);
        }

        public IActionResult Logout()
        {
            Login login = HttpContext.Session.GetObject<Login>("ObjetoComplejo");
            if(login == null)
            {
                return RedirectToAction("Create","Login");
            }
            //login.Id_Usuario = 0;
            //login.Usuario=string.Empty;
            //login.Password = string.Empty;
            login.FechaLogout = DateTime.Now;
            login.Nivel = 5;

            _context.Add(login);
            _context.SaveChangesAsync();
            HttpContext.Session.SetObject("ObjetoComplejo", login);
            HttpContext.Session.Clear();
            TempData["Message"] = null;
            return View();
        }

        // GET: Login/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Login == null)
            {
                return NotFound();
            }

            var login = await _context.Login.FindAsync(id);
            if (login == null)
            {
                return NotFound();
            }
            return View(login);
        }

        // POST: Login/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Id_Usuario,Usuario,Password,FechaLogin,FechaLogout,Nivel")] Login login)
        {
            if (id != login.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(login);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LoginExists(login.Id))
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
            return View(login);
        }

        // GET: Login/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Login == null)
            {
                return NotFound();
            }

            var login = await _context.Login
                .FirstOrDefaultAsync(m => m.Id == id);
            if (login == null)
            {
                return NotFound();
            }

            return View(login);
        }

        // POST: Login/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Login == null)
            {
                return Problem("Entity set 'MvcMovieContext.Login'  is null.");
            }
            var login = await _context.Login.FindAsync(id);
            if (login != null)
            {
                _context.Login.Remove(login);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LoginExists(int id)
        {
          return (_context.Login?.Any(e => e.Id == id)).GetValueOrDefault();
        }


    }
}
