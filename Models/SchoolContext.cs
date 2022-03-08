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
        
    }
}