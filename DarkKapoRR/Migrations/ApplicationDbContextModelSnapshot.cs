﻿// <auto-generated />
using System;
using DarkKapoRR;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DarkKapoRR.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("DarkKapoRR.Entidades.DañoJugador", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("AcademiaMilitar")
                        .HasColumnType("int");

                    b.Property<int>("Aeropuerto")
                        .HasColumnType("int");

                    b.Property<int>("Aguante")
                        .HasColumnType("int");

                    b.Property<int>("BaseMilitar")
                        .HasColumnType("int");

                    b.Property<int>("BonusNacion")
                        .HasColumnType("int");

                    b.Property<int>("Educacion")
                        .HasColumnType("int");

                    b.Property<DateTime?>("FechaActualizacion")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("FechaCreacion")
                        .HasColumnType("datetime2");

                    b.Property<int>("Fuerza")
                        .HasColumnType("int");

                    b.Property<int>("JugadorId")
                        .HasColumnType("int");

                    b.Property<int>("Nivel")
                        .HasColumnType("int");

                    b.Property<int>("PuertoEspacial")
                        .HasColumnType("int");

                    b.Property<int>("PuertoNaval")
                        .HasColumnType("int");

                    b.Property<int>("SistemaMisiles")
                        .HasColumnType("int");

                    b.Property<int>("Tropas")
                        .HasColumnType("int");

                    b.Property<int>("Version")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("JugadorId");

                    b.ToTable("DañosJugador");
                });

            modelBuilder.Entity("DarkKapoRR.Entidades.Estado", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime?>("FechaActualizacion")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("FechaCreacion")
                        .HasColumnType("datetime2");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("Version")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Estados");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            FechaCreacion = new DateTime(2024, 7, 20, 20, 27, 33, 995, DateTimeKind.Local).AddTicks(8754),
                            Nombre = "Lunar",
                            Version = 0
                        },
                        new
                        {
                            Id = 2,
                            FechaCreacion = new DateTime(2024, 7, 20, 20, 27, 33, 995, DateTimeKind.Local).AddTicks(8797),
                            Nombre = "Reino de Chile",
                            Version = 0
                        });
                });

            modelBuilder.Entity("DarkKapoRR.Entidades.Jugador", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Aguante")
                        .HasColumnType("int");

                    b.Property<int>("Educacion")
                        .HasColumnType("int");

                    b.Property<string>("EnlacePerfil")
                        .HasMaxLength(2083)
                        .HasColumnType("nvarchar(2083)");

                    b.Property<DateTime?>("FechaActualizacion")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("FechaCreacion")
                        .HasColumnType("datetime2");

                    b.Property<int>("Fuerza")
                        .HasColumnType("int");

                    b.Property<int>("Nivel")
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("RegionId")
                        .HasColumnType("int");

                    b.Property<int>("Version")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("RegionId");

                    b.ToTable("Jugadores");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Aguante = 999,
                            Educacion = 999,
                            FechaCreacion = new DateTime(2024, 7, 20, 20, 27, 33, 995, DateTimeKind.Local).AddTicks(9036),
                            Fuerza = 999,
                            Nivel = 107,
                            Nombre = "DarkKapo",
                            RegionId = 1,
                            Version = 0
                        },
                        new
                        {
                            Id = 2,
                            Aguante = 459,
                            Educacion = 459,
                            FechaCreacion = new DateTime(2024, 7, 20, 20, 27, 33, 995, DateTimeKind.Local).AddTicks(9040),
                            Fuerza = 648,
                            Nivel = 102,
                            Nombre = "Kapo",
                            RegionId = 2,
                            Version = 0
                        },
                        new
                        {
                            Id = 3,
                            Aguante = 193,
                            Educacion = 401,
                            FechaCreacion = new DateTime(2024, 7, 20, 20, 27, 33, 995, DateTimeKind.Local).AddTicks(9042),
                            Fuerza = 193,
                            Nivel = 89,
                            Nombre = "Osva",
                            RegionId = 4,
                            Version = 0
                        });
                });

            modelBuilder.Entity("DarkKapoRR.Entidades.Region", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("AcademiaMilitar")
                        .HasColumnType("int");

                    b.Property<int>("Aeropuerto")
                        .HasColumnType("int");

                    b.Property<int>("BaseMilitar")
                        .HasColumnType("int");

                    b.Property<int>("Escuela")
                        .HasColumnType("int");

                    b.Property<int>("EstadoId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("FechaActualizacion")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("FechaCreacion")
                        .HasColumnType("datetime2");

                    b.Property<int>("Hospital")
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("PlantaEnergia")
                        .HasColumnType("int");

                    b.Property<int>("PuertoEspacial")
                        .HasColumnType("int");

                    b.Property<int>("PuertoNaval")
                        .HasColumnType("int");

                    b.Property<int>("SistemaMisiles")
                        .HasColumnType("int");

                    b.Property<int>("Version")
                        .HasColumnType("int");

                    b.Property<int>("Viviendas")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("EstadoId");

                    b.ToTable("Regiones");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AcademiaMilitar = 136,
                            Aeropuerto = 4000,
                            BaseMilitar = 730,
                            Escuela = 1058,
                            EstadoId = 1,
                            FechaCreacion = new DateTime(2024, 7, 20, 20, 27, 33, 995, DateTimeKind.Local).AddTicks(8964),
                            Hospital = 1872,
                            Nombre = "MR 7",
                            PlantaEnergia = 1850,
                            PuertoEspacial = 1510,
                            PuertoNaval = 0,
                            SistemaMisiles = 0,
                            Version = 0,
                            Viviendas = 10200
                        },
                        new
                        {
                            Id = 2,
                            AcademiaMilitar = 194,
                            Aeropuerto = 8,
                            BaseMilitar = 534,
                            Escuela = 55,
                            EstadoId = 1,
                            FechaCreacion = new DateTime(2024, 7, 20, 20, 27, 33, 995, DateTimeKind.Local).AddTicks(8969),
                            Hospital = 1871,
                            Nombre = "MR 38",
                            PlantaEnergia = 600,
                            PuertoEspacial = 4,
                            PuertoNaval = 0,
                            SistemaMisiles = 0,
                            Version = 0,
                            Viviendas = 9520
                        },
                        new
                        {
                            Id = 3,
                            AcademiaMilitar = 198,
                            Aeropuerto = 425,
                            BaseMilitar = 1280,
                            Escuela = 970,
                            EstadoId = 1,
                            FechaCreacion = new DateTime(2024, 7, 20, 20, 27, 33, 995, DateTimeKind.Local).AddTicks(8972),
                            Hospital = 1872,
                            Nombre = "MR 68",
                            PlantaEnergia = 970,
                            PuertoEspacial = 305,
                            PuertoNaval = 0,
                            SistemaMisiles = 0,
                            Version = 0,
                            Viviendas = 10200
                        },
                        new
                        {
                            Id = 4,
                            AcademiaMilitar = 43,
                            Aeropuerto = 118,
                            BaseMilitar = 108,
                            Escuela = 275,
                            EstadoId = 2,
                            FechaCreacion = new DateTime(2024, 7, 20, 20, 27, 33, 995, DateTimeKind.Local).AddTicks(8974),
                            Hospital = 1283,
                            Nombre = "Magallanes",
                            PlantaEnergia = 440,
                            PuertoEspacial = 9,
                            PuertoNaval = 263,
                            SistemaMisiles = 300,
                            Version = 0,
                            Viviendas = 10315
                        });
                });

            modelBuilder.Entity("DarkKapoRR.Entidades.DañoJugador", b =>
                {
                    b.HasOne("DarkKapoRR.Entidades.Jugador", "Jugador")
                        .WithMany()
                        .HasForeignKey("JugadorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Jugador");
                });

            modelBuilder.Entity("DarkKapoRR.Entidades.Jugador", b =>
                {
                    b.HasOne("DarkKapoRR.Entidades.Region", "Region")
                        .WithMany()
                        .HasForeignKey("RegionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Region");
                });

            modelBuilder.Entity("DarkKapoRR.Entidades.Region", b =>
                {
                    b.HasOne("DarkKapoRR.Entidades.Estado", "Estado")
                        .WithMany()
                        .HasForeignKey("EstadoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Estado");
                });
#pragma warning restore 612, 618
        }
    }
}
