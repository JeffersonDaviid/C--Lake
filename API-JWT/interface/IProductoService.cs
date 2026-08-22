using RestAPI.Models;

namespace RestAPI.Interface;

public interface IProductoService
{
    // Usamos Task para indicar que estos métodos son asíncronos.
    // Si retornaran un valor, usaríamos Task<T> donde T es el tipo de dato que se espera retornar.
    // Si no retornan un valor, usamos Task sin tipo genérico.
    Task<List<Producto>> GetAll();
    Task<Producto> GetById(int id);
    Task Add(Producto producto);
    Task Update(Producto producto);
    Task Delete(int id);
}
