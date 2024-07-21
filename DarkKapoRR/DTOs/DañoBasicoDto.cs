using Microsoft.EntityFrameworkCore;

namespace DarkKapoRR.DTOs
{
    public class DañoBasicoDto
    {
        [Precision(12)]
        public decimal DañoMaximo { get; set; }
        [Precision(12)]
        public decimal DañoBase { get; set; }
        [Precision(12)]
        public decimal DañoMinimo { get; set; }
    }
}
