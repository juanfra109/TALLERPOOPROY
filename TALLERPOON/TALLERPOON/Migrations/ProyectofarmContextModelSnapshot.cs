﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TALLERPOON.Models.dbModels;

#nullable disable

namespace TALLERPOON.Migrations
{
    [DbContext(typeof(ProyectofarmContext))]
    partial class ProyectofarmContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("TALLERPOON.Models.dbModels.Almacen", b =>
                {
                    b.Property<int>("IdAlm")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Id_alm");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdAlm"));

                    b.Property<string>("NomAlm")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("nvarchar(60)")
                        .HasColumnName("nom_alm");

                    b.HasKey("IdAlm")
                        .HasName("PK_almacen_Id_alm");

                    b.ToTable("almacen", "farmacia");
                });

            modelBuilder.Entity("TALLERPOON.Models.dbModels.Carrito", b =>
                {
                    b.Property<int>("IdEmpl")
                        .HasColumnType("int")
                        .HasColumnName("id_empl");

                    b.Property<int>("IdProd")
                        .HasColumnType("int")
                        .HasColumnName("id_prod");

                    b.Property<int>("Cantidad")
                        .HasColumnType("int")
                        .HasColumnName("cantidad");

                    b.Property<decimal>("Total")
                        .HasColumnType("money")
                        .HasColumnName("total");

                    b.HasKey("IdEmpl", "IdProd");

                    b.HasIndex(new[] { "IdProd" }, "IX_carrito_id_prod");

                    b.ToTable("carrito");
                });

            modelBuilder.Entity("TALLERPOON.Models.dbModels.Detalleap", b =>
                {
                    b.Property<int>("IdDetalleap")
                        .HasColumnType("int")
                        .HasColumnName("Id_detalleap");

                    b.Property<int>("IdAlm")
                        .HasColumnType("int")
                        .HasColumnName("Id_alm");

                    b.Property<int>("IdProd")
                        .HasColumnType("int")
                        .HasColumnName("id_prod");

                    b.HasKey("IdDetalleap")
                        .HasName("PK_detalleap_Id_detalleap");

                    b.HasIndex(new[] { "IdAlm" }, "IX_detalleap_Id_alm");

                    b.ToTable("detalleap", "farmacia");
                });

            modelBuilder.Entity("TALLERPOON.Models.dbModels.Detalleea", b =>
                {
                    b.Property<int>("IdDetalleEa")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id_detalleEA");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdDetalleEa"));

                    b.Property<DateTime>("FechaDetalleEa")
                        .HasColumnType("date")
                        .HasColumnName("fecha_detalleEA");

                    b.Property<int>("IdAlm")
                        .HasColumnType("int")
                        .HasColumnName("id_alm");

                    b.Property<int>("IdEmpl")
                        .HasColumnType("int")
                        .HasColumnName("id_empl");

                    b.HasKey("IdDetalleEa")
                        .HasName("PK_detalleea_id_detalleEA");

                    b.HasIndex(new[] { "IdAlm" }, "IX_detalleea_id_alm");

                    b.HasIndex(new[] { "IdEmpl" }, "IX_detalleea_id_empl");

                    b.ToTable("detalleea", "farmacia");
                });

            modelBuilder.Entity("TALLERPOON.Models.dbModels.Detalleev", b =>
                {
                    b.Property<int>("IdDetalleEp")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Id_detalleEP");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdDetalleEp"));

                    b.Property<DateTime>("FechDetalleEp")
                        .HasColumnType("date")
                        .HasColumnName("fech_detalleEP");

                    b.Property<int>("IdEmpl")
                        .HasColumnType("int")
                        .HasColumnName("Id_empl");

                    b.Property<int>("IdProv")
                        .HasColumnType("int")
                        .HasColumnName("Id_prov");

                    b.HasKey("IdDetalleEp")
                        .HasName("PK_detalleev_Id_detalleEP");

                    b.HasIndex(new[] { "IdEmpl" }, "IX_detalleev_Id_empl");

                    b.HasIndex(new[] { "IdProv" }, "IX_detalleev_Id_prov");

                    b.ToTable("detalleev", "farmacia");
                });

            modelBuilder.Entity("TALLERPOON.Models.dbModels.Detallepp", b =>
                {
                    b.Property<int>("IdDetallepp")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id_detallepp");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdDetallepp"));

                    b.Property<int>("CantProd")
                        .HasColumnType("int")
                        .HasColumnName("cant_prod");

                    b.Property<int>("IdProd")
                        .HasColumnType("int")
                        .HasColumnName("id_prod");

                    b.Property<int>("IdProv")
                        .HasColumnType("int")
                        .HasColumnName("id_prov");

                    b.Property<string>("NomProd")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("nom_prod");

                    b.HasKey("IdDetallepp")
                        .HasName("PK_detallepp_id_detallepp");

                    b.HasIndex(new[] { "IdProd" }, "IX_detallepp_id_prod");

                    b.HasIndex(new[] { "IdProv" }, "IX_detallepp_id_prov");

                    b.ToTable("detallepp", "farmacia");
                });

            modelBuilder.Entity("TALLERPOON.Models.dbModels.Empleado", b =>
                {
                    b.Property<int>("IdEmpl")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Id_empl");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdEmpl"));

                    b.Property<string>("Correo")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("correo");

                    b.Property<string>("DirEmpl")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("dir_empl");

                    b.Property<string>("NomEmpl")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("nom_empl");

                    b.Property<string>("RfcEmpl")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("RFC_empl");

                    b.Property<string>("TelEmp")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("tel_emp");

                    b.Property<int>("TurnEmpl")
                        .HasColumnType("int")
                        .HasColumnName("turn_empl");

                    b.HasKey("IdEmpl")
                        .HasName("PK_empleado_Id_empl");

                    b.HasIndex(new[] { "TurnEmpl" }, "IX_empleado_turn_empl");

                    b.ToTable("empleado", "farmacia");
                });

            modelBuilder.Entity("TALLERPOON.Models.dbModels.Producto", b =>
                {
                    b.Property<int>("IdProd")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Id_prod");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdProd"));

                    b.Property<int>("CantProd")
                        .HasColumnType("int")
                        .HasColumnName("cant_prod");

                    b.Property<string>("Imagen")
                        .HasMaxLength(250)
                        .IsUnicode(false)
                        .HasColumnType("varchar(250)")
                        .HasColumnName("imagen");

                    b.Property<string>("NomProd")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("nom_prod");

                    b.Property<int>("PrecProd")
                        .HasColumnType("int")
                        .HasColumnName("prec_prod");

                    b.HasKey("IdProd")
                        .HasName("PK_productos_Id_prod");

                    b.ToTable("productos", "farmacia");
                });

            modelBuilder.Entity("TALLERPOON.Models.dbModels.Proveedor", b =>
                {
                    b.Property<int>("IdProv")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Id_prov");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdProv"));

                    b.Property<string>("CorrProv")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)")
                        .HasColumnName("corr_prov");

                    b.Property<string>("DirProv")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)")
                        .HasColumnName("dir_prov");

                    b.Property<string>("NomProv")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("nvarchar(60)")
                        .HasColumnName("nom_prov");

                    b.Property<string>("TelProv")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)")
                        .HasColumnName("tel_prov");

                    b.HasKey("IdProv")
                        .HasName("PK_proveedor_Id_prov");

                    b.ToTable("proveedor", "farmacia");
                });

            modelBuilder.Entity("TALLERPOON.Models.dbModels.Turno", b =>
                {
                    b.Property<int>("IdTurn")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id_turn");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdTurn"));

                    b.Property<string>("NombreTurn")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("nombre_turn");

                    b.HasKey("IdTurn");

                    b.ToTable("turno");
                });

            modelBuilder.Entity("TALLERPOON.Models.dbModels.Ventum", b =>
                {
                    b.Property<int>("IdVent")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Id_vent");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdVent"));

                    b.Property<DateTime>("FechVent")
                        .HasColumnType("date")
                        .HasColumnName("Fech_vent");

                    b.Property<int>("IdEmpl")
                        .HasColumnType("int")
                        .HasColumnName("Id_empl");

                    b.Property<decimal>("TotalVent")
                        .HasColumnType("decimal(19, 4)")
                        .HasColumnName("total_vent");

                    b.HasKey("IdVent")
                        .HasName("PK_venta_Id_vent");

                    b.HasIndex(new[] { "IdEmpl" }, "IX_venta_Id_empl");

                    b.ToTable("venta", "farmacia");
                });

            modelBuilder.Entity("TALLERPOON.Models.dbModels.Carrito", b =>
                {
                    b.HasOne("TALLERPOON.Models.dbModels.Empleado", "IdEmplNavigation")
                        .WithMany("Carritos")
                        .HasForeignKey("IdEmpl")
                        .IsRequired()
                        .HasConstraintName("FK_carrito_empleado");

                    b.HasOne("TALLERPOON.Models.dbModels.Producto", "IdProdNavigation")
                        .WithMany("Carritos")
                        .HasForeignKey("IdProd")
                        .IsRequired()
                        .HasConstraintName("FK_carrito_productos");

                    b.Navigation("IdEmplNavigation");

                    b.Navigation("IdProdNavigation");
                });

            modelBuilder.Entity("TALLERPOON.Models.dbModels.Detalleap", b =>
                {
                    b.HasOne("TALLERPOON.Models.dbModels.Almacen", "IdAlmNavigation")
                        .WithMany("Detalleaps")
                        .HasForeignKey("IdAlm")
                        .IsRequired()
                        .HasConstraintName("FK_detalleap_almacen");

                    b.HasOne("TALLERPOON.Models.dbModels.Producto", "IdDetalleapNavigation")
                        .WithOne("Detalleap")
                        .HasForeignKey("TALLERPOON.Models.dbModels.Detalleap", "IdDetalleap")
                        .IsRequired()
                        .HasConstraintName("FK_detalleap_productos");

                    b.Navigation("IdAlmNavigation");

                    b.Navigation("IdDetalleapNavigation");
                });

            modelBuilder.Entity("TALLERPOON.Models.dbModels.Detalleea", b =>
                {
                    b.HasOne("TALLERPOON.Models.dbModels.Almacen", "IdAlmNavigation")
                        .WithMany("Detalleeas")
                        .HasForeignKey("IdAlm")
                        .IsRequired()
                        .HasConstraintName("FK_detalleea_almacen");

                    b.HasOne("TALLERPOON.Models.dbModels.Empleado", "IdEmplNavigation")
                        .WithMany("Detalleeas")
                        .HasForeignKey("IdEmpl")
                        .IsRequired()
                        .HasConstraintName("FK_detalleea_empleado");

                    b.Navigation("IdAlmNavigation");

                    b.Navigation("IdEmplNavigation");
                });

            modelBuilder.Entity("TALLERPOON.Models.dbModels.Detalleev", b =>
                {
                    b.HasOne("TALLERPOON.Models.dbModels.Empleado", "IdEmplNavigation")
                        .WithMany("Detalleevs")
                        .HasForeignKey("IdEmpl")
                        .IsRequired()
                        .HasConstraintName("FK_detalleev_empleado");

                    b.HasOne("TALLERPOON.Models.dbModels.Proveedor", "IdProvNavigation")
                        .WithMany("Detalleevs")
                        .HasForeignKey("IdProv")
                        .IsRequired()
                        .HasConstraintName("FK_detalleev_proveedor");

                    b.Navigation("IdEmplNavigation");

                    b.Navigation("IdProvNavigation");
                });

            modelBuilder.Entity("TALLERPOON.Models.dbModels.Detallepp", b =>
                {
                    b.HasOne("TALLERPOON.Models.dbModels.Producto", "IdProdNavigation")
                        .WithMany("Detallepps")
                        .HasForeignKey("IdProd")
                        .IsRequired()
                        .HasConstraintName("FK_detallepp_productos");

                    b.HasOne("TALLERPOON.Models.dbModels.Proveedor", "IdProvNavigation")
                        .WithMany("Detallepps")
                        .HasForeignKey("IdProv")
                        .IsRequired()
                        .HasConstraintName("FK_detallepp_proveedor");

                    b.Navigation("IdProdNavigation");

                    b.Navigation("IdProvNavigation");
                });

            modelBuilder.Entity("TALLERPOON.Models.dbModels.Empleado", b =>
                {
                    b.HasOne("TALLERPOON.Models.dbModels.Turno", "TurnEmplNavigation")
                        .WithMany("Empleados")
                        .HasForeignKey("TurnEmpl")
                        .IsRequired()
                        .HasConstraintName("FK_empleado_turno");

                    b.Navigation("TurnEmplNavigation");
                });

            modelBuilder.Entity("TALLERPOON.Models.dbModels.Ventum", b =>
                {
                    b.HasOne("TALLERPOON.Models.dbModels.Empleado", "IdEmplNavigation")
                        .WithMany("Venta")
                        .HasForeignKey("IdEmpl")
                        .IsRequired()
                        .HasConstraintName("FK_venta_empleado");

                    b.Navigation("IdEmplNavigation");
                });

            modelBuilder.Entity("TALLERPOON.Models.dbModels.Almacen", b =>
                {
                    b.Navigation("Detalleaps");

                    b.Navigation("Detalleeas");
                });

            modelBuilder.Entity("TALLERPOON.Models.dbModels.Empleado", b =>
                {
                    b.Navigation("Carritos");

                    b.Navigation("Detalleeas");

                    b.Navigation("Detalleevs");

                    b.Navigation("Venta");
                });

            modelBuilder.Entity("TALLERPOON.Models.dbModels.Producto", b =>
                {
                    b.Navigation("Carritos");

                    b.Navigation("Detalleap");

                    b.Navigation("Detallepps");
                });

            modelBuilder.Entity("TALLERPOON.Models.dbModels.Proveedor", b =>
                {
                    b.Navigation("Detalleevs");

                    b.Navigation("Detallepps");
                });

            modelBuilder.Entity("TALLERPOON.Models.dbModels.Turno", b =>
                {
                    b.Navigation("Empleados");
                });
#pragma warning restore 612, 618
        }
    }
}
