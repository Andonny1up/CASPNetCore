using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using CASPNetCore.Models;

namespace CASPNetCore.Controllers
{
    public class AsignaturaController : Controller
    {
        public IActionResult Index()
        {

            return View( new Asignatura {
                    Name = "Matemáticas",
                    Id = Guid.NewGuid ().ToString ()
                });
        }
        public IActionResult MultiAsig()
        {
            var listaAsignaturas = new List<Asignatura> () {
                new Asignatura {
                    Name = "Matemáticas",
                    Id = Guid.NewGuid ().ToString ()
                },
                new Asignatura {
                    Name = "Educación Física",
                    Id = Guid.NewGuid ().ToString ()
                },
                    new Asignatura {
                    Name = "Castellano",
                    Id = Guid.NewGuid ().ToString ()
                },
                new Asignatura {
                    Name = "Ciencias Naturales",
                    Id = Guid.NewGuid ().ToString ()
                },
                new Asignatura {
                    Name = "Programacion",
                    Id = Guid.NewGuid ().ToString ()
                }
            };
            ViewBag.CosaDinamica = "La Monja";
            ViewBag.Fecha = DateTime.Now;
            return View("MultiAsig",listaAsignaturas);
        }
    }
}