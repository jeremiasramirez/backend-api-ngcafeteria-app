using System;
using System.Collections.Generic;

namespace APICafeteria.Models
{
    public partial class Facturacion
    {
        public int Id { get; set; }
        public string NombreCliente { get; set; } = null!;
        public string NombreProducto { get; set; } = null!;
        public int Cantidad { get; set; }
        public int Subtotal { get; set; }
        public int Total { get; set; }
    }
}
