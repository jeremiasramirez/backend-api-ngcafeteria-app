using System;
using System.Collections.Generic;

namespace APICafeteria.Models
{
    public partial class Empleado
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = null!;
        public string Cedula { get; set; } = null!;
        public string Tanda { get; set; } = null!;
        public string FechaIngreso { get; set; } = null!;
        public string Estado { get; set; } = null!;
        public string? Cargo { get; set; }
        public string? Email { get; set; }
        public string? Emails { get; set; }
    }
}
