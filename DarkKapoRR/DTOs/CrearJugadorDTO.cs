using System.Text.Json.Serialization;

namespace DarkKapoRR.DTOs
{
    public class CrearJugadorDTO
    {
        public string Nombre { get; set; } = null!;
        public string? EnlacePerfil { get; set; } = string.Empty;
        public int Fuerza { get; set; } = 30;
        public int Educacion { get; set; } = 30;
        public int Aguante { get; set; } = 30;
        public int RegionId { get; set; }
        [JsonIgnore]
        public DateTime FechaCreacion { get; set; }
    }
}