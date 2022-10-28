using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FranMotors.Models
{
    public class Historial
    {
        public int Id { get; set; }
        public int IdMoto { get; set; }
        public DateTime Fecha { get; set; }
        public string Detalle { get; set; }
        public decimal Precio { get; set; }
        public string Tipo { get; set; }
    }
}
