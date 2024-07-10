using DarkKapoRR.DTOs;
using DarkKapoRR.Repositorios;
using FluentValidation;

namespace DarkKapoRR.Validaciones
{
    public class ActualizarRegionDTOValidador : AbstractValidator<ActualizarRegionDTO>
    {
        public ActualizarRegionDTOValidador(IRepositorioRegion repositorio, IHttpContextAccessor httpContextAccessor)
        {
            var valorRutaId = httpContextAccessor.HttpContext?.Request.RouteValues["id"];
            var id = 0;

            if (valorRutaId is string valorString) int.TryParse(valorString, out id);

            RuleFor(n => n.Nombre).Must(NombreValido).WithMessage("{PropertyName} debe tener entre 3 a 50 caracteres")
                                  .MustAsync(async (nombre, _) =>
                                  {
                                      var existe = await repositorio.Existe(id, nombre);
                                      return !existe;
                                  }).WithMessage(g => $"Ya existe una región con nombre {g.Nombre}");
            RuleFor(a => a.AcademiaMilitar).Must(CantidadEdificiosValido).WithMessage("{PropertyName} debe ser mayor o igual a 0");
            RuleFor(h => h.Hospital).Must(CantidadEdificiosValido).WithMessage("{PropertyName} debe ser mayor o igual a 0");
            RuleFor(b => b.BaseMilitar).Must(CantidadEdificiosValido).WithMessage("{PropertyName} debe ser mayor o igual a 0");
            RuleFor(e => e.Escuela).Must(CantidadEdificiosValido).WithMessage("{PropertyName} debe ser mayor o igual a 0");
            RuleFor(s => s.SistemaMisiles).Must(CantidadEdificiosValido).WithMessage("{PropertyName} debe ser mayor o igual a 0");
            RuleFor(p => p.PuertoNaval).Must(CantidadEdificiosValido).WithMessage("{PropertyName} debe ser mayor o igual a 0");
            RuleFor(p => p.PlantaEnergia).Must(CantidadEdificiosValido).WithMessage("{PropertyName} debe ser mayor o igual a 0");
            RuleFor(p => p.PuertoEspacial).Must(CantidadEdificiosValido).WithMessage("{PropertyName} debe ser mayor o igual a 0");
            RuleFor(a => a.Aeropuerto).Must(CantidadEdificiosValido).WithMessage("{PropertyName} debe ser mayor o igual a 0");
        }
        private bool NombreValido(string? nombre)
        {
            return (nombre == null || (nombre?.Length >= 3 && nombre?.Length <= 50));
        }

        private bool CantidadEdificiosValido(int? cantidad)
        {
            return (cantidad == null || cantidad >= 0);
        }
    }
}
