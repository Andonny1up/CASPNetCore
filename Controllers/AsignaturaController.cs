using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using CASPNetCore.Models;

namespace CASPNetCore.Controllers
{
    public class AsignaturaController : Controller
    {
        [Route("Asignatura/Index/{asignaturaId?}")]
        public IActionResult Index(string asignaturaId)
        {
            if(!string.IsNullOrWhiteSpace(asignaturaId)){
                var asignatura = from asig in _context.Asignaturas
                where asig.Id == asignaturaId
                select asig;
                return View(asignatura.SingleOrDefault());
            }else{
                return View("MultiAsig",_context.Asignaturas);
            }
            

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