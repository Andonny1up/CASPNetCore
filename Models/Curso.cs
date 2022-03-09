using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CASPNetCore.Models
{
    public class Curso:ObjetoEscuelaBase
    {
        [Display(Prompt = "Soy sexy")]
        [StringLength(5, ErrorMessage ="Soy tan genial que no puedes pulsar más de 5 caracteres")]
        public override string Name { get; set; }
        public TiposJornada Jornada { get; set; }
        public List<Asignatura>? Asignaturas{ get; set; }
        public List<Alumno>? Alumnos{ get; set; }

        public string? Dirrecion { get; set; }
        public string? SchoolId { get; set; }
        public School? school { get; set; }
    }
}