using DarkKapoRR.Entidades;
using System.ComponentModel.DataAnnotations;

namespace DarkKapoRR.DTOs
{
    public class RegionDTO
    {
        public int Id { get; set; }
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
        public int ConsumoEnergia { get; set; } // revisar que hace
        public int EstadoId { get; set; }
        public Estado Estado { get; set; } = null!;
        public DateTime FechaCreacion { get; set; }
    }
}
