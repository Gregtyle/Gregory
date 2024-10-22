using FluentValidation;
using Gregory.Models;

namespace Gregory.Validaciones
{
    public class ValidacionEmpresa : AbstractValidator<Empresa>
    {
        public ValidacionEmpresa()
        {           
            RuleFor(x => x.Nit)
                .NotEmpty().WithMessage("El NIT es obligatorio.")
                .Length(9, 12).WithMessage("El NIT debe tener entre 9 y 12 caracteres.")
                .Matches(@"^\d+$").WithMessage("El NIT solo puede contener números."); 

            RuleFor(x => x.Nombre)
                .NotEmpty().WithMessage("El nombre es obligatorio.")
                .Length(3, 100).WithMessage("El nombre debe tener entre 3 y 100 caracteres.");

            RuleFor(x => x.Direccion)
                .NotEmpty().WithMessage("La dirección es obligatoria.")
                .MaximumLength(150).WithMessage("La dirección no puede tener más de 150 caracteres.");

            RuleFor(x => x.Telefono)
                .NotEmpty().WithMessage("El teléfono es obligatorio.")
                .Matches(@"^\d{7,10}$").WithMessage("El teléfono debe tener entre 7 y 10 dígitos.");

            RuleFor(x => x.RepresentanteLegal)
                .NotEmpty().WithMessage("El representante legal es obligatorio.")
                .Length(3, 100).WithMessage("El nombre del representante legal debe tener entre 3 y 100 caracteres.");
        }
    }
}
