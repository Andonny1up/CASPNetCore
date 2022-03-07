using System;
using System.Collections.Generic;

namespace CASPNetCore.Models
{
    public class School:ObjetoEscuelaBase
    {
        public int YearF { get; set; }

        public string Pais { get; set; }
        public string Ciudad { get; set; }
        public string Dirrecion { get; set; }
        public TiposEscuela TipoEscuela { get; set; }
        public List<Curso> Cursos { get; set; }

        public School(string nombre, int año) => (Name, YearF) = (nombre, año);

        public School(string nombre, int año, 
                       TiposEscuela tipo, 
                       string pais = "", string ciudad = "") : base()
        {
            (Name, YearF) = (nombre, año);
            Pais = pais;
            Ciudad = ciudad;
        }
        public School ()
        {

        }

        public override string ToString()
        {
            return $"Nombre: \"{Name}\", Tipo: {TipoEscuela} {System.Environment.NewLine} Pais: {Pais}, Ciudad:{Ciudad}";
        }
    }
}
