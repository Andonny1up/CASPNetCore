using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using CASPNetCore.Models;

namespace CASPNetCore.Controllers
{
    public class SchoolController : Controller
    {
        public IActionResult Index()
        {
            var school = new School();
            school.YearF = 2005;
            school.UniqueId = Guid.NewGuid().ToString();
            school.Name = "Juan Ardaya";
            school.Ciudad = "Trini city";
            school.Pais = "Bolivia";
            school.TipoEscuela = TiposEscuela.Secundaria;
            school.Dirrecion = "Enrique Egobiano";

            ViewBag.CosaDinamica = "La Monja";
            return View(school);
        }
    }
}