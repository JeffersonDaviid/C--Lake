using System;
using System.Collections.Generic;

namespace EF_Multiple_Tables.Models;

public partial class Pedido
{
    public int Id { get; set; }

    public int Usuarioid { get; set; }

    public DateTime Fecha { get; set; }

    public string? Estado { get; set; }

    public decimal? Total { get; set; }

    public virtual ICollection<Detallepedido> Detallepedidos { get; set; } = new List<Detallepedido>();

    public virtual Usuario Usuario { get; set; } = null!;
}
