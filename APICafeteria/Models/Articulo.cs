using System;
using System.Collections.Generic;

namespace APICafeteria.Models
{
    public partial class Articulo
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = null!;
        public int Cantidad { get; set; }
        public double Precio { get; set; }
    }
}
