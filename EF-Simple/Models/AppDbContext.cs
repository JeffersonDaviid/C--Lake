using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace EntitieFramework.Models;

public partial class TiendaConext : DbContext
{
    public TiendaConext()
    {
    }

    public TiendaConext(DbContextOptions<TiendaConext> options)
        : base(options)
    {
    }

    public virtual DbSet<Producto> Productos { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseNpgsql("Host=localhost;Port=5555;Database=db_tienda;Username=user_tienda;Password=pass_tienda");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Producto>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("Productos_pkey");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Color).HasMaxLength(30);
            entity.Property(e => e.Costo).HasColumnType("money");
            entity.Property(e => e.Nombre).HasMaxLength(50);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
