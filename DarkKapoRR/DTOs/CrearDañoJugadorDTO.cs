using System.Text.Json.Serialization;

namespace DarkKapoRR.DTOs
{
    public class CrearDañoJugadorDTO
    {
        public int? JugadorId { get; set; } = null!;
        public int? RegionId { get; set; } = null!;
        public int IndiceMilitar { get; set; }
        public int SistemaMisiles { get; set; }
        public int PuertoNaval { get; set; }
        public int Aeropuerto { get; set; }
        public int PuertoEspacial { get; set; }
        public int AcademiaMilitar { get; set; }
        public int Fuerza { get; set; }
        public int Educacion { get; set; }
        public int Aguante { get; set; }
        public int Nivel { get; set; }
        public int Tropas { get; set; }
        public int BonusNacion { get; set; }
        [JsonIgnore]
        public DateTime FechaCreacion { get; set; }
    }
}