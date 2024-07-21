using AutoMapper;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.OutputCaching;
using DarkKapoRR.DTOs;
using DarkKapoRR.Entidades;
using DarkKapoRR.Repositorios;
using DarkKapoRR.Filtros;

namespace DarkKapoRR.Endpoints
{
    public static class DañoJugadorEndpoint
    {
        public static RouteGroupBuilder MapDañoJugador(this RouteGroupBuilder group)
        {
            group.MapGet("/", ObtenerDañoJugador).CacheOutput(c => c.Expire(TimeSpan.FromMinutes(30)).Tag("dañosjugadores-get"));
            group.MapGet("/{id}", ObtenerDañoJugadorPorId);
            group.MapPost("/", CrearDañoJugador).AddEndpointFilter<FiltroValidaciones<CrearDañoJugadorDTO>>();
            group.MapPut("/{id}", ActualizarDañoJugador).AddEndpointFilter<FiltroValidaciones<CrearDañoJugadorDTO>>();
            group.MapDelete("/{id}", EliminarDañoJugador);
            group.MapPut("/{id}/personalizado", ActualizadoPersonalizado).AddEndpointFilter<FiltroValidaciones<ActualizarDañoJugadorDTO>>().WithOpenApi(opciones =>
            {
                opciones.Summary = "Actualiza uno o varios campos";
                opciones.Description = "Si no deseas actualizar un campo, solo debes eliminarlo";
                return opciones;
            });
            group.MapGet("/{jugadorId}/ataquesbasico", DañosBasico).WithOpenApi(opciones =>
            {
                opciones.Summary = "Obtiene los daños basicos de un jugador";
                opciones.Description = "Obtiene los daños Mínimo, Base (sin bonus nación) y Máximo de un jugador";
                return opciones;
            });
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
        static async Task<Results<Created<DañoJugadorDTO>, ValidationProblem>> CrearDañoJugador(CrearDañoJugadorDTO crearDañoJugadorDTO, IRepositorioDañoJugador repositorio, IOutputCacheStore outputCacheStore, IMapper mapper, IRepositorioRegion repositorioRegion, IRepositorioJugador repositorioJugador)
        {            
            crearDañoJugadorDTO.FechaCreacion = DateTime.Now;
            var dañoJugador = mapper.Map<DañoJugador>(crearDañoJugadorDTO);

            if (crearDañoJugadorDTO.RegionId != null || crearDañoJugadorDTO.RegionId != 0)
            {
                var region = repositorioRegion.ObtenerPorId(crearDañoJugadorDTO.RegionId.GetValueOrDefault()).Result;
                if (region != null)
                { 
                    dañoJugador.AcademiaMilitar = region.AcademiaMilitar;
                    dañoJugador.BaseMilitar = region.BaseMilitar;
                    dañoJugador.SistemaMisiles = region.SistemaMisiles;
                    dañoJugador.PuertoNaval = region.PuertoNaval;
                    dañoJugador.PuertoEspacial = region.PuertoEspacial;
                    dañoJugador.Aeropuerto = region.Aeropuerto;
                }
            }

            if (crearDañoJugadorDTO.JugadorId != null || crearDañoJugadorDTO.JugadorId != 0)
            {
                var jugador = repositorioJugador.ObtenerPorId(crearDañoJugadorDTO.JugadorId.GetValueOrDefault()).Result;
                if(jugador != null)
                {
                    dañoJugador.Fuerza = jugador.Fuerza;
                    dañoJugador.Educacion = jugador.Educacion;
                    dañoJugador.Aguante = jugador.Aguante;
                    dañoJugador.Nivel = jugador.Nivel;
                    dañoJugador.Tropas = (50000+(jugador.Nivel * 2500));
                }
            }

            var id = await repositorio.Crear(dañoJugador);
            await outputCacheStore.EvictByTagAsync("dañosjugadores-get", default);
            var dañoJugadorDTO = mapper.Map<DañoJugadorDTO>(dañoJugador);
            return TypedResults.Created($"/ataquejugador/{id}", dañoJugadorDTO);
        }
        static async Task<Results<NoContent, NotFound, ValidationProblem>> ActualizarDañoJugador(CrearDañoJugadorDTO crearDañoJugadorDTO, IRepositorioDañoJugador repositorio, IOutputCacheStore outputCacheStore, int id, IMapper mapper)
        {
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
        static async Task<Results<NoContent, NotFound, ValidationProblem>> ActualizadoPersonalizado(ActualizarDañoJugadorDTO actualizarDañoJugadorDTO, IRepositorioDañoJugador repositorio, IOutputCacheStore outputCacheStore, int id)
        {
            var dañoJugador = await repositorio.ObtenerPorId(id);
            if (dañoJugador == null) return TypedResults.NotFound();

            if(actualizarDañoJugadorDTO.JugadorId != null) dañoJugador.JugadorId = actualizarDañoJugadorDTO.JugadorId.GetValueOrDefault();
            if(actualizarDañoJugadorDTO.BaseMilitar != null) dañoJugador.BaseMilitar = actualizarDañoJugadorDTO.BaseMilitar.GetValueOrDefault();
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
            dañoJugador.Version++;
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

        static async Task<Results<Ok<DañoBasicoDto>, NotFound>> DañosBasico(IRepositorioDañoJugador repositorio, IRepositorioJugador repositorioJugador, int jugadorId)
        {   //La logica es el el RepositorioDañoJugador
            var Jugador = await repositorioJugador.ObtenerPorId(jugadorId);
            if (Jugador is null) return TypedResults.NotFound();

            var dañoJugadorDTO = repositorio.DañosBasico(Jugador);
            
            return TypedResults.Ok(dañoJugadorDTO);
        }
    }
}
