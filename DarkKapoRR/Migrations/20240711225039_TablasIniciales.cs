using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

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
                name: "Jugadores",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    EnlacePerfil = table.Column<string>(type: "nvarchar(2083)", maxLength: 2083, nullable: true),
                    Fuerza = table.Column<int>(type: "int", nullable: false),
                    Educacion = table.Column<int>(type: "int", nullable: false),
                    Aguante = table.Column<int>(type: "int", nullable: false),
                    EstadoId = table.Column<int>(type: "int", nullable: false),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaActualizacion = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Version = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Jugadores", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Jugadores_Estados_EstadoId",
                        column: x => x.EstadoId,
                        principalTable: "Estados",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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

            migrationBuilder.CreateIndex(
                name: "IX_Jugadores_EstadoId",
                table: "Jugadores",
                column: "EstadoId");

            migrationBuilder.CreateIndex(
                name: "IX_Regiones_EstadoId",
                table: "Regiones",
                column: "EstadoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Jugadores");

            migrationBuilder.DropTable(
                name: "Regiones");

            migrationBuilder.DropTable(
                name: "Estados");
        }
    }
}
