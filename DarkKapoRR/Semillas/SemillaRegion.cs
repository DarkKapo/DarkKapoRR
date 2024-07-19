using DarkKapoRR.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DarkKapoRR.Semillas
{
    public class SemillaRegion : IEntityTypeConfiguration<Region>
    {
        public void Configure(EntityTypeBuilder<Region> builder)
        {
            builder.HasData(
                new Region { Id = 1, Nombre = "MR 7", AcademiaMilitar = 136, Hospital = 1872, BaseMilitar = 730, Escuela = 1058, SistemaMisiles = 0, PuertoNaval = 0, PlantaEnergia = 1850, PuertoEspacial = 1510, Aeropuerto = 4000, Viviendas = 10200, EstadoId = 1, FechaCreacion = DateTime.Now },
                new Region { Id = 2, Nombre = "MR 38", AcademiaMilitar = 194, Hospital = 1871, BaseMilitar = 534, Escuela = 55, SistemaMisiles = 0, PuertoNaval = 0, PlantaEnergia = 600, PuertoEspacial = 4, Aeropuerto = 8, Viviendas = 9520, EstadoId = 1, FechaCreacion = DateTime.Now },
                new Region { Id = 3, Nombre = "MR 68", AcademiaMilitar = 198, Hospital = 1872, BaseMilitar = 1280, Escuela = 970, SistemaMisiles = 0, PuertoNaval = 0, PlantaEnergia = 970, PuertoEspacial = 305, Aeropuerto = 425, Viviendas = 10200, EstadoId = 1, FechaCreacion = DateTime.Now },
                new Region { Id = 4, Nombre = "Magallanes", AcademiaMilitar = 43, Hospital = 1283, BaseMilitar = 108, Escuela = 275, SistemaMisiles = 300, PuertoNaval = 263, PlantaEnergia = 440, PuertoEspacial = 9, Aeropuerto = 118, Viviendas = 10315, EstadoId = 2, FechaCreacion = DateTime.Now }
                );
        }
    }
}
