using System.ComponentModel.DataAnnotations;

namespace DarkKapoRR.Entidades
{
    public class Region
    {
        public int Id { get; set; }
        [StringLength(50)]
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
        public int ConsumoEnergia => Hospital + BaseMilitar + Escuela + SistemaMisiles + PuertoNaval + PuertoEspacial + Aeropuerto + Viviendas; // revisar que hace
        public int EstadoId { get; set; }
        public Estado Estado { get; set; } = null!;
        public DateTime FechaCreacion { get; set; }
        public DateTime? FechaActualizacion { get; set; }
        public int Version { get; set; }
    }
}
