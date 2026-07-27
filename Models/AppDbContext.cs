using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace EF_Multiple_Tables.Models;

public partial class TiendaContext : DbContext
{
    public TiendaContext()
    {
    }

    public TiendaContext(DbContextOptions<TiendaContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Categoria> Categorias { get; set; }

    public virtual DbSet<Detallepedido> Detallepedidos { get; set; }

    public virtual DbSet<Direccione> Direcciones { get; set; }

    public virtual DbSet<Pedido> Pedidos { get; set; }

    public virtual DbSet<Producto> Productos { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseNpgsql("Host=localhost;Port=5555;Database=db_tienda;Username=user_tienda;Password=pass_tienda");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Categoria>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("categorias_pkey");

            entity.ToTable("categorias");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Nombre)
                .HasMaxLength(80)
                .HasColumnName("nombre");
        });

        modelBuilder.Entity<Detallepedido>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("detallepedido_pkey");

            entity.ToTable("detallepedido");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Cantidad).HasColumnName("cantidad");
            entity.Property(e => e.Pedidoid).HasColumnName("pedidoid");
            entity.Property(e => e.Preciounitario)
                .HasPrecision(10, 2)
                .HasColumnName("preciounitario");
            entity.Property(e => e.Productoid).HasColumnName("productoid");

            entity.HasOne(d => d.Pedido).WithMany(p => p.Detallepedidos)
                .HasForeignKey(d => d.Pedidoid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_detalle_pedido");

            entity.HasOne(d => d.Producto).WithMany(p => p.Detallepedidos)
                .HasForeignKey(d => d.Productoid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_detalle_producto");
        });

        modelBuilder.Entity<Direccione>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("direcciones_pkey");

            entity.ToTable("direcciones");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Calleprincipal)
                .HasMaxLength(120)
                .HasColumnName("calleprincipal");
            entity.Property(e => e.Ciudad)
                .HasMaxLength(80)
                .HasColumnName("ciudad");
            entity.Property(e => e.Referencia).HasColumnName("referencia");
            entity.Property(e => e.Sector)
                .HasMaxLength(100)
                .HasColumnName("sector");
            entity.Property(e => e.Usuarioid).HasColumnName("usuarioid");

            entity.HasOne(d => d.Usuario).WithMany(p => p.Direcciones)
                .HasForeignKey(d => d.Usuarioid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_direccion_usuario");
        });

        modelBuilder.Entity<Pedido>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("pedidos_pkey");

            entity.ToTable("pedidos");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Estado)
                .HasMaxLength(30)
                .HasColumnName("estado");
            entity.Property(e => e.Fecha)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("fecha");
            entity.Property(e => e.Total)
                .HasPrecision(10, 2)
                .HasColumnName("total");
            entity.Property(e => e.Usuarioid).HasColumnName("usuarioid");

            entity.HasOne(d => d.Usuario).WithMany(p => p.Pedidos)
                .HasForeignKey(d => d.Usuarioid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_pedido_usuario");
        });

        modelBuilder.Entity<Producto>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("productos_pkey");

            entity.ToTable("productos");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Categoriaid).HasColumnName("categoriaid");
            entity.Property(e => e.Disponible)
                .HasDefaultValue(true)
                .HasColumnName("disponible");
            entity.Property(e => e.Nombre)
                .HasMaxLength(120)
                .HasColumnName("nombre");
            entity.Property(e => e.Precio)
                .HasPrecision(10, 2)
                .HasColumnName("precio");

            entity.HasOne(d => d.Categoria).WithMany(p => p.Productos)
                .HasForeignKey(d => d.Categoriaid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_producto_categoria");
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("usuarios_pkey");

            entity.ToTable("usuarios");

            entity.HasIndex(e => e.Email, "usuarios_email_key").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Apellido)
                .HasMaxLength(100)
                .HasColumnName("apellido");
            entity.Property(e => e.Email)
                .HasMaxLength(150)
                .HasColumnName("email");
            entity.Property(e => e.Fecharegistro).HasColumnName("fecharegistro");
            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .HasColumnName("nombre");
            entity.Property(e => e.Telefono)
                .HasMaxLength(20)
                .HasColumnName("telefono");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
