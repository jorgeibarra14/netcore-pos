using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Pos_backend.Models;
using Pos_backend.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pos_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VentasController : ControllerBase
    {
        private readonly AppDbContext context;

        public VentasController(AppDbContext context)
        {
            this.context = context;
        }
        [HttpPost]
        public async Task<IActionResult> Create(VentaViewModel ventaViewModel)
        {
            Venta venta = new Venta
            {
                Monto = ventaViewModel.Monto,
                UserId = ventaViewModel.UserId
            };
            context.Ventas.Add(venta);
            await context.SaveChangesAsync();
            int ventaId = venta.Id;

            foreach (var item in ventaViewModel.Productos)
            {
                ProductoVenta pv = new ProductoVenta
                {
                    Cantidad = item.Cantidad,
                    Producto = item.Producto.Id,
                    Venta = ventaId
                };
                context.ProductosVentas.Add(pv);
                
            }
            await context.SaveChangesAsync();
            return Ok(ventaId);
        }
    }
}
