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
            group.MapPut("/{id}", ActualizarRegion);
            group.MapDelete("/{id}", EliminarRegion);
            group.MapPut("/{id}/personalizado", ActualizadoPersonalizado);
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
        static async Task<Results<NoContent, NotFound, ValidationProblem>> ActualizarRegion(CrearRegionDTO crearRegionDTO, IRepositorioRegion repositorio, IOutputCacheStore outputCacheStore, int id, IMapper mapper, IValidator<CrearRegionDTO> validador)
        {
            var resultadoValidacion = await validador.ValidateAsync(crearRegionDTO);
            if (!resultadoValidacion.IsValid) return TypedResults.ValidationProblem(resultadoValidacion.ToDictionary());

            var existe = await repositorio.Existe(id);
            if (!existe) return TypedResults.NotFound();

            var fechaCreacionDB = (await repositorio.ObtenerPorId(id))?.FechaCreacion;
            crearRegionDTO.FechaCreacion = fechaCreacionDB ?? DateTime.Now;
            var region = mapper.Map<Region>(crearRegionDTO);

            region.Id = id;
            region.FechaActualizacion = DateTime.Now;
            region.Version++;
            await repositorio.Actualizar(region);
            await outputCacheStore.EvictByTagAsync("regiones-get", default);
            return TypedResults.NoContent();
        }
        static async Task<Results<NoContent, NotFound, ValidationProblem>> ActualizadoPersonalizado(ActualizarRegionDTO actualizarRegionDTO, IRepositorioRegion repositorio, IOutputCacheStore outputCacheStore, int id, IValidator<ActualizarRegionDTO> validador)
        {
            var resultadoValidacion = await validador.ValidateAsync(actualizarRegionDTO);
            if (!resultadoValidacion.IsValid) return TypedResults.ValidationProblem(resultadoValidacion.ToDictionary());

            var region = await repositorio.ObtenerPorId(id);
            if (region == null) return TypedResults.NotFound();

            if(actualizarRegionDTO.Nombre != null) region.Nombre = actualizarRegionDTO.Nombre;
            if(actualizarRegionDTO.AcademiaMilitar != null) region.AcademiaMilitar = actualizarRegionDTO.AcademiaMilitar.GetValueOrDefault();
            if(actualizarRegionDTO.Hospital != null) region.Hospital = actualizarRegionDTO.Hospital.GetValueOrDefault();
            if(actualizarRegionDTO.BaseMilitar != null) region.BaseMilitar = actualizarRegionDTO.BaseMilitar.GetValueOrDefault();
            if(actualizarRegionDTO.Escuela != null) region.Escuela = actualizarRegionDTO.Escuela.GetValueOrDefault();
            if(actualizarRegionDTO.SistemaMisiles != null) region.SistemaMisiles = actualizarRegionDTO.SistemaMisiles.GetValueOrDefault();
            if(actualizarRegionDTO.PuertoNaval != null) region.PuertoNaval = actualizarRegionDTO.PuertoNaval.GetValueOrDefault();
            if(actualizarRegionDTO.PlantaEnergia != null) region.PlantaEnergia = actualizarRegionDTO.PlantaEnergia.GetValueOrDefault();
            if(actualizarRegionDTO.PuertoEspacial != null) region.PuertoEspacial = actualizarRegionDTO.PuertoEspacial.GetValueOrDefault();
            if(actualizarRegionDTO.Aeropuerto != null) region.Aeropuerto = actualizarRegionDTO.Aeropuerto.GetValueOrDefault();
            if(actualizarRegionDTO.Viviendas != null) region.Viviendas = actualizarRegionDTO.Viviendas.GetValueOrDefault();
            if(actualizarRegionDTO.EstadoId != null) region.EstadoId = actualizarRegionDTO.EstadoId.GetValueOrDefault();

            region.Id = id;
            actualizarRegionDTO.FechaCreacion = region.FechaCreacion;
            region.FechaActualizacion = DateTime.Now;
            region.Version++;

            await repositorio.Actualizar(region);
            await outputCacheStore.EvictByTagAsync("regiones-get", default);
            return TypedResults.NoContent();
        }
        static async Task<Results<NoContent, NotFound>> EliminarRegion(IRepositorioRegion repositorio, IOutputCacheStore outputCacheStore, int id)
        {
            var existe = await repositorio.Existe(id);
            if (!existe) return TypedResults.NotFound();

            await repositorio.Eliminar(id);
            await outputCacheStore.EvictByTagAsync("regiones-get", default);
            return TypedResults.NoContent();
        }
    }
}
