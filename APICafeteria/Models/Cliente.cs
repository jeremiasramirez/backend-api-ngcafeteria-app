using System;
using System.Collections.Generic;

namespace APICafeteria.Models
{
    public partial class Cliente
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string? FechaRegistro { get; set; }
        public int? IdUsuario { get; set; }
    }
}
