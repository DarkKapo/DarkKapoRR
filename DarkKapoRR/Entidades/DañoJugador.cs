using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DarkKapoRR.Entidades
{
    public class DañoJugador
    {
        public int Id { get; set; }
        public int JugadorId { get; set; }//Para calcular el daño actual del jugador
        [ForeignKey("JugadorId")]
        public Jugador Jugador { get; set; } = null!;
        //Para calcular el daño actual personalizado
        public int AcademiaMilitar { get; set; }
        public int BaseMilitar { get; set; }
        public int SistemaMisiles { get; set; }
        public int PuertoNaval { get; set; }
        public int PuertoEspacial { get; set; }
        public int Aeropuerto { get; set; }
        public int Fuerza { get; set; }
        public int Educacion { get; set; }
        public int Aguante { get; set; }
        public int Nivel { get; set; }
        public int Tropas { get; set; }
        public int BonusNacion { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime? FechaActualizacion { get; set; }
        public int Version { get; set; }        
    }
}
