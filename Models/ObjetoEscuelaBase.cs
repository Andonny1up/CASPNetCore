using System;

namespace CASPNetCore.Models
{
    public abstract class ObjetoEscuelaBase
    {
        public string UniqueId { get; set; }
        public string Name { get; set; }
        public ObjetoEscuelaBase()
        {
           
        }
        public override string ToString()
        {
            //return base.ToString();
            return $"{Name},{UniqueId}";
        }
    }
}