using System.ComponentModel.DataAnnotations.Schema;

namespace DarkKapoRR.Entidades
{
    public class DañoJugador
    {
        public int Id { get; set; }
        public int JugadorId { get; set; }
        [ForeignKey("JugadorId")]
        public Jugador Jugador { get; set; } = null!;
    }
}
