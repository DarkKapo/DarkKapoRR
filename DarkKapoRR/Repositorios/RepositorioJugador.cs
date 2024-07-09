using DarkKapoRR.Entidades;
using Microsoft.EntityFrameworkCore;

namespace DarkKapoRR.Repositorios
{
    public class RepositorioJugador : IRepositorioJugador
    {
        private readonly ApplicationDbContext context;

        public RepositorioJugador(ApplicationDbContext context)
        {
            this.context = context;
        }

        public async Task<int> Crear(Jugador player)
        {
            context.Players.Add(player);
            await context.SaveChangesAsync();
            return player.Id;
        }
        public async Task<Jugador?> ObtenerPorId(int id)
        {
            return await context.Players.FirstOrDefaultAsync(x => x.Id == id);
        }
        public async Task<List<Jugador>> ObtenerTodos()
        {
            return await context.Players.OrderByDescending(i => i.Id).ToListAsync();
        }
        public async Task<bool> Existe(int id)
        {   //Esto es más eficiente que buscar por id
            return await context.Players.AnyAsync(x => x.Id == id);
        }
        public async Task Actualizar(Jugador player)
        {
            context.Update(player);
            await context.SaveChangesAsync();
        }
        public async Task Eliminar(int id)
        {
            await context.Players.Where(x => x.Id == id).ExecuteDeleteAsync();
        }
    }
}
