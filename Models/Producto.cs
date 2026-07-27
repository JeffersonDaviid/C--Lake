using System;
using System.Collections.Generic;

namespace EF_Multiple_Tables.Models;

public partial class Producto
{
    public int Id { get; set; }

    public int Categoriaid { get; set; }

    public string Nombre { get; set; } = null!;

    public decimal Precio { get; set; }

    public bool? Disponible { get; set; }

    public virtual Categoria Categoria { get; set; } = null!;

    public virtual ICollection<Detallepedido> Detallepedidos { get; set; } = new List<Detallepedido>();
}
