using System.Text.Json.Serialization;

namespace DarkKapoRR.DTOs
{
    public class ActualizarJugadorDTO
    {
        public string? Nombre { get; set; } = null;
        public string? EnlacePerfil { get; set; } = null;
        public int Fuerza { get; set; }
        public int Educacion { get; set; }
        public int Aguante { get; set; }
        [JsonIgnore]
        public DateTime FechaCreacion { get; set; }
    }
}
