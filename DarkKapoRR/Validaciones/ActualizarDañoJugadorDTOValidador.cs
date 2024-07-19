using DarkKapoRR.DTOs;
using FluentValidation;

namespace DarkKapoRR.Validaciones
{
    public class ActualizarDañoJugadorDTOValidador : AbstractValidator<ActualizarDañoJugadorDTO>
    {
        public ActualizarDañoJugadorDTOValidador()
        {
            RuleFor(j => j.JugadorId).Must(CantidadEdificiosValido).WithMessage("{PropertyName} debe ser mayor o igual a 0");
            RuleFor(i => i.IndiceMilitar).Must(CantidadEdificiosValido).WithMessage("{PropertyName} debe ser mayor o igual a 0");
            RuleFor(s => s.SistemaMisiles).Must(CantidadEdificiosValido).WithMessage("{PropertyName} debe ser mayor o igual a 0");
            RuleFor(p => p.PuertoNaval).Must(CantidadEdificiosValido).WithMessage("{PropertyName} debe ser mayor o igual a 0");
            RuleFor(a => a.Aeropuerto).Must(CantidadEdificiosValido).WithMessage("{PropertyName} debe ser mayor o igual a 0");
            RuleFor(p => p.PuertoEspacial).Must(CantidadEdificiosValido).WithMessage("{PropertyName} debe ser mayor o igual a 0");
            RuleFor(a => a.AcademiaMilitar).Must(CantidadEdificiosValido).WithMessage("{PropertyName} debe ser mayor o igual a 0");
            RuleFor(e => e.Fuerza).Must(EstadisticaValida).WithMessage("{PropertyName} debe estar entre 30 y 999");
            RuleFor(e => e.Educacion).Must(EstadisticaValida).WithMessage("{PropertyName} debe estar entre 30 y 999");
            RuleFor(a => a.Aguante).Must(EstadisticaValida).WithMessage("{PropertyName} debe estar entre 30 y 999");
            RuleFor(n => n.Nivel).Must(CantidadEdificiosValido).WithMessage("{PropertyName} debe ser mayor o igual a 0");
            RuleFor(t => t.Tropas).Must(CantidadEdificiosValido).WithMessage("{PropertyName} debe ser mayor o igual a 0");
            RuleFor(b => b.BonusNacion).InclusiveBetween(0, 1).WithMessage("{PropertyName} debe ser {From} ó {To}");
        }
        private bool CantidadEdificiosValido(int? cantidad)
        {
            return (cantidad == null || cantidad >= 0);
        }
        private bool EstadisticaValida(int estadistica)
        {
            return (estadistica == 0 || (estadistica >= 30 && estadistica <= 999));
        }
    }
}
