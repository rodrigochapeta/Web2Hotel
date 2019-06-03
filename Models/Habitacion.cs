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
        public int Capacidad { get; set; } // 0 = deluxe , 1 = standard , 2 = ejecutiva // 8 5 may  3 men
        public virtual ICollection<Reserva> Reserva { get; set; }
    }
}
