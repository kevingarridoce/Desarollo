using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProyectoRedes.Models
{
    public class Equipos
    {
        public int EquiposID { get; set; }
        public string Modelo { get; set; }
        public string Marca { get; set; }
        public string Tipo { get; set; }
        [Required(ErrorMessage = "Es necesario conocer el numero Serial")]
        [DisplayName("Numero Serial")]
        public string Serial { get; set; }
        public string Descripcion { get; set; }
        public virtual ICollection<Reserva> Reserva { get; set; }
    }
}