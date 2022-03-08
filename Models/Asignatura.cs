using System;

namespace CASPNetCore.Models
{
    public class Asignatura: ObjetoEscuelaBase
    {   
        public string CursoId { get; set; }
        public Curso curso { get; set; }
        public List<Evaluacion> Evaluaciones {get; set;}
    }
}