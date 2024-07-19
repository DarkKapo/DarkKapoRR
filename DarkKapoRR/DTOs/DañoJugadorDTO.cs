using DarkKapoRR.Entidades;
using Microsoft.EntityFrameworkCore;

namespace DarkKapoRR.DTOs
{
    public class DañoJugadorDTO
    {
        public int Id { get; set; }
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
        public DateTime FechaCreacion { get; set; }
        //[Precision(12)]
        //public decimal TropasTotal { get; set; }
        //[Precision(12)]
        //public decimal DañoMaximo { get; set; }
        //[Precision(12)]
        //public decimal DañoMinimo { get; set; }
    }
}