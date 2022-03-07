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

            return View( new Alumno {
                    Name = "Pepe Veraz",
                    UniqueId = Guid.NewGuid ().ToString ()
                });
        }
        public IActionResult MultiAlum()
        {
            var listaAlumnos = GenerarAlumnosAlAzar();
            ViewBag.CosaDinamica = "La Monja";
            ViewBag.Fecha = DateTime.Now;
            return View("MultiAlum",listaAlumnos);
        }
        private List<Alumno> GenerarAlumnosAlAzar()
        {
            string[] nombre1 = { "Alba", "Felipa", "Eusebio", "Farid", "Donald", "Alvaro", "Nicolás" };
            string[] apellido1 = { "Ruiz", "Sarmiento", "Uribe", "Maduro", "Trump", "Toledo", "Herrera" };
            string[] nombre2 = { "Freddy", "Anabel", "Rick", "Murty", "Silvana", "Diomedes", "Nicomedes", "Teodoro" };

            var listaAlumnos = from n1 in nombre1
                               from n2 in nombre2
                               from a1 in apellido1
                               select new Alumno { Name = $"{n1} {n2} {a1}", UniqueId = Guid.NewGuid().ToString() };

            return listaAlumnos.OrderBy((al) => al.UniqueId).ToList();
        }
    }
}