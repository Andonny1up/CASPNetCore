using System;
using System.Linq;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using CASPNetCore.Models;

namespace CASPNetCore.Controllers
{
    public class AlumnoController : Controller
    {
        [Route("Alumno/Index/{alumnoId?}")]
        public IActionResult Index(string alumnoId)
        {
            if(!string.IsNullOrWhiteSpace(alumnoId)){
                var alumno = from alumn in _context.Alumnos
                where alumn.Id == alumnoId
                select alumn;
                return View(alumno.SingleOrDefault());
            }else{
                return View("MultiAlum",_context.Alumnos);
            }
            

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