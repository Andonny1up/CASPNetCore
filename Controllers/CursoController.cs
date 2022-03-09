using System;
using System.Linq;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using CASPNetCore.Models;

namespace CASPNetCore.Controllers
{
    public class CursoController : Controller
    {
        [Route("Curso/Index/{CursoId?}")]
        public IActionResult Index(string cursoId)
        {
            if(!string.IsNullOrWhiteSpace(cursoId)){
                var curso = from cur in _context.cursos
                where cur.Id == cursoId
                select cur;
                return View(curso.SingleOrDefault());
            }else{
                return View("MultiCurso",_context.cursos);
            }
            

        }
        public IActionResult MultiCurso()
        {
            ViewBag.CosaDinamica = "Televisa presenta";
            ViewBag.Fecha = DateTime.Now;
            return View("MultiCurso",_context.cursos);
        }
        public IActionResult Create()
        {
            ViewBag.Fecha = DateTime.Now;
            return View();
        }
        [HttpPost]
        public IActionResult Create(Curso curso)
        {
            curso.Id = Guid.NewGuid().ToString();
            ViewBag.Fecha = DateTime.Now;
            var scuela = _context.Escuelas.FirstOrDefault();
            curso.SchoolId = scuela.Id;
            curso.school = scuela;
            if (ModelState.IsValid)
            {
                _context.cursos.Add(curso);
                _context.SaveChanges();
                ViewBag.MensajeExtra = "Curso Creado";
                return View("Index",curso);
            }
            else{
                return View();
            }
        }
         public IActionResult Update () {
            ViewBag.Fecha = DateTime.Now;

            return View ();
        }
        [HttpPost]
        public IActionResult Update (Curso curso) {
            ViewBag.Fecha = DateTime.Now;

            if (ModelState.IsValid) {
                Curso cursoDb = _context.cursos.Where (c => c.Id == curso.Id).SingleOrDefault ();
                if (cursoDb == null || string.IsNullOrWhiteSpace (cursoDb.Id)) {
                    ViewBag.MensajeExtra = "El curso no existe. Compruebe el ID.";

                    return View (curso);
                }
                var escuela = _context.Escuelas.FirstOrDefault ();
                if (curso.SchoolId != cursoDb.SchoolId) 
                    cursoDb.SchoolId = curso.SchoolId;
                if (curso.Name != cursoDb.Name)
                    cursoDb.Name = curso.Name;
                if (curso.Jornada != cursoDb.Jornada)
                    cursoDb.Jornada = curso.Jornada;

                _context.cursos.Update (cursoDb);
                _context.SaveChanges ();
                ViewBag.MensajeExtra = "Curso actualizado";

                return View ("Index", curso);
            } else {
                return View (curso);
            }
        }
        private SchoolContext _context;
        public CursoController(SchoolContext context)
        {
            _context = context;
        }
    }
}