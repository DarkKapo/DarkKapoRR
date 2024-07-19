using AutoMapper;
using DarkKapoRR.DTOs;
using DarkKapoRR.Entidades;
using DarkKapoRR.Repositorios;
using FluentValidation;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.OutputCaching;

namespace DarkKapoRR.Endpoints
{
    public static class DañoJugadorEndpoint
    {
        public static RouteGroupBuilder MapDañoJugador(this RouteGroupBuilder group)
        {
            group.MapGet("/", ObtenerDañoJugador).CacheOutput(c => c.Expire(TimeSpan.FromMinutes(30)).Tag("dañosjugadores-get"));
            group.MapGet("/{id}", ObtenerDañoJugadorPorId);
            group.MapPost("/", CrearDañoJugador);
            group.MapPut("/{id}", ActualizarDañoJugador);
            group.MapDelete("/{id}", EliminarDañoJugador);
            group.MapPut("/{id}/personalizado", ActualizadoPersonalizado);
            return group;
        }
        static async Task<Ok<List<DañoJugadorDTO>>> ObtenerDañoJugador(IRepositorioDañoJugador repositorio, IMapper mapper)
        {
            var dañoJugador = await repositorio.ObtenerTodos();
            var dañoJugadorDTO = mapper.Map<List<DañoJugadorDTO>>(dañoJugador);
            return TypedResults.Ok(dañoJugadorDTO);
        }
        static async Task<Results<Ok<DañoJugadorDTO>, NotFound>> ObtenerDañoJugadorPorId(IRepositorioDañoJugador repositorio, int id, IMapper mapper)
        {
            var dañoJugador = await repositorio.ObtenerPorId(id);
            var dañoJugadorDTO = mapper.Map<DañoJugadorDTO>(dañoJugador);
            if (dañoJugador is not null) return TypedResults.Ok(dañoJugadorDTO);
            return TypedResults.NotFound();
        }
        static async Task<Results<Created<DañoJugadorDTO>, ValidationProblem>> CrearDañoJugador(CrearDañoJugadorDTO crearDañoJugadorDTO, IRepositorioDañoJugador repositorio, IOutputCacheStore outputCacheStore, IMapper mapper, IValidator<CrearDañoJugadorDTO> validador)
        {
            var resultadoValidacion = await validador.ValidateAsync(crearDañoJugadorDTO);
            if (!resultadoValidacion.IsValid) return TypedResults.ValidationProblem(resultadoValidacion.ToDictionary());
            crearDañoJugadorDTO.FechaCreacion = DateTime.Now;
            var dañoJugador = mapper.Map<DañoJugador>(crearDañoJugadorDTO);
            var id = await repositorio.Crear(dañoJugador);
            await outputCacheStore.EvictByTagAsync("dañosjugadores-get", default);
            var dañoJugadorDTO = mapper.Map<DañoJugadorDTO>(dañoJugador);
            return TypedResults.Created($"/dañosjugador/{id}", dañoJugadorDTO);
        }
        static async Task<Results<NoContent, NotFound, ValidationProblem>> ActualizarDañoJugador(CrearDañoJugadorDTO crearDañoJugadorDTO, IRepositorioDañoJugador repositorio, IOutputCacheStore outputCacheStore, int id, IMapper mapper, IValidator<CrearDañoJugadorDTO> validador)
        {
            var resultadoValidacion = await validador.ValidateAsync(crearDañoJugadorDTO);
            if (!resultadoValidacion.IsValid) return TypedResults.ValidationProblem(resultadoValidacion.ToDictionary());

            var existe = await repositorio.Existe(id);
            if (!existe) return TypedResults.NotFound();

            var fechaCreacionDB = (await repositorio.ObtenerPorId(id))?.FechaCreacion;
            crearDañoJugadorDTO.FechaCreacion = fechaCreacionDB ?? DateTime.Now;
            var dañoJugador = mapper.Map<DañoJugador>(crearDañoJugadorDTO);

            dañoJugador.Id = id;
            dañoJugador.FechaActualizacion = DateTime.Now;
            await repositorio.Actualizar(dañoJugador);
            await outputCacheStore.EvictByTagAsync("dañosjugadores-get", default);
            return TypedResults.NoContent();
        }
        static async Task<Results<NoContent, NotFound, ValidationProblem>> ActualizadoPersonalizado(ActualizarDañoJugadorDTO actualizarDañoJugadorDTO, IRepositorioDañoJugador repositorio, IOutputCacheStore outputCacheStore, int id, IValidator<ActualizarDañoJugadorDTO> validador)
        {
            var resultadoValidacion = await validador.ValidateAsync(actualizarDañoJugadorDTO);
            if (!resultadoValidacion.IsValid) return TypedResults.ValidationProblem(resultadoValidacion.ToDictionary());

            var dañoJugador = await repositorio.ObtenerPorId(id);
            if (dañoJugador == null) return TypedResults.NotFound();

            if(actualizarDañoJugadorDTO.JugadorId != null) dañoJugador.JugadorId = actualizarDañoJugadorDTO.JugadorId.GetValueOrDefault();
            if(actualizarDañoJugadorDTO.IndiceMilitar != null) dañoJugador.IndiceMilitar = actualizarDañoJugadorDTO.IndiceMilitar.GetValueOrDefault();
            if(actualizarDañoJugadorDTO.SistemaMisiles != null) dañoJugador.SistemaMisiles = actualizarDañoJugadorDTO.SistemaMisiles.GetValueOrDefault();
            if(actualizarDañoJugadorDTO.PuertoNaval != null) dañoJugador.PuertoNaval = actualizarDañoJugadorDTO.PuertoNaval.GetValueOrDefault();
            if(actualizarDañoJugadorDTO.Aeropuerto != null) dañoJugador.Aeropuerto = actualizarDañoJugadorDTO.Aeropuerto.GetValueOrDefault();
            if(actualizarDañoJugadorDTO.PuertoEspacial != null) dañoJugador.PuertoEspacial = actualizarDañoJugadorDTO.PuertoEspacial.GetValueOrDefault();
            if(actualizarDañoJugadorDTO.AcademiaMilitar != null) dañoJugador.AcademiaMilitar = actualizarDañoJugadorDTO.AcademiaMilitar.GetValueOrDefault();
            if(actualizarDañoJugadorDTO.Fuerza != 0) dañoJugador.Fuerza = actualizarDañoJugadorDTO.Fuerza;
            if(actualizarDañoJugadorDTO.Educacion != 0) dañoJugador.Educacion = actualizarDañoJugadorDTO.Educacion;
            if(actualizarDañoJugadorDTO.Aguante != 0) dañoJugador.Aguante = actualizarDañoJugadorDTO.Aguante;
            if(actualizarDañoJugadorDTO.Nivel != null) dañoJugador.Nivel = actualizarDañoJugadorDTO.Nivel.GetValueOrDefault();
            if(actualizarDañoJugadorDTO.Tropas != null) dañoJugador.Tropas = actualizarDañoJugadorDTO.Tropas.GetValueOrDefault();
            if(actualizarDañoJugadorDTO.BonusNacion != null) dañoJugador.BonusNacion = actualizarDañoJugadorDTO.BonusNacion.GetValueOrDefault();
            
            dañoJugador.Id = id;
            dañoJugador.FechaActualizacion = DateTime.Now;
            await repositorio.Actualizar(dañoJugador);
            await outputCacheStore.EvictByTagAsync("dañosjugadores-get", default);
            return TypedResults.NoContent();
        }
        static async Task<Results<NoContent, NotFound, ValidationProblem>> EliminarDañoJugador(IRepositorioDañoJugador repositorio, IOutputCacheStore outputCacheStore, int id)
        {
            var existe = await repositorio.Existe(id);
            if (!existe) return TypedResults.NotFound();
            await repositorio.Eliminar(id);
            await outputCacheStore.EvictByTagAsync("dañosjugadores-get", default);
            return TypedResults.NoContent();
        }
    }
}
