using DarkKapoRR.Entidades;

namespace DarkKapoRR.DTOs
{
    public class JugadorDTO
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = null!;
        public string? EnlacePerfil { get; set; }
        public int Fuerza { get; set; }
        public int Educacion { get; set; }
        public int Aguante { get; set; }
        public int RegionId { get; set; }
        public Region Region { get; set; } = null!;
        public DateTime FechaCreacion { get; set; }
    }
}
