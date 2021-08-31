using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace Pos_backend.Models
{
    public partial class Producto
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public double Precio { get; set; }
        public string Sku { get; set; }
        public DateTime? FechaCreacion { get; set; }
    }
}
