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
    }
}
