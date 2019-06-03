using System;

namespace Web2Hotel.Dto
{
    public class ReservaDto
    {
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
        public int UsusarioId { get; set; }
        public int[] Habitaciones { get; set; }
    }
}