using System;

namespace CASPNetCore.Models
{
    public abstract class ObjetoEscuelaBase
    {
        public string? Id { get; set; }
        public virtual string Name { get; set; }
        public ObjetoEscuelaBase()
        {
           
        }
        public override string ToString()
        {
            //return base.ToString();
            return $"{Name},{Id}";
        }
    }
}