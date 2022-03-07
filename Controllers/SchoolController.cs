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
            school.SchoolId = Guid.NewGuid().ToString();
            school.Name = "Juan Ardaya";

            ViewBag.CosaDinamica = "La Monja";
            return View(school);
        }
    }
}