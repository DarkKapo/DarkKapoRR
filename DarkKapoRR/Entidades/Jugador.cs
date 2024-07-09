using System.ComponentModel.DataAnnotations;

namespace DarkKapoRR.Entidades
{
    public class Jugador
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "El {0} es requerido")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "El Nombre debe tener entre {2} y {1} caracteres")]
        public string Nombre { get; set; } = null!;
        [StringLength(2083, ErrorMessage = "La URL del Perfil debe tener hasta {1} caracteres")]
        public string? EnlacePerfil { get; set; }
        [Range(30, 999, ErrorMessage = "La Fuerza debe estar entre {1} y {2}")]
        public int Fuerza { get; set; } = 30;
        [Range(30, 999, ErrorMessage = "La Educación estar entre {1} y {2}")]
        public int Educacion { get; set; } = 30;
        [Range(30, 999, ErrorMessage = "El Aguante debe estar entre {1} y {2}")]
        public int Aguante { get; set; } = 30;
    }
}
