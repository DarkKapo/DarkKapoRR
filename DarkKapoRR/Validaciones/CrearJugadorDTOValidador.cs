using DarkKapoRR.DTOs;
using FluentValidation;

namespace DarkKapoRR.Validaciones
{
    public class CrearJugadorDTOValidador : AbstractValidator<CrearJugadorDTO>
    {
        public CrearJugadorDTOValidador()
        {
            RuleFor(n => n.Nombre).NotEmpty().WithMessage("{PropertyName} es requerido").Length(3, 50).WithMessage("{PropertyName} tiene {TotalLength} letras. Debe tener una longitud entre {MinLength} y {MaxLength} letras.");
            RuleFor(e => e.EnlacePerfil).MaximumLength(2083).WithMessage("{PropertyName} tiene {TotalLength} letras. Debe tener una longitud maxima de {MaxLength} letras.");
            RuleFor(f => f.Fuerza).InclusiveBetween(30, 999).WithMessage("{PropertyName} debe estar entre {From} y {To}");
            RuleFor(e => e.Educacion).InclusiveBetween(30, 999).WithMessage("{PropertyName} debe estar entre {From} y {To}");
            RuleFor(a => a.Aguante).InclusiveBetween(30, 999).WithMessage("{PropertyName} debe estar entre {From} y {To}");
        }
    }
}
