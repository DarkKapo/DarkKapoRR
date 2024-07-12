using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace DarkKapoRR.DTOs
{
    public class CrearEstadoDTO
    {
        [StringLength(50)]
        public string Nombre { get; set; } = null!;
        [JsonIgnore]
        public DateTime FechaCreacion { get; set; }
    }
}
