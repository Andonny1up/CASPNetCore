using System;
using System.Collections.Generic;

namespace CASPNetCore.Models
{
    public class Alumno: ObjetoEscuelaBase
    {
        public List<Evaluacion> Evaluaciones {get; set;} = new List<Evaluacion>();
    }
}