using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace CASPNetCore.Models
{
    public class SchoolContext : DbContext
    {
        public DbSet<School> Escuelas { get; set; }

        public DbSet<Asignatura> Asignaturas { get; set; }
        public DbSet<Alumno> Alumnos { get; set; }
        public DbSet<Curso> cursos { get; set; }
        public DbSet<Evaluacion> Evaluacions { get; set; }

        public SchoolContext(DbContextOptions<SchoolContext> options): base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            var school = new School();
            school.YearF = 2005;
            school.Id = Guid.NewGuid().ToString();
            school.Name = "Juan Ardaya";
            school.Ciudad = "Trini city";
            school.Pais = "Bolivia";
            school.TipoEscuela = TiposEscuela.Secundaria;
            school.Dirrecion = "Enrique Egobiano";

            modelBuilder.Entity<School>().HasData(school);
            modelBuilder.Entity<Asignatura>().HasData(
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
            );
            modelBuilder.Entity<Alumno>().HasData(GenerarAlumnosAlAzar().ToArray());
        }
        private List<Alumno> GenerarAlumnosAlAzar()
        {
            string[] nombre1 = { "Alba", "Felipa", "Eusebio", "Farid", "Donald", "Alvaro", "Nicolás" };
            string[] apellido1 = { "Ruiz", "Sarmiento", "Uribe", "Maduro", "Trump", "Toledo", "Herrera" };
            string[] nombre2 = { "Freddy", "Anabel", "Rick", "Murty", "Silvana", "Diomedes", "Nicomedes", "Teodoro" };

            var listaAlumnos = from n1 in nombre1
                               from n2 in nombre2
                               from a1 in apellido1
                               select new Alumno { Name = $"{n1} {n2} {a1}", Id = Guid.NewGuid().ToString() };

            return listaAlumnos.OrderBy((al) => al.Id).ToList();
        }
        
    }
}