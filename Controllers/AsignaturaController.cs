using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using CASPNetCore.Models;

namespace CASPNetCore.Controllers
{
    public class AsignaturaController : Controller
    {
        public IActionResult Index()
        {
            var Asig = new Asignatura(){
                UniqueId = Guid.NewGuid().ToString(),
                Name = "Programacion"
            };

            ViewBag.CosaDinamica = "La Monja";
            ViewBag.Fecha = DateTime.Now;
            return View(Asig);
        }
    }
}