using DarkKapoRR.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DarkKapoRR.Semillas
{
    public class SemillaJugador : IEntityTypeConfiguration<Jugador>
    {
        public void Configure(EntityTypeBuilder<Jugador> builder)
        {
            builder.HasData(
                new Jugador { Id = 1, Nombre = "DarkKapo", Nivel = 107, Fuerza = 999, Educacion = 999, Aguante = 999, RegionId = 1, FechaCreacion = DateTime.Now },
                new Jugador { Id = 2, Nombre = "Kapo", Nivel = 102, Fuerza = 648, Educacion = 459, Aguante = 459, RegionId = 2, FechaCreacion = DateTime.Now },
                new Jugador { Id = 3, Nombre = "Osva", Nivel = 89, Fuerza = 193, Educacion = 401, Aguante = 193, RegionId = 4, FechaCreacion = DateTime.Now }
                );
        }
    }
}
