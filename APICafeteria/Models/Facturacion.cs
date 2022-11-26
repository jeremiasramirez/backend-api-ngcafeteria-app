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
        public double Subtotal { get; set; }
        public double Total { get; set; }
        public string? Estado { get; set; }
    }
}
