using DarkKapoRR.DTOs;
using DarkKapoRR.Entidades;
using Microsoft.EntityFrameworkCore;

namespace DarkKapoRR.Repositorios
{
    public class RepositorioDañoJugador : IRepositorioDañoJugador
    {
        private readonly ApplicationDbContext context;
        public RepositorioDañoJugador(ApplicationDbContext context)
        {
            this.context = context;
        }

        public async Task<int> Crear(DañoJugador dañoJugador)
        {
            context.DañosJugador.Add(dañoJugador);
            await context.SaveChangesAsync();
            return dañoJugador.Id;
        }
        public async Task<DañoJugador?> ObtenerPorId(int id)
        {
            return await context.DañosJugador.Include(j => j.Jugador).ThenInclude(r => r.Region).AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
        }
        public async Task<List<DañoJugador>> ObtenerTodos()
        {
            return await context.DañosJugador.OrderByDescending(i => i.Id).Include(j => j.Jugador).ThenInclude(r => r.Region).ToListAsync();
        }
        public async Task<bool> Existe(int id)
        {   //Esto es más eficiente que buscar por id
            return await context.DañosJugador.AnyAsync(x => x.Id == id);
        }
        public async Task Actualizar(DañoJugador dañoJugador)
        {
            context.Update(dañoJugador);
            await context.SaveChangesAsync();
        }
        public async Task Eliminar(int id)
        {
            await context.DañosJugador.Where(x => x.Id == id).ExecuteDeleteAsync();
        }

        public DañoBasicoDto DañosBasico(Jugador jugador)
        {
            DañoBasicoDto dañoJugadorDTO = new()
            {
                DañoMaximo = Math.Round(((1M + 0.5M + 0.75M + 0M + 0M + 2.5M + (decimal)jugador.Fuerza / 100 + 3M + (decimal)(jugador.Educacion + jugador.Aguante + jugador.Nivel) / 200m) * (decimal)(50000m + (jugador.Nivel * 2500)) * 1.1m * 1.125m), 2, MidpointRounding.AwayFromZero),
                DañoBase = Math.Round(((1M + 0.05M + 0M + 0M + 0M + 0M + (decimal)jugador.Fuerza / 100 + 0M + (decimal)(jugador.Educacion + jugador.Aguante + jugador.Nivel) / 200m) * (decimal)(50000m + (jugador.Nivel * 2500)) * 1m * 1m), 2, MidpointRounding.AwayFromZero),
                DañoMinimo = Math.Round(((1M + 0.05M + (-0.75M) + 0M + 0M + 0 + (decimal)jugador.Fuerza / 100 + 0 + (decimal)(jugador.Educacion + jugador.Aguante + jugador.Nivel) / 200m) * (decimal)(50000m + (jugador.Nivel * 2500)) * 1m * 0.875m), 2, MidpointRounding.AwayFromZero)
            };
            return dañoJugadorDTO;
        }
    }
}
