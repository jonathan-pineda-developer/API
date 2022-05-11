using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiExamenFinal.Entities
{
    public class Escuela
    { 
        public Escuela()
        {
            Carreras = new List<Carrera>();
        }
        public int Id { get; set; }
        public string nonbre { get; set; }
        public string codigo { get; set; }
        public int faculdadId { get; set; }
        public virtual Facultad Facultad { get; set; }
        public virtual List<Carrera> Carreras { get; set; }
    }
}
