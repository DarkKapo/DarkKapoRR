using System.ComponentModel.DataAnnotations;

namespace DarkKapoRR.Entidades
{
    public class Jugador
    {
        public int Id { get; set; }
        [StringLength(50)]
        public string Nombre { get; set; } = null!;
        [StringLength(2083)]
        public string? EnlacePerfil { get; set; }
        public int Fuerza { get; set; }
        public int Educacion { get; set; }
        public int Aguante { get; set; }
        public int EstadoId { get; set; }
        public Estado Estado { get; set; } = null!;
        public DateTime FechaCreacion { get; set; }
        public DateTime? FechaActualizacion { get; set; } = null;
        public int Version { get; set; }
    }
}
