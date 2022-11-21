using System;
using System.Collections.Generic;

namespace APICafeteria.Models
{
    public partial class Articulo
    {
        public int Id { get; set; }
        public string Marca { get; set; } = null!;
        public string Descripcion { get; set; } = null!;
        public int Precio { get; set; }
        public string Disponibles { get; set; } = null!;
        public string Estado { get; set; } = null!;
        public int? IdCategoria { get; set; }
    }
}
