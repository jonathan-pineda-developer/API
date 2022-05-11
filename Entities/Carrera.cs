using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiExamenFinal.Entities
{
    public class Carrera
    {
        public int Id { get; set; }
        public string nombre { get; set;}
        public string codigo { get; set; }
        public int escuelaId { get; set; }
        public virtual Escuela Escuela { get; set; }
    }
}
