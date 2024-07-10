using AutoMapper;
using DarkKapoRR.DTOs;
using DarkKapoRR.Entidades;
using DarkKapoRR.Repositorios;
using FluentValidation;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.OutputCaching;

namespace DarkKapoRR.Endpoints
{
    public static class RegionEndpoint
    {
        public static RouteGroupBuilder MapRegiones(this RouteGroupBuilder group)
        {
            group.MapGet("/", ObtenerRegiones).CacheOutput(c => c.Expire(TimeSpan.FromMinutes(30)).Tag("jugadores-get"));
            group.MapGet("/{id}", ObtenerRegionPorId);
            group.MapPost("/", CrearRegion);
            //group.MapPut("/{id}", ActualizarRegion);
            //group.MapDelete("/{id}", EliminarRegion);
            //group.MapPut("/{id}/personalizado", ActualizadoPersonalizado);
            return group;
        }
        static async Task<Ok<List<RegionDTO>>> ObtenerRegiones(IRepositorioRegion repositorio, IMapper mapper)
        {
            var regiones = await repositorio.ObtenerTodos();
            var regionesDTO = mapper.Map<List<RegionDTO>>(regiones);
            return TypedResults.Ok(regionesDTO);
        }
        static async Task<Results<Ok<RegionDTO>, NotFound>> ObtenerRegionPorId(IRepositorioRegion repositorio, int id, IMapper mapper)
        {
            var region = await repositorio.ObtenerPorId(id);
            var regionDTO = mapper.Map<RegionDTO>(region);
            if (region is not null) return TypedResults.Ok(regionDTO);
            return TypedResults.NotFound();
        }
        static async Task<Results<Created<RegionDTO>, ValidationProblem>> CrearRegion(CrearRegionDTO crearRegionDTO, IRepositorioRegion repositorio, IOutputCacheStore outputCacheStore, IMapper mapper, IValidator<CrearRegionDTO> validador)
        {
            var resultadoValidacion = await validador.ValidateAsync(crearRegionDTO);
            if (!resultadoValidacion.IsValid) return TypedResults.ValidationProblem(resultadoValidacion.ToDictionary());
            crearRegionDTO.FechaCreacion = DateTime.Now;
            var region = mapper.Map<Region>(crearRegionDTO);
            var id = await repositorio.Crear(region);
            await outputCacheStore.EvictByTagAsync("regiones-get", default);
            var regionDTO = mapper.Map<RegionDTO>(region);
            return TypedResults.Created($"/region/{id}", regionDTO);
        }
    }
}
