using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pos_backend.Models
{
    public class Venta
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public float Monto { get; set; }
        public DateTime FechaCreacion { get; set; }
    }
}
