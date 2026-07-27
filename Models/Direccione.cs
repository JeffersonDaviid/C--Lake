using System;
using System.Collections.Generic;

namespace EF_Multiple_Tables.Models;

public partial class Direccione
{
    public int Id { get; set; }

    public int Usuarioid { get; set; }

    public string? Ciudad { get; set; }

    public string? Sector { get; set; }

    public string? Calleprincipal { get; set; }

    public string? Referencia { get; set; }

    public virtual Usuario Usuario { get; set; } = null!;
}
