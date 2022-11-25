using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FranMotors.Models
{
    public class Account
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Este campo es obligatorio")]
        [RegularExpression("[a-zA-Z ]{2,20}", ErrorMessage = "Solo admite letras entre 2 y 20")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "Este campo es obligatorio")]
        [RegularExpression("[a-zA-Z ]{2,20}", ErrorMessage = "Solo admite letras entre 2 y 20")]
        public string Apellidos { get; set; }

        [Required(ErrorMessage = "Este campo es obligatorio")]
        [RegularExpression("[0-9]{8}", ErrorMessage = "Valores incorrectos")]
        public string Dni { get; set; }

        [Required(ErrorMessage = "Este campo es obligatorio")]
        [RegularExpression("/^[a-zA-Z0-9.!#$%&'*+/=?^_`{|}~-]+@[a-zA-Z0-9-]+(?:\.[a-zA-Z0-9-]+)*$/;", ErrorMessage = "E-mail no valido")]
        public string Correo { get; set; }

        [Required(ErrorMessage = "Este campo es obligatorio")]
        [RegularExpression("[0-9]{9}", ErrorMessage = "Valores incorrectos")]
        public string Telefono { get; set; }

        public string Tipo { get; set; }

        [Required(ErrorMessage = "Este campo es obligatorio")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Este campo es obligatorio")]
        //[RegularExpression("(?=.*)(?=.*[a-zA-Z]).{10,50}")]
        public string Password { get; set; }

        public bool Estado { get; set; }
    }
}
