namespace DarkKapoRR.DTOs
{
    public class CrearJugadorDTO
    {
        public string Nombre { get; set; } = null!;
        public string? EnlacePerfil { get; set; }
        public int Fuerza { get; set; }
        public int Educacion { get; set; }
        public int Aguante { get; set; }
    }
}
