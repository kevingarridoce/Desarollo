using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProyectoRedes.Models
{
    public class Reserva
    {
        public int ReservaID { get; set; }
        [Required(ErrorMessage = "Es necesario conocer el laboratorio")]
        [DisplayName("Laboratorio")]
        public int LaboratorioID { get; set; }

        [Required(ErrorMessage = "Es necesario conocer el Profesor a cargo")]
        [DisplayName("Profesor")]
        public int ProfesorID { get; set; }

        [Required(ErrorMessage = "Es necesario conocer el equipo a usar")]
        [DisplayName("Equipo")]
        public int EquiposID { get; set; }
        [Required(ErrorMessage = "Es necesario conocer el dia que se hace la reserva")]
        [DisplayName("Fecha de reserva")]
        public DateTime FechaReserva { get; set; }
        [Required(ErrorMessage = "Es necesario conocer el dia que se hara la practica")]
        [DisplayName("Dia de practica")]
        public DateTime FechaDiaLab { get; set; }
        public string Descripcion { get; set; }
        [DisplayName("Cantidad de equipos")]
        public int CantidadEquipos { get; set; }
        [DisplayName("Laboratorio")]
        public virtual Laboratorio Laboratorio { get; set; }
        [DisplayName("Profesor")]
        public virtual Profesor Profesor { get; set; }
        [DisplayName("Equipo")]
        public virtual Equipos Equipos { get; set; }
    }
}