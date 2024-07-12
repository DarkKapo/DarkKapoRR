﻿using System.ComponentModel.DataAnnotations;

namespace DarkKapoRR.Entidades
{
    public class Estado
    {
        public int Id { get; set; }
        [StringLength(50)]
        public string Nombre { get; set; } = null!;
        public DateTime FechaCreacion { get; set; }
        public DateTime? FechaActualizacion { get; set; }
        public int Version { get; set; }
    }
}