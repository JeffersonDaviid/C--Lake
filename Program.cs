

using EF_Multiple_Tables.Models;

var db = new TiendaContext();


var users = db.Usuarios;

foreach (var user in users)
{
    Console.WriteLine($"{user.Nombre}");
}