using DarkKapoRR.DTOs;
using DarkKapoRR.Repositorios;
using FluentValidation;

namespace DarkKapoRR.Validaciones
{
    public class ActualizarJugadorDTOValidador : AbstractValidator<ActualizarJugadorDTO>
    {
        public ActualizarJugadorDTOValidador(IRepositorioJugador repositorio, IHttpContextAccessor httpContextAccessor)
        {
            var valorRutaId = httpContextAccessor.HttpContext?.Request.RouteValues["id"];
            var id = 0;

            if (valorRutaId is string valorString) int.TryParse(valorString, out id);

            RuleFor(r => r.RegionId).NotEmpty().WithMessage("{PropertyName} es requerido");
            RuleFor(n => n.Nombre).Must(NombreValido).WithMessage("{PropertyName} debe tener entre 3 a 50 caracteres")
                                  .MustAsync(async (nombre, _) =>
                                  {
                                      var existe = await repositorio.Existe(id, nombre);
                                      return !existe;
                                  }).WithMessage(g => $"Ya existe un jugador con nombre {g.Nombre}");
            RuleFor(e => e.Fuerza).Must(EstadisticaValida).WithMessage("{PropertyName} debe estar entre 30 y 999");
            RuleFor(e => e.Educacion).Must(EstadisticaValida).WithMessage("{PropertyName} debe estar entre 30 y 999");
            RuleFor(a => a.Aguante).Must(EstadisticaValida).WithMessage("{PropertyName} debe estar entre 30 y 999");
        }
        private bool NombreValido(string? nombre)
        {
            return (nombre == null || (nombre?.Length >= 3 && nombre?.Length <= 50));
        }
        private bool EstadisticaValida(int estadistica)
        {
            return (estadistica == 0 || (estadistica >= 30 && estadistica <= 999));
        }
    }
}
