using AutoMapper;
using DarkKapoRR.DTOs;
using DarkKapoRR.Entidades;
using DarkKapoRR.Filtros;
using DarkKapoRR.Repositorios;
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
            group.MapPost("/", CrearEstado).AddEndpointFilter<FiltroValidaciones<CrearEstadoDTO>>();
            group.MapPut("/{id}", ActualizarEstado).AddEndpointFilter<FiltroValidaciones<CrearEstadoDTO>>();
            group.MapPut("/{id}/personalizado", ActualizadoPersonalizado).AddEndpointFilter<FiltroValidaciones<ActualizarEstadoDTO>>().WithOpenApi(opciones =>
            {
                opciones.Summary = "Actualiza uno o varios campos";
                opciones.Description = "Si no deseas actualizar un campo, solo debes eliminarlo";
                return opciones;
            });
            group.MapDelete("/{id}", EliminarEstado);
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
        static async Task<Results<Created<EstadoDTO>, ValidationProblem>> CrearEstado(CrearEstadoDTO crearEstadoDTO, IRepositorioEstado repositorio, IOutputCacheStore outputCacheStore, IMapper mapper)
        {
            crearEstadoDTO.FechaCreacion = DateTime.Now;
            var estado = mapper.Map<Estado>(crearEstadoDTO);
            var id = await repositorio.Crear(estado);
            await outputCacheStore.EvictByTagAsync("estados-get", default);
            var estadoDTO = mapper.Map<EstadoDTO>(estado);
            return TypedResults.Created($"/estado/{id}", estadoDTO);
        }
        static async Task<Results<NoContent, NotFound, ValidationProblem>> ActualizarEstado(CrearEstadoDTO crearEstadoDTO, IRepositorioEstado repositorio, IOutputCacheStore outputCacheStore, int id, IMapper mapper)
        {
            var existe = await repositorio.Existe(id);
            if (!existe) return TypedResults.NotFound();

            var fechaCreacionDB = (await repositorio.ObtenerPorId(id))?.FechaCreacion;
            crearEstadoDTO.FechaCreacion = fechaCreacionDB ?? DateTime.Now;
            var estado = mapper.Map<Estado>(crearEstadoDTO);

            estado.Id = id;
            estado.FechaActualizacion = DateTime.Now;
            estado.Version++;
            await repositorio.Actualizar(estado);
            await outputCacheStore.EvictByTagAsync("estados-get", default);
            return TypedResults.NoContent();
        }
        static async Task<Results<NoContent, NotFound, ValidationProblem>> ActualizadoPersonalizado(ActualizarEstadoDTO actualizarEstadoDTO, IRepositorioEstado repositorio, IOutputCacheStore outputCacheStore, int id)
        {
            var estado = await repositorio.ObtenerPorId(id);
            if (estado == null) return TypedResults.NotFound();

            var fechaCreacionDB = (await repositorio.ObtenerPorId(id))?.FechaCreacion;
            if(actualizarEstadoDTO.Nombre != null) estado.Nombre = estado.Nombre;

            estado.Id = id;
            estado.FechaActualizacion = DateTime.Now;
            estado.Version++;
            await repositorio.Actualizar(estado);
            await outputCacheStore.EvictByTagAsync("estados-get", default);
            return TypedResults.NoContent();
        }

        static async Task<Results<NoContent, NotFound>> EliminarEstado(IRepositorioEstado repositorio, IOutputCacheStore outputCacheStore, int id)
        {
            var existe = await repositorio.Existe(id);
            if (!existe) return TypedResults.NotFound();
            await repositorio.Eliminar(id);
            await outputCacheStore.EvictByTagAsync("estados-get", default);
            return TypedResults.NoContent();
        }
    }
}