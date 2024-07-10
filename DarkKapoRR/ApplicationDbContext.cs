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
        public DbSet<Region> Regions { get; set; }
        public DbSet<Jugador> Players { get; set; }
    }
}
