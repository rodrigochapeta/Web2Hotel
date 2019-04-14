using System;
using System.Collections.Generic;

namespace Web2Hotel.Models
{
    public partial class Habitacion
    {
        public Habitacion()
        {
            Reserva = new HashSet<Reserva>();
        }

        public int Id { get; set; }
        public int Numero { get; set; }
        public int Capacidad { get; set; }

        public virtual ICollection<Reserva> Reserva { get; set; }
    }
}
