using Pos_backend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pos_backend.ViewModels
{
    public class ProductoVentaViewModel
    {
        public Producto Producto { get; set; }
        public int Cantidad { get; set; }
    }
}
