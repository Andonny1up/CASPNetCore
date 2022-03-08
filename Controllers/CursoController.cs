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
        private SchoolContext _context;
        public CursoController(SchoolContext context)
        {
            _context = context;
        }
    }
}