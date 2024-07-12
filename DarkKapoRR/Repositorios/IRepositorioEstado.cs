using DarkKapoRR.Entidades;

namespace DarkKapoRR.Repositorios
{
    public interface IRepositorioEstado
    {
        Task<List<Estado>> ObtenerTodos();
        Task<Estado?> ObtenerPorId(int id);
        Task<int> Crear(Estado player);
        Task<bool> Existe(int id);
        Task Actualizar(Estado player);
        Task Eliminar(int id);
        Task<bool> Existe(int id, string? nombre);
    }
}
