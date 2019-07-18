using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProyectoRedes.Models
{
    public class Profesor
    {
        public int ProfesorID { get; set; }
        [Required(ErrorMessage = "Es necesario conocer el nombre del profesor")]
        public string Nombre { get; set; }
        [Required(ErrorMessage = "Es necesario conocer el apellido del profesor")]
        public string Apellido { get; set; }
        public string Especialidad { get; set; }
        public virtual ICollection<Reserva> Reserva { get; set; }
    }
}