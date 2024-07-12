using DarkKapoRR.DTOs;
using DarkKapoRR.Repositorios;
using FluentValidation;

namespace DarkKapoRR.Validaciones
{
    public class CrearEstadoDTOValidador : AbstractValidator<CrearEstadoDTO>
    {
        public CrearEstadoDTOValidador(IRepositorioEstado repositorio)
        {
            RuleFor(n => n.Nombre).NotEmpty().WithMessage("{PropertyName} es requerido").Length(3, 50).WithMessage("{PropertyName} tiene {TotalLength} letras. Debe tener una longitud entre {MinLength} y {MaxLength} letras.");
        }
    }
}
