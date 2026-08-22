using System;
using System.Collections.Generic;

namespace EF_Multiple_Tables.Models;

public partial class Detallepedido
{
    public int Id { get; set; }

    public int Pedidoid { get; set; }

    public int Productoid { get; set; }

    public int Cantidad { get; set; }

    public decimal Preciounitario { get; set; }

    public virtual Pedido Pedido { get; set; } = null!;

    public virtual Producto Producto { get; set; } = null!;
}
