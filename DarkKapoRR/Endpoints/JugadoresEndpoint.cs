﻿using AutoMapper;
using DarkKapoRR.DTOs;
using DarkKapoRR.Entidades;
using DarkKapoRR.Repositorios;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.OutputCaching;

namespace DarkKapoRR.Endpoints
{
    public static class JugadoresEndpoint
    {
        public static RouteGroupBuilder MapJugadores(this RouteGroupBuilder group)
        {
            group.MapGet("/", ObtenerJugadores).CacheOutput(c => c.Expire(TimeSpan.FromSeconds(60)).Tag("jugadores-get"));
            group.MapGet("/{id}", ObtenerJugadorPorId);
            group.MapPost("/", CrearJugador);
            group.MapPut("/{id}", ActualizarJugador);
            group.MapDelete("/{id}", EliminarJugador);
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

        static async Task<Created<JugadorDTO>> CrearJugador(CrearJugadorDTO crearJugadorDTO, IRepositorioJugador repositorio, IOutputCacheStore outputCacheStore, IMapper mapper)
        {
            var jugador = mapper.Map<Jugador>(crearJugadorDTO);//Uso de automapper
            var id = await repositorio.Crear(jugador);
            await outputCacheStore.EvictByTagAsync("jugadores-get", default);
            var jugadorDTO = mapper.Map<JugadorDTO>(jugador);
            return TypedResults.Created($"/jugador/{id}", jugadorDTO);
        }

        static async Task<Results<NoContent, NotFound>> ActualizarJugador(CrearJugadorDTO crearJugadorDTO, IRepositorioJugador repositorio, IOutputCacheStore outputCacheStore, int id, IMapper mapper)
        {
            var existe = await repositorio.Existe(id);
            if (!existe) return TypedResults.NotFound();
            var jugador = mapper.Map<Jugador>(crearJugadorDTO);
            jugador.Id = id;
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