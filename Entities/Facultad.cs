using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiExamenFinal.Entities
{
    public class Facultad
    {
        public Facultad()
        {
            Escuelas = new List<Escuela>();
        }
        public int Id { get; set; }
        public string nombre { get; set; }
        public string codigo { get; set; }
        public virtual List<Escuela> Escuelas { get; set; }
    }
}
