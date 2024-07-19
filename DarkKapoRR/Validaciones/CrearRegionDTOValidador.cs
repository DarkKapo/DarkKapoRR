using DarkKapoRR.DTOs;
using DarkKapoRR.Repositorios;
using FluentValidation;

namespace DarkKapoRR.Validaciones
{
    public class CrearRegionDTOValidador : AbstractValidator<CrearRegionDTO>
    {
        public CrearRegionDTOValidador(IRepositorioRegion repositorio) 
        {
            RuleFor(n => n.Nombre).NotEmpty().WithMessage("{PropertyName} es requerido").Length(3, 50).WithMessage("{PropertyName} tiene {TotalLength} letras. Debe tener una longitud entre {MinLength} y {MaxLength} letras.");
            RuleFor(m => m.AcademiaMilitar).GreaterThanOrEqualTo(0).WithMessage("{PropertyName} debe ser mayor o igual a {ComparisonValue}");
            RuleFor(h => h.Hospital).GreaterThanOrEqualTo(0).WithMessage("{PropertyName} debe ser mayor o igual a {ComparisonValue}");
            RuleFor(b => b.BaseMilitar).GreaterThanOrEqualTo(0).WithMessage("{PropertyName} debe ser mayor o igual a {ComparisonValue}");
            RuleFor(e => e.Escuela).GreaterThanOrEqualTo(0).WithMessage("{PropertyName} debe ser mayor o igual a {ComparisonValue}");
            RuleFor(s => s.SistemaMisiles).GreaterThanOrEqualTo(0).WithMessage("{PropertyName} debe ser mayor o igual a {ComparisonValue}");
            RuleFor(p => p.PuertoNaval).GreaterThanOrEqualTo(0).WithMessage("{PropertyName} debe ser mayor o igual a {ComparisonValue}");
            RuleFor(p => p.PlantaEnergia).GreaterThanOrEqualTo(0).WithMessage("{PropertyName} debe ser mayor o igual a {ComparisonValue}");
            RuleFor(p => p.PuertoEspacial).GreaterThanOrEqualTo(0).WithMessage("{PropertyName} debe ser mayor o igual a {ComparisonValue}");
            RuleFor(a => a.Aeropuerto).GreaterThanOrEqualTo(0).WithMessage("{PropertyName} debe ser mayor o igual a {ComparisonValue}");
            RuleFor(v => v.Viviendas).GreaterThanOrEqualTo(0).WithMessage("{PropertyName} debe ser mayor o igual a {ComparisonValue}");
            RuleFor(c => c.EstadoId).NotEmpty().WithMessage("{PropertyName} es requerido");
        }
    }
}