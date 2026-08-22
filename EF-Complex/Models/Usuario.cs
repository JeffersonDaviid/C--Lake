using System;
using System.Collections.Generic;

namespace EF_Multiple_Tables.Models;

public partial class Usuario
{
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;

    public string Apellido { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string? Telefono { get; set; }

    public DateOnly Fecharegistro { get; set; }

    public virtual ICollection<Direccione> Direcciones { get; set; } = new List<Direccione>();

    public virtual ICollection<Pedido> Pedidos { get; set; } = new List<Pedido>();
}
