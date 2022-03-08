using System;
using System.Linq;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using CASPNetCore.Models;

namespace CASPNetCore.Controllers
{
    public class AlumnoController : Controller
    {
        public IActionResult Index()
        {
            return View(_context.Alumnos.FirstOrDefault());
        }
        public IActionResult MultiAlum()
        {
            ViewBag.CosaDinamica = "La Monja";
            ViewBag.Fecha = DateTime.Now;
            return View("MultiAlum",_context.Alumnos);
        }
        private SchoolContext _context;
        public AlumnoController(SchoolContext context)
        {
            _context = context;
        }
    }
}