using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FranMotors.Models
{
    public class Motocicleta
    {
        public int Id { get; set; }
        public int IdCliente { get; set; }
        [Required]
        public string Placa { get; set; }
        [Required]
        public string Marca { get; set; }
        [Required]
        public string NumSerie { get; set; }
        [Required]
        public string Cilindrada { get; set; }
        public string EstadoMoto { get; set; }
        public string ImgTarjeta { get; set; }
        public string ImgMoto { get; set; }
        public DateTime Año { get; set; }
    }
}
