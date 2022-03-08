using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using CASPNetCore.Models;

namespace CASPNetCore.Controllers
{
    public class AsignaturaController : Controller
    {
        public IActionResult Index()
        {
            return View(_context.Asignaturas.FirstOrDefault());
        }
        public IActionResult MultiAsig()
        {
            ViewBag.CosaDinamica = "La Monja";
            ViewBag.Fecha = DateTime.Now;
            return View("MultiAsig",_context.Asignaturas);
        }
        private SchoolContext _context;
        public AsignaturaController(SchoolContext context)
        {
            _context = context;
        }
    }
}