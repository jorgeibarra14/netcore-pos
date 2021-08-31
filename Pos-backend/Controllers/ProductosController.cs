using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Pos_backend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pos_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductosController : ControllerBase
    {
        private readonly IConfiguration configuration;
        private readonly string connection;
        private readonly AppDbContext context;

        public ProductosController(AppDbContext context)
        {
            this.context = context;
        }
        [HttpGet]
        public IEnumerable<Producto> Get()
        {

            IEnumerable<Producto> productos = context.Productos.ToList();
            return productos;
        }
        [HttpGet("{sku}")]
        public IEnumerable<Producto> GetBySku(string sku)
        {

            IEnumerable<Producto> productos = context.Productos.ToList();
            return productos.Where(p => p.Sku == sku);

        }
        [HttpPost]
        public async Task<IActionResult> Create(Producto producto)
        {
            context.Productos.Add(producto);
            await context.SaveChangesAsync();
            return Ok();
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Producto producto, int id)
        {
            var std = context.Productos.First(p => p.Id == id);
            std.Sku = producto.Sku;
            std.Nombre = producto.Nombre;
            std.Precio = producto.Precio;
            await context.SaveChangesAsync();
            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(Producto producto)
        {
            context.Remove(producto);
            await context.SaveChangesAsync();
            return Ok();
        }
    }
}
