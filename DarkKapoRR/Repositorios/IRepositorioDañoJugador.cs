using DarkKapoRR.Entidades;

namespace DarkKapoRR.Repositorios
{
    public interface IRepositorioDañoJugador
    {
        Task<List<DañoJugador>> ObtenerTodos();
        Task<DañoJugador?> ObtenerPorId(int id);
        Task<int> Crear(DañoJugador dañoJugador);
        Task<bool> Existe(int id);
        Task Actualizar(DañoJugador dañoJugador);
        Task Eliminar(int id);
    }
}
