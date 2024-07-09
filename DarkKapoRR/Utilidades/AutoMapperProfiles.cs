using AutoMapper;
using DarkKapoRR.DTOs;
using DarkKapoRR.Entidades;

namespace DarkKapoRR.Utilidades
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<CrearJugadorDTO, Jugador>();
            CreateMap<Jugador, JugadorDTO>();
        }
    }
}
