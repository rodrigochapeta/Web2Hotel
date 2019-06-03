using System;
using System.Collections.Generic;

namespace Web2Hotel.Models
{
    public partial class Reserva
    {
        public int Id { get; set; }
        public int CreationId { get; set; }
        public DateTime CreationDate { get; set; }
        public int HabitacionId { get; set; }
        public string Estado { get; set; }
        public int UsuarioId { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }

        public virtual Usuario Creation { get; set; }
        public virtual Habitacion Habitacion { get; set; }
        public virtual Usuario Usuario { get; set; }
    }

}
