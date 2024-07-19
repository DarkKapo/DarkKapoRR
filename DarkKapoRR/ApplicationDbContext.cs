using DarkKapoRR.Entidades;
using DarkKapoRR.Semillas;
using Microsoft.EntityFrameworkCore;

namespace DarkKapoRR
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new SemillaEstado());
            modelBuilder.ApplyConfiguration(new SemillaRegion());
            modelBuilder.ApplyConfiguration(new SemillaJugador());
        }

        public DbSet<Estado> Estados { get; set; }
        public DbSet<Region> Regiones { get; set; }
        public DbSet<Jugador> Jugadores { get; set; }
        public DbSet<DañoJugador> DañosJugador { get; set; }
    }
}
