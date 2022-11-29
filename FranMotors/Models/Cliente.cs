using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FranMotors.Models
{
    public class Cliente
    {
        public int Id { get; set; }
        public int IdMecanico { get; set; }

        [Required(ErrorMessage = "Este campo es obligatorio")]
        [RegularExpression("[a-zA-Z ]{2,20}", ErrorMessage = "Solo admite letras entre 2 y 20")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "Este campo es obligatorio")]
        [RegularExpression("[a-zA-Z ]{2,20}", ErrorMessage = "Solo admite letras entre 2 y 20")]
        public string Apellido { get; set; }

        [Required(ErrorMessage = "Este campo es obligatorio")]
        public string Dni { get; set; }
        //[Required(ErrorMessage = "Este campo es obligatorio")]
        public string ImageDni { get; set; }

        [Required(ErrorMessage = "Este campo es obligatorio")]
        [RegularExpression("^[a-zA-Z0-9-_.]+@([a-zA-Z0-9]+.)[a-zA-Z]{2,6}$", ErrorMessage = "E-mail no valido")]
        public string Correo { get; set; }

        [Required(ErrorMessage = "Este campo es obligatorio")]
        [RegularExpression("[0-9]{9}", ErrorMessage = "Valores incorrectos")]
        public string Telefono { get; set; }
    }
}
