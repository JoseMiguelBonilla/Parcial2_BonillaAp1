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

                    b.Property<decimal>("PesoTotal")
                        .HasColumnType("TEXT");

                    b.Property<int>("ProductoId")
                        .HasColumnType("INTEGER");

                    b.HasKey("EntradaId");

                    b.ToTable("Entradas");
                });

            modelBuilder.Entity("_2Parcial_BonillaAp1.Shared.Models.EntradasDetalle", b =>
                {
                    b.Property<int>("DetalleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("CantidadUtilizada")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Descripcion")
                        .HasColumnType("TEXT");

                    b.Property<int>("Disponibilidad")
                        .HasColumnType("INTEGER");

                    b.Property<int>("EntradaId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("FrutoId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Nombre")
                        .HasColumnType("TEXT");

                    b.Property<int>("ProductoId")
                        .HasColumnType("INTEGER");

                    b.HasKey("DetalleId");

                    b.HasIndex("EntradaId");

                    b.ToTable("EntradasDetalle");
                });

            modelBuilder.Entity("_2Parcial_BonillaAp1.Shared.Models.Presentacion", b =>
                {
                    b.Property<int>("PresentacionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Descripcion")
                        .HasColumnType("TEXT");

                    b.HasKey("PresentacionId");

                    b.ToTable("Presentaciones");

                    b.HasData(
                        new
                        {
                            PresentacionId = 1,
                            Descripcion = "Saco"
                        },
                        new
                        {
                            PresentacionId = 2,
                            Descripcion = "Caja"
                        });
                });

            modelBuilder.Entity("_2Parcial_BonillaAp1.Shared.Models.Productos", b =>
                {
                    b.Property<int>("ProductoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Descripcion")
                        .HasColumnType("TEXT");

                    b.Property<int>("Existencia")
                        .HasColumnType("INTEGER");

                    b.Property<decimal>("Peso")
                        .HasColumnType("TEXT");

                    b.Property<int>("PresentacionId")
                        .HasColumnType("INTEGER");

                    b.HasKey("ProductoId");

                    b.ToTable("Productos");

                    b.HasData(
                        new
                        {
                            ProductoId = 1,
                            Descripcion = "Mani",
                            Existencia = 100,
                            Peso = 100m,
                            PresentacionId = 1
                        },
                        new
                        {
                            ProductoId = 2,
                            Descripcion = "Pasas",
                            Existencia = 100,
                            Peso = 100m,
                            PresentacionId = 1
                        },
                        new
                        {
                            ProductoId = 3,
                            Descripcion = "Pistacho",
                            Existencia = 100,
                            Peso = 100m,
                            PresentacionId = 1
                        },
                        new
                        {
                            ProductoId = 4,
                            Descripcion = "Ciruela",
                            Existencia = 100,
                            Peso = 100m,
                            PresentacionId = 1
                        },
                        new
                        {
                            ProductoId = 5,
                            Descripcion = "Arandanos",
                            Existencia = 100,
                            Peso = 100m,
                            PresentacionId = 1
                        },
                        new
                        {
                            ProductoId = 6,
                            Descripcion = "Producto Mixto",
                            Existencia = 0,
                            Peso = 1m,
                            PresentacionId = 2
                        });
                });

            modelBuilder.Entity("_2Parcial_BonillaAp1.Shared.Models.EntradasDetalle", b =>
                {
                    b.HasOne("_2Parcial_BonillaAp1.Shared.Models.Entradas", null)
                        .WithMany("EntradasDetalles")
                        .HasForeignKey("EntradaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("_2Parcial_BonillaAp1.Shared.Models.Entradas", b =>
                {
                    b.Navigation("EntradasDetalles");
                });
#pragma warning restore 612, 618
        }
    }
}
