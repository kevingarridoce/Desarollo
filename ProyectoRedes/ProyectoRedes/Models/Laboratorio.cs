using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProyectoRedes.Models
{
    public class Laboratorio
    {
        public int LaboratorioID { get; set; }

        [Required(ErrorMessage = "Es necesario conocer el laboratorio")]
        [DisplayName("Numero de laboratorio")]
        public int NumClase { get; set; }
        public int Capacidad { get; set; }
        public virtual ICollection<Reserva> Reserva { get; set; }
    }
}