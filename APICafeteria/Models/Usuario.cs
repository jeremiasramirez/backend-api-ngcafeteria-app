using System;
using System.Collections.Generic;

namespace APICafeteria.Models
{
    public partial class Usuario
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = null!;
        public string TipoDeUsuario { get; set; } = null!;
        public string Estado { get; set; } = null!;
        public string? Clave { get; set; }
        public string? SessionKey { get; set; }
        public string? Email { get; set; }
    }
}
