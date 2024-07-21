using DarkKapoRR.Entidades;
using System.ComponentModel.DataAnnotations.Schema;

namespace DarkKapoRR.DTOs
{
    public class ActualizarDañoJugadorDTO
    {
        public int? JugadorId { get; set; } = null;
        public int? BaseMilitar { get; set; } = null;
        public int? SistemaMisiles { get; set; } = null;
        public int? PuertoNaval { get; set; } = null;
        public int? Aeropuerto { get; set; } = null;
        public int? PuertoEspacial { get; set; } = null;
        public int? AcademiaMilitar { get; set; } = null;
        public int Fuerza { get; set; }
        public int Educacion { get; set; }
        public int Aguante { get; set; }
        public int? Nivel { get; set; } = null;
        public int? Tropas { get; set; } = null;
        public int? BonusNacion { get; set; } = null;
    }
}
