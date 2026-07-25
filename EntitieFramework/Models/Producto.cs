using System;
using System.Collections.Generic;

namespace EntitieFramework.Models;

public partial class Producto
{
    public long Id { get; set; }

    public string? Nombre { get; set; }

    public string? Color { get; set; }

    public decimal? Costo { get; set; }
}
