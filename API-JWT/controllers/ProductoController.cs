using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RestAPI.Interface;
using RestAPI.Models;

namespace RestAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductoController : ControllerBase
{
    private readonly IProductoService _productoService;

    public ProductoController(IProductoService productoService)
    {
        _productoService = productoService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var productos = await _productoService.GetAll();
        return Ok(productos);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var producto = await _productoService.GetById(id);
        if (producto == null)
        {
            return NotFound();
        }
        return Ok(producto);
    }

    [HttpPost]
    [Authorize]
    public async Task<IActionResult> Add(Producto producto)
    {
        await _productoService.Add(producto);
        return CreatedAtAction(nameof(GetById), new { id = producto.Id }, producto);
    }

    [HttpPut("{id}")]
    [Authorize]
    public async Task<IActionResult> Update(int id, Producto producto)
    {
        if (id != producto.Id)
        {
            return BadRequest();
        }
        var existingProducto = await _productoService.GetById(id);
        if (existingProducto == null)
        {
            return NotFound();
        }
        await _productoService.Update(producto);
        return NoContent();
    }

    [HttpDelete("{id}")]
    [Authorize]
    public async Task<IActionResult> Delete(int id)
    {
        var existingProducto = await _productoService.GetById(id);
        if (existingProducto == null)
        {
            return NotFound();
        }
        await _productoService.Delete(id);
        return NoContent();
    }
}