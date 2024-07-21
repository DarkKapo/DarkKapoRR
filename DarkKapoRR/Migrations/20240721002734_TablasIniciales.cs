using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DarkKapoRR.Migrations
{
    /// <inheritdoc />
    public partial class TablasIniciales : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Estados",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaActualizacion = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Version = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Estados", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Regiones",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    AcademiaMilitar = table.Column<int>(type: "int", nullable: false),
                    Hospital = table.Column<int>(type: "int", nullable: false),
                    BaseMilitar = table.Column<int>(type: "int", nullable: false),
                    Escuela = table.Column<int>(type: "int", nullable: false),
                    SistemaMisiles = table.Column<int>(type: "int", nullable: false),
                    PuertoNaval = table.Column<int>(type: "int", nullable: false),
                    PlantaEnergia = table.Column<int>(type: "int", nullable: false),
                    PuertoEspacial = table.Column<int>(type: "int", nullable: false),
                    Aeropuerto = table.Column<int>(type: "int", nullable: false),
                    Viviendas = table.Column<int>(type: "int", nullable: false),
                    EstadoId = table.Column<int>(type: "int", nullable: false),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaActualizacion = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Version = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Regiones", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Regiones_Estados_EstadoId",
                        column: x => x.EstadoId,
                        principalTable: "Estados",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Jugadores",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Nivel = table.Column<int>(type: "int", nullable: false),
                    EnlacePerfil = table.Column<string>(type: "nvarchar(2083)", maxLength: 2083, nullable: true),
                    Fuerza = table.Column<int>(type: "int", nullable: false),
                    Educacion = table.Column<int>(type: "int", nullable: false),
                    Aguante = table.Column<int>(type: "int", nullable: false),
                    RegionId = table.Column<int>(type: "int", nullable: false),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaActualizacion = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Version = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Jugadores", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Jugadores_Regiones_RegionId",
                        column: x => x.RegionId,
                        principalTable: "Regiones",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DañosJugador",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    JugadorId = table.Column<int>(type: "int", nullable: false),
                    AcademiaMilitar = table.Column<int>(type: "int", nullable: false),
                    BaseMilitar = table.Column<int>(type: "int", nullable: false),
                    SistemaMisiles = table.Column<int>(type: "int", nullable: false),
                    PuertoNaval = table.Column<int>(type: "int", nullable: false),
                    PuertoEspacial = table.Column<int>(type: "int", nullable: false),
                    Aeropuerto = table.Column<int>(type: "int", nullable: false),
                    Fuerza = table.Column<int>(type: "int", nullable: false),
                    Educacion = table.Column<int>(type: "int", nullable: false),
                    Aguante = table.Column<int>(type: "int", nullable: false),
                    Nivel = table.Column<int>(type: "int", nullable: false),
                    Tropas = table.Column<int>(type: "int", nullable: false),
                    BonusNacion = table.Column<int>(type: "int", nullable: false),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaActualizacion = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Version = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DañosJugador", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DañosJugador_Jugadores_JugadorId",
                        column: x => x.JugadorId,
                        principalTable: "Jugadores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Estados",
                columns: new[] { "Id", "FechaActualizacion", "FechaCreacion", "Nombre", "Version" },
                values: new object[,]
                {
                    { 1, null, new DateTime(2024, 7, 20, 20, 27, 33, 995, DateTimeKind.Local).AddTicks(8754), "Lunar", 0 },
                    { 2, null, new DateTime(2024, 7, 20, 20, 27, 33, 995, DateTimeKind.Local).AddTicks(8797), "Reino de Chile", 0 }
                });

            migrationBuilder.InsertData(
                table: "Regiones",
                columns: new[] { "Id", "AcademiaMilitar", "Aeropuerto", "BaseMilitar", "Escuela", "EstadoId", "FechaActualizacion", "FechaCreacion", "Hospital", "Nombre", "PlantaEnergia", "PuertoEspacial", "PuertoNaval", "SistemaMisiles", "Version", "Viviendas" },
                values: new object[,]
                {
                    { 1, 136, 4000, 730, 1058, 1, null, new DateTime(2024, 7, 20, 20, 27, 33, 995, DateTimeKind.Local).AddTicks(8964), 1872, "MR 7", 1850, 1510, 0, 0, 0, 10200 },
                    { 2, 194, 8, 534, 55, 1, null, new DateTime(2024, 7, 20, 20, 27, 33, 995, DateTimeKind.Local).AddTicks(8969), 1871, "MR 38", 600, 4, 0, 0, 0, 9520 },
                    { 3, 198, 425, 1280, 970, 1, null, new DateTime(2024, 7, 20, 20, 27, 33, 995, DateTimeKind.Local).AddTicks(8972), 1872, "MR 68", 970, 305, 0, 0, 0, 10200 },
                    { 4, 43, 118, 108, 275, 2, null, new DateTime(2024, 7, 20, 20, 27, 33, 995, DateTimeKind.Local).AddTicks(8974), 1283, "Magallanes", 440, 9, 263, 300, 0, 10315 }
                });

            migrationBuilder.InsertData(
                table: "Jugadores",
                columns: new[] { "Id", "Aguante", "Educacion", "EnlacePerfil", "FechaActualizacion", "FechaCreacion", "Fuerza", "Nivel", "Nombre", "RegionId", "Version" },
                values: new object[,]
                {
                    { 1, 999, 999, null, null, new DateTime(2024, 7, 20, 20, 27, 33, 995, DateTimeKind.Local).AddTicks(9036), 999, 107, "DarkKapo", 1, 0 },
                    { 2, 459, 459, null, null, new DateTime(2024, 7, 20, 20, 27, 33, 995, DateTimeKind.Local).AddTicks(9040), 648, 102, "Kapo", 2, 0 },
                    { 3, 193, 401, null, null, new DateTime(2024, 7, 20, 20, 27, 33, 995, DateTimeKind.Local).AddTicks(9042), 193, 89, "Osva", 4, 0 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_DañosJugador_JugadorId",
                table: "DañosJugador",
                column: "JugadorId");

            migrationBuilder.CreateIndex(
                name: "IX_Jugadores_RegionId",
                table: "Jugadores",
                column: "RegionId");

            migrationBuilder.CreateIndex(
                name: "IX_Regiones_EstadoId",
                table: "Regiones",
                column: "EstadoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DañosJugador");

            migrationBuilder.DropTable(
                name: "Jugadores");

            migrationBuilder.DropTable(
                name: "Regiones");

            migrationBuilder.DropTable(
                name: "Estados");
        }
    }
}
