﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using _2Parcial_BonillaAp1.Server.DAL;

#nullable disable

namespace _2Parcial_BonillaAp1.Server.Migrations
{
    [DbContext(typeof(Contexto))]
    partial class ContextoModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.8");

            modelBuilder.Entity("_2Parcial_BonillaAp1.Shared.Models.Entradas", b =>
                {
                    b.Property<int>("EntradaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("CantidadProducida")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Concepto")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("Fecha")
                        .HasColumnType("TEXT");

                    b.Property<int>("PesoTotal")
                        .HasColumnType("INTEGER");

                    b.Property<int>("ProductoId")
                        .HasColumnType("INTEGER");

                    b.HasKey("EntradaId");

                    b.ToTable("Entradas");
                });

            modelBuilder.Entity("_2Parcial_BonillaAp1.Shared.Models.ProductosDetalle", b =>
                {
                    b.Property<int>("DetalleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("CantidadUtilizada")
                        .HasColumnType("INTEGER");

                    b.Property<int>("EntradaId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("ProductoId")
                        .HasColumnType("INTEGER");

                    b.HasKey("DetalleId");

                    b.HasIndex("EntradaId");

                    b.ToTable("ProductosDetalles");
                });

            modelBuilder.Entity("_2Parcial_BonillaAp1.Shared.Models.TipoProductos", b =>
                {
                    b.Property<int?>("TipoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Descripcion")
                        .HasColumnType("TEXT");

                    b.Property<int>("Existencia")
                        .HasColumnType("INTEGER");

                    b.Property<int>("ProductoId")
                        .HasColumnType("INTEGER");

                    b.HasKey("TipoId");

                    b.ToTable("TipoProductos");

                    b.HasData(
                        new
                        {
                            TipoId = 1,
                            Descripcion = "Mani",
                            Existencia = 0,
                            ProductoId = 0
                        },
                        new
                        {
                            TipoId = 3,
                            Descripcion = "Pasas",
                            Existencia = 0,
                            ProductoId = 0
                        },
                        new
                        {
                            TipoId = 4,
                            Descripcion = "Pistacho",
                            Existencia = 0,
                            ProductoId = 0
                        },
                        new
                        {
                            TipoId = 5,
                            Descripcion = "Ciruela",
                            Existencia = 0,
                            ProductoId = 0
                        },
                        new
                        {
                            TipoId = 6,
                            Descripcion = "Arandanos",
                            Existencia = 0,
                            ProductoId = 0
                        });
                });

            modelBuilder.Entity("_2Parcial_BonillaAp1.Shared.Models.ProductosDetalle", b =>
                {
                    b.HasOne("_2Parcial_BonillaAp1.Shared.Models.Entradas", null)
                        .WithMany("ClientesDetalle")
                        .HasForeignKey("EntradaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("_2Parcial_BonillaAp1.Shared.Models.Entradas", b =>
                {
                    b.Navigation("ClientesDetalle");
                });
#pragma warning restore 612, 618
        }
    }
}
