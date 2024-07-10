using DarkKapoRR.Entidades;
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

        }

        //public DbSet<State> States { get; set; }
        public DbSet<Region> Regiones { get; set; }
        public DbSet<Jugador> Jugadores { get; set; }
    }
}
