using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pos_backend.Models
{
    public class ProductoVenta
    {
        public int Id { get; set; }
        public int Venta { get; set; }
        public int Producto { get; set; }
        public int Cantidad { get; set; }
    }
}
