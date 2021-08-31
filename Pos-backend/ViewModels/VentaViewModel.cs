using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pos_backend.ViewModels
{
    public class VentaViewModel
    {
        public string UserId { get; set; }
        public float Monto { get; set; }
        public IEnumerable<ProductoVentaViewModel> Productos { get; set; }
    }
}
