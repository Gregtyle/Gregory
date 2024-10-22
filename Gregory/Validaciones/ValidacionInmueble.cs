using FluentValidation;
using Gregory.Models;

namespace Gregory.Validaciones
{
    public class ValidacionInmueble : AbstractValidator<Inmueble>
    {
        public ValidacionInmueble() 
        {
            RuleFor(x => x.Nombre)
            .NotEmpty().WithMessage("El nombre es obligatorio.")
            .Length(3, 100).WithMessage("El nombre debe tener entre 3 y 100 caracteres.");

            RuleFor(x => x.TipoInmueble)
                .NotEmpty().WithMessage("El tipo de inmueble es obligatorio.");

            RuleFor(x => x.NumerodeInmuebles)
                .NotEmpty().WithMessage("Cantidad es obligatoria")
                .GreaterThan(0).WithMessage("La cantidad de inmuebles debe ser mayor que 0.");

            RuleFor(x => x.Descripcion)
                .MaximumLength(200).WithMessage("La descripción no puede tener más de 200 caracteres.")
                .When(x => !string.IsNullOrEmpty(x.Descripcion)); 
        }
    }
}
