using System;
using System.Collections.Generic;

namespace Web2Hotel.Models
{
    public partial class Contacto
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Descripcion { get; set; }
        public string Email { get; set; }
        public string Telefono { get; set; }
        public string Estado { get; set; }
    }
}
