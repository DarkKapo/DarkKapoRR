using System.ComponentModel.DataAnnotations;

namespace DarkKapoRR.DTOs
{
    public class ActualizarEstadoDTO
    {
        [StringLength(50)]
        public string Nombre { get; set; } = null!;
    }
}
