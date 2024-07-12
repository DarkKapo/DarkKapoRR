using DarkKapoRR.DTOs;
using DarkKapoRR.Repositorios;
using FluentValidation;

namespace DarkKapoRR.Validaciones
{
    public class ActualizarEstadoDTOValidador : AbstractValidator<ActualizarEstadoDTO>
    {
        public ActualizarEstadoDTOValidador(IRepositorioEstado repositorio, IHttpContextAccessor httpContextAccessor)
        {
            var valorRutaId = httpContextAccessor.HttpContext?.Request.RouteValues["id"];
            var id = 0;

            if (valorRutaId is string valorString) int.TryParse(valorString, out id);

            RuleFor(n => n.Nombre).Must(NombreValido).WithMessage("{PropertyName} debe tener entre 3 a 50 caracteres")
                                  .MustAsync(async (nombre, _) =>
                                  {
                                      var existe = await repositorio.Existe(id, nombre);
                                      return !existe;
                                  }).WithMessage(g => $"Ya existe un Estado con nombre {g.Nombre}");
        }
        private bool NombreValido(string? nombre)
        {
            return (nombre == null || (nombre?.Length >= 3 && nombre?.Length <= 50));
        }
    }
}
