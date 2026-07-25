using EntitieFramework.Models;

var dbContext = new TiendaConext();


// Select de la DB
var productos = dbContext.Productos;
foreach (Producto p in productos)
{
    Console.WriteLine($"{p.Nombre}, {p.Color}");
}


// Insertar en DB
var productoNuevo = new Producto() { Nombre = "Tostadora", Color = "Verde", Costo = 390.00M };
dbContext.Productos.Add(productoNuevo); // NO hace nada en DB, solo le avisa a EF
dbContext.Productos.Add(new Producto() { Nombre = "Computadora", Color = "Gris", Costo = 1300M }); // NO hace nada en DB, solo le avisa a EF
dbContext.SaveChanges(); // Ahora inserta, solo si las dos insert OK


productos = dbContext.Productos;

foreach (var p in productos)
{
    Console.WriteLine($"{p.Id} {p.Nombre} {p.Costo} {p.Color}");
}