using DarkKapoRR.Entidades;

namespace DarkKapoRR.Repositorios
{
    public interface IRepositorioJugador
    {
        Task<List<Jugador>> ObtenerTodos();
        Task<Jugador?> ObtenerPorId(int id);
        Task<int> Crear(Jugador player);
        Task<bool> Existe(int id);
        Task Actualizar(Jugador player);
        Task Eliminar(int id);
        Task<bool> Existe(int id, string? nombre);
    }
}
