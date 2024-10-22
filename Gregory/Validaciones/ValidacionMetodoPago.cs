using FluentValidation;
using Gregory.Models;

namespace Gregory.Validaciones
{
    public class ValidacionMetodoPago : AbstractValidator<MetodoPago>
    {
        public ValidacionMetodoPago() 
        {
            RuleFor(x => x.Nombre)
            .NotEmpty().WithMessage("El nombre es obligatorio.")
            .Length(3, 100).WithMessage("El nombre debe tener entre 3 y 100 caracteres.");
        }
    }
}
