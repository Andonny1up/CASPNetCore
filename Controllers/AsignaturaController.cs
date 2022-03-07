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
                    UniqueId = Guid.NewGuid ().ToString ()
                });
        }
        public IActionResult MultiAsig()
        {
            var listaAsignaturas = new List<Asignatura> () {
                new Asignatura {
                    Name = "Matemáticas",
                    UniqueId = Guid.NewGuid ().ToString ()
                },
                new Asignatura {
                    Name = "Educación Física",
                    UniqueId = Guid.NewGuid ().ToString ()
                },
                    new Asignatura {
                    Name = "Castellano",
                    UniqueId = Guid.NewGuid ().ToString ()
                },
                new Asignatura {
                    Name = "Ciencias Naturales",
                    UniqueId = Guid.NewGuid ().ToString ()
                },
                new Asignatura {
                    Name = "Programacion",
                    UniqueId = Guid.NewGuid ().ToString ()
                }
            };
            ViewBag.CosaDinamica = "La Monja";
            ViewBag.Fecha = DateTime.Now;
            return View("MultiAsig",listaAsignaturas);
        }
    }
}