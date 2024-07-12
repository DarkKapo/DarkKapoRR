using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace DarkKapoRR.DTOs
{
    public class CrearRegionDTO
    {
        public string Nombre { get; set; } = null!;
        public int AcademiaMilitar { get; set; } //No tiene consumo de energía
        public int Hospital { get; set; }
        public int BaseMilitar { get; set; }
        public int Escuela { get; set; }
        public int SistemaMisiles { get; set; }
        public int PuertoNaval { get; set; } //Para regiones con acceso al mar
        public int PlantaEnergia { get; set; } //No tiene consumo de energía
        public int PuertoEspacial { get; set; }
        public int Aeropuerto { get; set; }
        public int Viviendas { get; set; }
        public int EstadoId { get; set; }
        [JsonIgnore]
        public DateTime FechaCreacion { get; set; }
    }
}
