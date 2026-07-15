// L I N Q
// Lista de Personas
var p1 = new Persona { Nombre = "Jefferson", Apellido = "Chileno", Edad = 24 };
var p2 = new Persona { Nombre = "Emilio", Apellido = "Perez", Edad = 22 };
var p3 = new Persona { Nombre = "Daniela", Apellido = "Perez", Edad = 33 };
var p4 = new Persona { Nombre = "Joselyn", Apellido = "Secretlastname", Edad = 27 };

// ARREGLOS
var gente = new Persona[] { p1, p2, p3, p4 };
Console.WriteLine("\n\nLista de todas las personas");
foreach (var p in gente)
{
    Console.WriteLine($"{p.Nombre} {p.Apellido} - {p.Edad} años");
}


// WHERE
var mayores = gente.Where(p => p.Edad >= 25);
Console.WriteLine("\n\nPersonas mayores de 25 años");
foreach (var p in mayores)
{
    Console.WriteLine($"{p.Nombre} {p.Apellido}");
}


// WHERE 
var perezz = gente.Where(p => p.Apellido == "Perez");
Console.WriteLine("\n\nPersonas con apellido Perez");
foreach (var p in perezz)
{
    Console.WriteLine($"{p.Nombre} {p.Apellido}");
}

// SUMA 
var sumaEdades = gente.Sum(g => g.Edad);
Console.WriteLine("\n\nLas personas suman " + sumaEdades);
// Promedio 
var promedioEdades = sumaEdades / gente.Length;
Console.WriteLine("Las personas promedian " + promedioEdades);
// Maximo edad 
var pMayor = gente.Max(p => p.Edad);
Console.WriteLine("El más mayor es " + pMayor);
// Promedio de los Perez 
var promedioPerez = gente
    .Where(p => p.Apellido == "Perez")
    .Average(p => p.Edad);
Console.WriteLine("El promedio de los Perez " + promedioPerez);

// Ordenados por edad
var ordenados = gente.OrderBy(p => p.Edad);
Console.WriteLine("\n\nPersonas ordenadas por edad");
foreach (var p in ordenados)
{
    Console.WriteLine($"{p.Nombre} {p.Apellido}");
}

// Ordenados por Apellido DESC
var ordenadosByLastname = gente.OrderByDescending(p => p.Apellido);
Console.WriteLine("\n\nPersonas ordenadas por Apellido DESC");
foreach (var p in ordenadosByLastname)
{
    Console.WriteLine($"{p.Apellido} {p.Nombre}");
}

// CHEQUES
Console.WriteLine("\n\n==================");
Console.WriteLine("==========================");
Console.WriteLine("OPERACIONES CON CHEQUES");

// LISTAS
var cheques = new List<Cheque>();
cheques.Add(new Cheque { Banco = "Vision Found", Numero = 101, Monto = 250.45M, Fecha = new DateTime(2026, 07, 23) });
cheques.Add(new Cheque { Banco = "Vision Found", Numero = 300, Monto = 470.45M, Fecha = new DateTime(2026, 05, 26) });
cheques.Add(new Cheque { Banco = "Bolivariano", Numero = 109, Monto = 870.70M, Fecha = new DateTime(2026, 02, 21) });
cheques.Add(new Cheque { Banco = "Produbanco", Numero = 203, Monto = 500.45M, Fecha = new DateTime(2026, 01, 07) });
cheques.Add(new Cheque { Banco = "Guayaquil", Numero = 738, Monto = 273.45M, Fecha = new DateTime(2026, 03, 11) });
cheques.Add(new Cheque { Banco = "Pichincha", Numero = 412, Monto = 640.20M, Fecha = new DateTime(2026, 04, 18) });
cheques.Add(new Cheque { Banco = "Vision Found", Numero = 515, Monto = 320.10M, Fecha = new DateTime(2026, 06, 02) });
cheques.Add(new Cheque { Banco = "Bolivariano", Numero = 622, Monto = 910.00M, Fecha = new DateTime(2026, 08, 09) });
cheques.Add(new Cheque { Banco = "Produbanco", Numero = 744, Monto = 150.75M, Fecha = new DateTime(2026, 09, 14) });
cheques.Add(new Cheque { Banco = "Guayaquil", Numero = 899, Monto = 405.30M, Fecha = new DateTime(2026, 10, 27) });

// SUMA total en cheques
var totalCheques = cheques.Sum(c => c.Monto);
Console.WriteLine("\n\nLos cheques suman " + totalCheques);





class Persona
{
    public string Nombre { get; set; }
    public string Apellido { get; set; }
    public int Edad { get; set; }
}


class Cheque
{
    public string Banco { get; set; }
    public int Numero { get; set; }
    public decimal Monto { get; set; }
    public DateTime Fecha { get; set; }

}