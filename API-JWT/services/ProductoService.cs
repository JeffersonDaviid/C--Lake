using RestAPI.Interface;
using RestAPI.Models;

namespace RestAPI.services;

public class ProductoService : IProductoService
{
    private readonly List<Producto> _productos = [];

    public ProductoService()
    {
        // Agregar algunos productos de ejemplo
        _productos.Add(new Producto(1, "Producto A", 10, 9.99m));
        _productos.Add(new Producto(2, "Producto B", 5, 19.99m));
        _productos.Add(new Producto(3, "Producto C", 20, 4.99m));
    }

    public Task<List<Producto>> GetAll()
    {
        // SIMULAR UNA OPERACIÓN ASÍNCRONA
        // Task.FromResult se usa para convertir un resultado sincrónico en una tarea asíncrona.
        return Task.FromResult(_productos);
    }

    public Task<Producto> GetById(int id)
    {
        var producto = _productos.FirstOrDefault(p => p.Id == id);
        // SIMULAR UNA OPERACIÓN ASÍNCRONA
        return Task.FromResult(producto);
    }

    public Task Add(Producto producto)
    {
        _productos.Add(producto);
        // SIMULAR UNA OPERACIÓN ASÍNCRONA
        // Task.CompletedTask se usa no para retornar un valor.
        return Task.CompletedTask;
    }

    public Task Update(Producto producto)
    {
        var existingProducto = _productos.FirstOrDefault(p => p.Id == producto.Id);
        if (existingProducto != null)
        {
            existingProducto.Name = producto.Name;
            existingProducto.Quantity = producto.Quantity;
            existingProducto.Price = producto.Price;
        }
        return Task.CompletedTask;
    }

    public Task Delete(int id)
    {
        var producto = _productos.FirstOrDefault(p => p.Id == id);
        if (producto != null)
        {
            _productos.Remove(producto);
        }
        return Task.CompletedTask;
    }



}