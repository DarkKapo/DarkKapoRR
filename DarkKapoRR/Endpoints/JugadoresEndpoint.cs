﻿using AutoMapper;
using DarkKapoRR.DTOs;
using DarkKapoRR.Entidades;
using DarkKapoRR.Repositorios;
using FluentValidation;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.OutputCaching;

namespace DarkKapoRR.Endpoints
{
    public static class JugadoresEndpoint
    {
        public static RouteGroupBuilder MapJugadores(this RouteGroupBuilder group)
        {
            group.MapGet("/", ObtenerJugadores).CacheOutput(c => c.Expire(TimeSpan.FromMinutes(30)).Tag("jugadores-get"));
            group.MapGet("/{id}", ObtenerJugadorPorId);
            group.MapPost("/", CrearJugador);
            group.MapPut("/{id}", ActualizarJugador);
            group.MapDelete("/{id}", EliminarJugador);
            group.MapPut("/{id}/personalizado", ActualizadoPersonalizado).WithOpenApi(opciones =>
            {
                opciones.Summary = "Actualiza uno o varios campos";
                opciones.Description = "Si no deseas actualizar un campo, solo debes eliminarlo";
                return opciones;
            });
            return group;
        }
        static async Task<Ok<List<JugadorDTO>>> ObtenerJugadores(IRepositorioJugador repositorio, IMapper mapper)
        {
            var jugadores = await repositorio.ObtenerTodos();
            var jugadoresDTO = mapper.Map<List<JugadorDTO>>(jugadores);
            return TypedResults.Ok(jugadoresDTO);
        }

        static async Task<Results<Ok<JugadorDTO>, NotFound>> ObtenerJugadorPorId(IRepositorioJugador repositorio, int id, IMapper mapper)
        {
            var jugador = await repositorio.ObtenerPorId(id);
            var jugadorDTO = mapper.Map<JugadorDTO>(jugador);
            if (jugador is not null) return TypedResults.Ok(jugadorDTO);
            return TypedResults.NotFound();
        }

        static async Task<Results<Created<JugadorDTO>, ValidationProblem>> CrearJugador(CrearJugadorDTO crearJugadorDTO, IRepositorioJugador repositorio, IOutputCacheStore outputCacheStore, IMapper mapper, IValidator<CrearJugadorDTO> validador)
        {
            var resultadoValidacion = await validador.ValidateAsync(crearJugadorDTO);
            if (!resultadoValidacion.IsValid) return TypedResults.ValidationProblem(resultadoValidacion.ToDictionary());
            crearJugadorDTO.FechaCreacion = DateTime.Now;
            var jugador = mapper.Map<Jugador>(crearJugadorDTO);//Uso de automapper
            var id = await repositorio.Crear(jugador);
            await outputCacheStore.EvictByTagAsync("jugadores-get", default);
            var jugadorDTO = mapper.Map<JugadorDTO>(jugador);
            return TypedResults.Created($"/jugador/{id}", jugadorDTO);
        }

        static async Task<Results<NoContent, NotFound, ValidationProblem>> ActualizarJugador(CrearJugadorDTO crearJugadorDTO, IRepositorioJugador repositorio, IOutputCacheStore outputCacheStore, int id, IMapper mapper, IValidator<CrearJugadorDTO> validador)
        {
            var resultadoValidacion = await validador.ValidateAsync(crearJugadorDTO);
            if (!resultadoValidacion.IsValid) return TypedResults.ValidationProblem(resultadoValidacion.ToDictionary());
            var existe = await repositorio.Existe(id);
            if (!existe) return TypedResults.NotFound();
            var fechaCreacionDB = (await repositorio.ObtenerPorId(id))?.FechaCreacion;
            crearJugadorDTO.FechaCreacion = fechaCreacionDB ?? DateTime.Now;
            var jugador = mapper.Map<Jugador>(crearJugadorDTO);
            jugador.Id = id;
            jugador.FechaActualizacion = DateTime.Now;
            jugador.Version++;
            await repositorio.Actualizar(jugador);
            await outputCacheStore.EvictByTagAsync("jugadores-get", default);
            return TypedResults.NoContent();
        }

        static async Task<Results<NoContent, NotFound, ValidationProblem>> ActualizadoPersonalizado(ActualizarJugadorDTO actualizarJugadorDTO, IRepositorioJugador repositorio, IOutputCacheStore outputCacheStore, int id, IValidator<ActualizarJugadorDTO> validador)
        {
            var resultadoValidacion = await validador.ValidateAsync(actualizarJugadorDTO);
            if (!resultadoValidacion.IsValid) return TypedResults.ValidationProblem(resultadoValidacion.ToDictionary());

            var jugador = await repositorio.ObtenerPorId(id);
            if (jugador == null) return TypedResults.NotFound();

            if(actualizarJugadorDTO.Nombre != null) jugador.Nombre = actualizarJugadorDTO.Nombre;
            if(actualizarJugadorDTO.EnlacePerfil != null) jugador.EnlacePerfil = actualizarJugadorDTO.EnlacePerfil;
            if(actualizarJugadorDTO.Fuerza != 0) jugador.Fuerza = actualizarJugadorDTO.Fuerza;
            if(actualizarJugadorDTO.Educacion != 0) jugador.Educacion = actualizarJugadorDTO.Educacion;
            if(actualizarJugadorDTO.Aguante != 0) jugador.Aguante = actualizarJugadorDTO.Aguante;
            if(actualizarJugadorDTO.RegionId != 0) jugador.RegionId = actualizarJugadorDTO.RegionId;
            actualizarJugadorDTO.FechaCreacion = jugador.FechaCreacion;
            jugador.FechaActualizacion = DateTime.Now;
            jugador.Version++;

            await repositorio.Actualizar(jugador);
            await outputCacheStore.EvictByTagAsync("jugadores-get", default);
            return TypedResults.NoContent();
        }

        static async Task<Results<NoContent, NotFound>> EliminarJugador(IRepositorioJugador repositorio, IOutputCacheStore outputCacheStore, int id)
        {
            var existe = await repositorio.Existe(id);
            if (!existe) return TypedResults.NotFound();

            await repositorio.Eliminar(id);
            await outputCacheStore.EvictByTagAsync("jugadores-get", default);
            return TypedResults.NoContent();
        }
    }
}
