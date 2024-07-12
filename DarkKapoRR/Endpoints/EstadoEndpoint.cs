using AutoMapper;
using DarkKapoRR.DTOs;
using DarkKapoRR.Entidades;
using DarkKapoRR.Repositorios;
using FluentValidation;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.OutputCaching;

namespace DarkKapoRR.Endpoints
{
    public static class EstadoEndpoint
    {
        public static RouteGroupBuilder MapEstados(this RouteGroupBuilder group)
        {
            group.MapGet("/", ObtenerEstados).CacheOutput(c => c.Expire(TimeSpan.FromMinutes(30)).Tag("estados-get"));
            group.MapGet("/{id}", ObtenerEstadoPorId);
            group.MapPost("/", CrearEstado);
            return group;
        }
        static async Task<Ok<List<EstadoDTO>>> ObtenerEstados(IRepositorioEstado repositorio, IMapper mapper)
        {
            var estados = await repositorio.ObtenerTodos();
            var estadosDTO = mapper.Map<List<EstadoDTO>>(estados);
            return TypedResults.Ok(estadosDTO);
        }
        static async Task<Results<Ok<EstadoDTO>, NotFound>> ObtenerEstadoPorId(IRepositorioEstado repositorio, int id, IMapper mapper)
        {
            var estado = await repositorio.ObtenerPorId(id);
            var estadoDTO = mapper.Map<EstadoDTO>(estado);
            if (estado is not null) return TypedResults.Ok(estadoDTO);
            return TypedResults.NotFound();
        }
        static async Task<Results<Created<EstadoDTO>, ValidationProblem>> CrearEstado(CrearEstadoDTO crearEstadoDTO, IRepositorioEstado repositorio, IOutputCacheStore outputCacheStore, IMapper mapper, IValidator<CrearEstadoDTO> validador)
        {
            var resultadoValidacion = await validador.ValidateAsync(crearEstadoDTO);
            if (!resultadoValidacion.IsValid) return TypedResults.ValidationProblem(resultadoValidacion.ToDictionary());
            crearEstadoDTO.FechaCreacion = DateTime.Now;
            var estado = mapper.Map<Estado>(crearEstadoDTO);
            var id = await repositorio.Crear(estado);
            await outputCacheStore.EvictByTagAsync("estados-get", default);
            var estadoDTO = mapper.Map<EstadoDTO>(estado);
            return TypedResults.Created($"/estado/{id}", estadoDTO);
        }
    }
}