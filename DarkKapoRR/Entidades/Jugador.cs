namespace DarkKapoRR.Entidades
{
    public class Jugador
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = null!;
        public string? EnlacePerfil { get; set; }
        public int Fuerza { get; set; }
        public int Educacion { get; set; }
        public int Aguante { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime? FechaActualizacion { get; set; } = null;
        public int Version { get; set; }
    }
}
