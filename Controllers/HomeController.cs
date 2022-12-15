using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using MvcClinicas.Models;

namespace MvcClinicas.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {

         var loginsesion= HttpContext.Session.GetObject<Login>("ObjetoComplejo");
        if(loginsesion == null)
        {
        return RedirectToAction("Create","Login");
        }     
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
