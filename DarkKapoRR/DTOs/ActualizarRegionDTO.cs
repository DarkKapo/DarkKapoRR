using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace DarkKapoRR.DTOs
{
    public class ActualizarRegionDTO
    {
        public string? Nombre { get; set; } = null;
        public int? AcademiaMilitar { get; set; } //No tiene consumo de energía
        public int? Hospital { get; set; } = null;
        public int? BaseMilitar { get; set; } = null;
        public int? Escuela { get; set; } = null;
        public int? SistemaMisiles { get; set; } = null;
        public int? PuertoNaval { get; set; } = null; //Para regiones con acceso al mar
        public int? PlantaEnergia { get; set; } = null; //No tiene consumo de energía
        public int? PuertoEspacial { get; set; } = null;
        public int? Aeropuerto { get; set; } = null;
        public int? Viviendas { get; set; } = null;
        [JsonIgnore]
        public DateTime FechaCreacion { get; set; }
    }
}
