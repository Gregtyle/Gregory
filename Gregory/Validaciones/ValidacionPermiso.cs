using FluentValidation;
using Gregory.Models;

namespace Gregory.Validaciones
{
    public class ValidacionPermiso : AbstractValidator<Permiso>
    {
        public ValidacionPermiso() 
        {
            RuleFor(x => x.NombrePermiso)
           .NotEmpty().WithMessage("El nombre del permiso es obligatorio.")
           .Length(3, 100).WithMessage("El nombre del permiso debe tener entre 3 y 100 caracteres.");

            RuleFor(x => x.Descripcion)
                .MaximumLength(200).WithMessage("La descripción no puede tener más de 200 caracteres.")
                .When(x => !string.IsNullOrEmpty(x.Descripcion)); 
        }
    }
}
