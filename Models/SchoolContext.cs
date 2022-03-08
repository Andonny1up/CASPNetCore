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

            // Cargar Cursos de la Escuela
            var cursos = CargarCursos(school);
            // x cada Curso cargar Asignaturas
            var listaAsignaturas = CargarAsignaturas(cursos);
            // x cada Curso cargar Alumnos
            var listaAlumnos = CargarAlumnos(cursos);
            // Tarea: cargar Evaluaciones
            modelBuilder.Entity<School>().HasData(school);
            modelBuilder.Entity<Curso>().HasData(cursos.ToArray());
            modelBuilder.Entity<Asignatura>().HasData(listaAsignaturas.ToArray());
            modelBuilder.Entity<Alumno>().HasData(listaAlumnos.ToArray());
        }
        private static List<Curso> CargarCursos(School escuela)
        {
            var listaCursos = new List<Curso>() {
                new Curso {
                    Name = "101",
                    Id = Guid.NewGuid ().ToString (),
                    SchoolId = escuela.Id,
                    Jornada = TiposJornada.Mañana
                },
                new Curso {
                    Id = Guid.NewGuid ().ToString (),
                    Name = "201",
                    SchoolId = escuela.Id,
                    Jornada = TiposJornada.Mañana
                },
                new Curso {
                    Id = Guid.NewGuid ().ToString (),
                    SchoolId = escuela.Id,
                    Name = "301",
                    Jornada = TiposJornada.Mañana
                },
                new Curso {
                    Id = Guid.NewGuid ().ToString (),
                    SchoolId = escuela.Id,
                    Name = "401",
                    Jornada = TiposJornada.Tarde
                },
                new Curso {
                    Id = Guid.NewGuid ().ToString (),
                    SchoolId = escuela.Id,
                    Name = "501",
                    Jornada = TiposJornada.Noche
                }
            };
            return listaCursos;
        }
        private static List<Asignatura> CargarAsignaturas(List<Curso> cursos)
        {
            var listaCompleta = new List<Asignatura>(); 
            foreach (var curso in cursos)
            {
                var asignaturas = new List<Asignatura>() {
                    new Asignatura {
                        Id = Guid.NewGuid ().ToString (),
                        CursoId = curso.Id,
                        Name = "Matemáticas",
                    },
                    new Asignatura {
                        Id = Guid.NewGuid ().ToString (),
                        CursoId = curso.Id,
                        Name = "Educación Física",
                    },
                    new Asignatura {
                        Id = Guid.NewGuid ().ToString (),
                        CursoId = curso.Id,
                        Name = "Castellano",
                    },
                    new Asignatura {
                        Id = Guid.NewGuid ().ToString (),
                        CursoId = curso.Id,
                        Name = "Ciencias Naturales",
                    },
                    new Asignatura {
                        Id = Guid.NewGuid ().ToString (),
                        CursoId = curso.Id,
                        Name = "Programación",
                    }
                };
                listaCompleta.AddRange(asignaturas);
            }
            return listaCompleta;
        }
        private List<Alumno> CargarAlumnos(List<Curso> cursos)
        {
            var listaCompleta = new List<Alumno>();
            var rnd = new Random();
            foreach (var curso in cursos)
            {
                int cantRandom = rnd.Next(5, 20);
                var listaAlumnos = this.GenerarAlumnosAlAzar(curso, cantRandom);
                listaCompleta.AddRange(listaAlumnos);
            }
            return listaCompleta;
        }
        private List<Alumno> GenerarAlumnosAlAzar(Curso curso ,int cantidad)
        {
            string[] nombre1 = { "Alba", "Felipa", "Eusebio", "Farid", "Donald", "Alvaro", "Nicolás" };
            string[] apellido1 = { "Ruiz", "Sarmiento", "Uribe", "Maduro", "Trump", "Toledo", "Herrera" };
            string[] nombre2 = { "Freddy", "Anabel", "Rick", "Murty", "Silvana", "Diomedes", "Nicomedes", "Teodoro" };

            var listaAlumnos = from n1 in nombre1
                               from n2 in nombre2
                               from a1 in apellido1
                               select new Alumno { CursoId = curso.Id,Name = $"{n1} {n2} {a1}", Id = Guid.NewGuid().ToString() };

            return listaAlumnos.OrderBy((al) => al.Id).Take(cantidad).ToList();
        }

        //analizar luego
        private List<Evaluacion> CargarEvaluaciones(List<Curso> cursos, List<Asignatura> asignaturas, List<Alumno> alumnos, int numeroEvaluaciones = 5)
        {
            Random rnd = new Random();
            var listaEv = new List<Evaluacion>();
            foreach (var curso in cursos)
            {
                foreach (var asignatura in asignaturas)
                {
                    foreach (var alumno in alumnos)
                    {
                        for (int i = 0; i < numeroEvaluaciones; i++)
                        {
                            int cantRandom = rnd.Next(0, 500);
                            var tmp = new List<Evaluacion> {
                                new Evaluacion { 
                                    Id = Guid.NewGuid().ToString(),
                                    Name = "Evaluación de " + asignatura.Name+ " # " + (i + 1),
                                    AlumnoId = alumno.Id,
                                    Alumno = alumno,
                                    AsignaturaId = asignatura.Id,
                                    Asignatura = asignatura,
                                    Nota = (float)cantRandom/100
                                }
                            };
                            listaEv.AddRange(tmp);
                        }
                    }
                }
            }

            return listaEv;
        }
        
    }
}