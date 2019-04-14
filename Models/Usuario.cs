using System;
using System.Collections.Generic;

namespace Web2Hotel.Models
{
    public partial class Usuario
    {
        public Usuario()
        {
            ReservaCreation = new HashSet<Reserva>();
            ReservaUsuario = new HashSet<Reserva>();
        }

        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Nombre { get; set; }
        public string Apelllido { get; set; }
        public string Email { get; set; }
        public string Telefono { get; set; }
        public string Role { get; set; }
        public string Estado { get; set; }

        public virtual ICollection<Reserva> ReservaCreation { get; set; }
        public virtual ICollection<Reserva> ReservaUsuario { get; set; }
    }
}
