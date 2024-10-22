using FluentValidation;
using Gregory.Models;

namespace Gregory.Validaciones
{
    public class ValidacionHabitaciones : AbstractValidator<Habitacione>
    {
        public ValidacionHabitaciones()
        {
            RuleFor(x => x.Nombre)
                .NotEmpty().WithMessage("El nombre es obligatorio.")
                .Length(3, 50).WithMessage("El nombre debe tener entre 3 y 50 caracteres.");

            RuleFor(x => x.IdTipoHabitacion)
                .GreaterThan(0).WithMessage("Debe seleccionar un tipo de habitación.");

            RuleFor(x => x.IdInmueble)
                .GreaterThan(0).WithMessage("Debe seleccionar un inmueble.");

            RuleFor(x => x.Descripcion)
                .MaximumLength(200).WithMessage("La descripción no puede tener más de 200 caracteres.")
                .When(x => !string.IsNullOrEmpty(x.Descripcion)); 
        }
    }
}
