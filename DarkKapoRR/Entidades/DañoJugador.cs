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
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime FechaCreacion { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? FechaActualizacion { get; set; }
        public int Version { get; set; }
        //[Precision(12)]
        //public decimal TropasTotal => (decimal)(Jugador.Educacion + Jugador.Aguante + Jugador.Nivel);//Resolver, priemra opcion es que sea un metodo en vez de incluirlo en el modelo
        //[Precision(12)]
        //public decimal DañoMaximo => Math.Round(((1M + 0.5M + 0.75M + 0M + 0M + 2.5M + (decimal)Jugador.Fuerza/100 + 3M + (decimal)(Jugador.Educacion+Jugador.Aguante+Jugador.Nivel)/200m)* TropasTotal * 1.1m*1.125m), 2, MidpointRounding.AwayFromZero);
        //[Precision(12)]
        //public decimal DañoMinimo => Math.Round(((1M + 0.05M + (-0.75M) + 0M + 0M + 0 + (decimal)Jugador.Fuerza / 100 + 0 + (decimal)(Jugador.Educacion + Jugador.Aguante + Jugador.Nivel) / 200m) * TropasTotal * 1m * 0.875m), 2, MidpointRounding.AwayFromZero);
    }
}
