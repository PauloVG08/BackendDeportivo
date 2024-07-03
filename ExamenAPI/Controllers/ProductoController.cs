using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ExamenAPI.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ExamenAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductoController : ControllerBase
    {
        private readonly ProductoContext _context;

        public ProductoController(ProductoContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Producto>>> GetProductos()
        {
            try
            {
                var productos = await _context.Producto.ToListAsync();
                if (productos == null || productos.Count == 0)
                {
                    return NotFound(); 
                }

                return Ok(productos); 
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno del servidor: {ex.Message}");
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Producto>> GetProducto(int id)
        {
            var producto = await _context.Producto.FindAsync(id);

            if (producto == null)
            {
                return NotFound(); 
            }

            return Ok(producto);
        }

        [HttpGet("categoria/{categoria}")]
        public async Task<ActionResult<IEnumerable<Producto>>> GetProductosByCategoria(string categoria)
        {
            var productos = await _context.Producto
                .Where(p => p.Categoria.ToUpper() == categoria.ToUpper())
                .ToListAsync();

            if (productos == null || productos.Count == 0)
            {
                return NotFound();
            }

            return Ok(productos);
        }

        [HttpPost]
        public async Task<ActionResult<Producto>> PostProducto(Producto producto)
        {
            try
            {
                _context.Producto.Add(producto);
                await _context.SaveChangesAsync();

                return CreatedAtAction(nameof(GetProducto), new { id = producto.ProductoId }, producto);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno del servidor: {ex.Message}");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProducto(int id)
        {
            try
            {
                var producto = await _context.Producto.FindAsync(id);
                if (producto == null)
                {
                    return NotFound();
                }

                _context.Producto.Remove(producto);
                await _context.SaveChangesAsync();

                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno del servidor: {ex.Message}");
            }
        }
    }
}
