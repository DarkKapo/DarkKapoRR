using DarkKapoRR.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DarkKapoRR.Semillas
{
    public class SemillaEstado : IEntityTypeConfiguration<Estado>
    {
        public void Configure(EntityTypeBuilder<Estado> builder)
        {
            builder.HasData(
                new Estado { Id = 1, Nombre = "Lunar", FechaCreacion = DateTime.Now },
                new Estado { Id = 2, Nombre = "Reino de Chile", FechaCreacion = DateTime.Now }
                );
        }
    }
}
