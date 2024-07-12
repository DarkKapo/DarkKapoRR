using DarkKapoRR.Entidades;
using Microsoft.EntityFrameworkCore;

namespace DarkKapoRR.Repositorios
{
    public class RepositorioEstado : IRepositorioEstado
    {
        private readonly ApplicationDbContext context;

        public RepositorioEstado(ApplicationDbContext context)
        {
            this.context = context;
        }

        public async Task<int> Crear(Estado estado)
        {
            context.Estados.Add(estado);
            await context.SaveChangesAsync();
            return estado.Id;
        }
        public async Task<Estado?> ObtenerPorId(int id)
        {
            return await context.Estados.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
        }
        public async Task<List<Estado>> ObtenerTodos()
        {
            return await context.Estados.OrderByDescending(i => i.Id).ToListAsync();
        }
        public async Task<bool> Existe(int id)
        {   //Esto es más eficiente que buscar por id
            return await context.Estados.AnyAsync(x => x.Id == id);
        }
        public async Task<bool> Existe(int id, string? nombre)
        {
            return await context.Estados.AnyAsync(g => g.Id != id && g.Nombre == nombre);
        }
        public async Task Actualizar(Estado estado)
        {
            context.Update(estado);
            await context.SaveChangesAsync();
        }
        public async Task Eliminar(int id)
        {
            await context.Estados.Where(x => x.Id == id).ExecuteDeleteAsync();
        }
    }
}
