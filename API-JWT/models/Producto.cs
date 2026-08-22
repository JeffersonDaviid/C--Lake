namespace RestAPI.Models;

public class Producto
{
    public int Id { get; }
    public string Name { get; set; }
    public int Quantity { get; set; }
    public decimal Price { get; set; }

    public Producto(int id, string name, int quantity, decimal price)
    {
        Id = id;
        Name = name;
        Quantity = quantity;
        Price = price;
    }
}