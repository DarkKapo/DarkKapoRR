using DarkKapoRR.Entidades;
using Microsoft.EntityFrameworkCore;

namespace DarkKapoRR.Repositorios
{
    public class RepositorioRegion : IRepositorioRegion
    {
        private readonly ApplicationDbContext context;
        public RepositorioRegion(ApplicationDbContext context)
        {
            this.context = context;
        }

        public async Task<int> Crear(Region region)
        {
            context.Regions.Add(region);
            await context.SaveChangesAsync();
            return region.Id;
        }
        public async Task<Region?> ObtenerPorId(int id)
        {
            return await context.Regions.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
        }
        public async Task<List<Region>> ObtenerTodos()
        {
            return await context.Regions.OrderByDescending(i => i.Id).ToListAsync();
        }
        public async Task<bool> Existe(int id)
        {   //Esto es más eficiente que buscar por id
            return await context.Regions.AnyAsync(x => x.Id == id);
        }
        public async Task<bool> Existe(int id, string? nombre)
        {
            return await context.Regions.AnyAsync(g => g.Id != id && g.Nombre == nombre);
        }
        public async Task Actualizar(Region region)
        {
            context.Update(region);
            await context.SaveChangesAsync();
        }
        public async Task Eliminar(int id)
        {
            await context.Regions.Where(x => x.Id == id).ExecuteDeleteAsync();
        }
    }
}
