using DarkKapoRR.Entidades;

namespace DarkKapoRR.DTOs
{
    public class EstadoDTO
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = null!;
        public DateTime FechaCreacion { get; set; }
    }
}
