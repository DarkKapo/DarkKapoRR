using DarkKapoRR.DTOs;
using FluentValidation;

namespace DarkKapoRR.Validaciones
{
    public class CrearDañoJugadorDTOValidador : AbstractValidator<CrearDañoJugadorDTO>
    {
        public CrearDañoJugadorDTOValidador()
        {
            RuleFor(j => j.JugadorId).NotEmpty().WithMessage("{PropertyName} es requerido");
            RuleFor(n => n.IndiceMilitar).GreaterThanOrEqualTo(0).WithMessage("{PropertyName} debe ser mayor o igual a {ComparisonValue}");
            RuleFor(n => n.SistemaMisiles).GreaterThanOrEqualTo(0).WithMessage("{PropertyName} debe ser mayor o igual a {ComparisonValue}");
            RuleFor(n => n.PuertoNaval).GreaterThanOrEqualTo(0).WithMessage("{PropertyName} debe ser mayor o igual a {ComparisonValue}");
            RuleFor(n => n.Aeropuerto).GreaterThanOrEqualTo(0).WithMessage("{PropertyName} debe ser mayor o igual a {ComparisonValue}");
            RuleFor(n => n.PuertoEspacial).GreaterThanOrEqualTo(0).WithMessage("{PropertyName} debe ser mayor o igual a {ComparisonValue}");
            RuleFor(n => n.AcademiaMilitar).GreaterThanOrEqualTo(0).WithMessage("{PropertyName} debe ser mayor o igual a {ComparisonValue}");
            RuleFor(n => n.Fuerza).InclusiveBetween(30,999).WithMessage("{PropertyName} debe ser entre {From} y {To}");
            RuleFor(n => n.Educacion).InclusiveBetween(30, 999).WithMessage("{PropertyName} debe ser entre {From} y {To}");
            RuleFor(n => n.Aguante).InclusiveBetween(30, 999).WithMessage("{PropertyName} debe ser entre {From} y {To}");
            RuleFor(n => n.Nivel).GreaterThanOrEqualTo(0).WithMessage("{PropertyName} debe ser mayor o igual a {ComparisonValue}");
            RuleFor(n => n.Tropas).GreaterThanOrEqualTo(0).WithMessage("{PropertyName} debe ser mayor o igual a {ComparisonValue}");
            RuleFor(n => n.BonusNacion).InclusiveBetween(0, 1).WithMessage("{PropertyName} debe ser entre {From} y {To}");
        }
    }
}
