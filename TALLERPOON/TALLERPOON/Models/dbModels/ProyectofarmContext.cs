using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace TALLERPOON.Models.dbModels;

public partial class ProyectofarmContext : DbContext
{
    public ProyectofarmContext()
    {
    }

    public ProyectofarmContext(DbContextOptions<ProyectofarmContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Almacen> Almacens { get; set; }

    public virtual DbSet<Carrito> Carritos { get; set; }

    public virtual DbSet<Detalleap> Detalleaps { get; set; }

    public virtual DbSet<Detalleea> Detalleeas { get; set; }

    public virtual DbSet<Detalleev> Detalleevs { get; set; }

    public virtual DbSet<Detallepp> Detallepps { get; set; }

    public virtual DbSet<Empleado> Empleados { get; set; }

    public virtual DbSet<Producto> Productos { get; set; }

    public virtual DbSet<Proveedor> Proveedors { get; set; }

    public virtual DbSet<Turno> Turnos { get; set; }

    public virtual DbSet<Ventum> Venta { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=.;Database=proyectofarmgeneradan;Trusted_Connection=True; TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Almacen>(entity =>
        {
            entity.HasKey(e => e.IdAlm).HasName("PK_almacen_Id_alm");
        });

        modelBuilder.Entity<Carrito>(entity =>
        {
            entity.HasOne(d => d.IdEmplNavigation).WithMany(p => p.Carritos)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_carrito_empleado");

            entity.HasOne(d => d.IdProdNavigation).WithMany(p => p.Carritos)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_carrito_productos");
        });

        modelBuilder.Entity<Detalleap>(entity =>
        {
            entity.HasKey(e => e.IdDetalleap).HasName("PK_detalleap_Id_detalleap");

            entity.Property(e => e.IdDetalleap).ValueGeneratedNever();

            entity.HasOne(d => d.IdAlmNavigation).WithMany(p => p.Detalleaps)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_detalleap_almacen");

            entity.HasOne(d => d.IdDetalleapNavigation).WithOne(p => p.Detalleap)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_detalleap_productos");
        });

        modelBuilder.Entity<Detalleea>(entity =>
        {
            entity.HasKey(e => e.IdDetalleEa).HasName("PK_detalleea_id_detalleEA");

            entity.HasOne(d => d.IdAlmNavigation).WithMany(p => p.Detalleeas)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_detalleea_almacen");

            entity.HasOne(d => d.IdEmplNavigation).WithMany(p => p.Detalleeas)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_detalleea_empleado");
        });

        modelBuilder.Entity<Detalleev>(entity =>
        {
            entity.HasKey(e => e.IdDetalleEp).HasName("PK_detalleev_Id_detalleEP");

            entity.HasOne(d => d.IdEmplNavigation).WithMany(p => p.Detalleevs)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_detalleev_empleado");

            entity.HasOne(d => d.IdProvNavigation).WithMany(p => p.Detalleevs)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_detalleev_proveedor");
        });

        modelBuilder.Entity<Detallepp>(entity =>
        {
            entity.HasKey(e => e.IdDetallepp).HasName("PK_detallepp_id_detallepp");

            entity.HasOne(d => d.IdProdNavigation).WithMany(p => p.Detallepps)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_detallepp_productos");

            entity.HasOne(d => d.IdProvNavigation).WithMany(p => p.Detallepps)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_detallepp_proveedor");
        });

        modelBuilder.Entity<Empleado>(entity =>
        {
            entity.HasKey(e => e.IdEmpl).HasName("PK_empleado_Id_empl");

            entity.HasOne(d => d.TurnEmplNavigation).WithMany(p => p.Empleados)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_empleado_turno");
        });

        modelBuilder.Entity<Producto>(entity =>
        {
            entity.HasKey(e => e.IdProd).HasName("PK_productos_Id_prod");
        });

        modelBuilder.Entity<Proveedor>(entity =>
        {
            entity.HasKey(e => e.IdProv).HasName("PK_proveedor_Id_prov");
        });

        modelBuilder.Entity<Ventum>(entity =>
        {
            entity.HasKey(e => e.IdVent).HasName("PK_venta_Id_vent");

            entity.HasOne(d => d.IdEmplNavigation).WithMany(p => p.Venta)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_venta_empleado");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
