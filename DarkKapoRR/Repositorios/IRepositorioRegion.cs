using DarkKapoRR.Entidades;

namespace DarkKapoRR.Repositorios
{
    public interface IRepositorioRegion
    {
        Task<List<Region>> ObtenerTodos();
        Task<Region?> ObtenerPorId(int id);
        Task<int> Crear(Region region);
        Task<bool> Existe(int id);
        Task Actualizar(Region region);
        Task Eliminar(int id);
        Task<bool> Existe(int id, string? nombre);
    }
}