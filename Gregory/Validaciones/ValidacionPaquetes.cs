using Gregory.Models;
using FluentValidation;

namespace Gregory.Validaciones
{
    public class ValidacionPaquetes : AbstractValidator<PaquetesHospedaje>
    {
        public ValidacionPaquetes()
        {

            RuleFor(PaquetesHospedaje => PaquetesHospedaje.Nombre)
                .NotEmpty().WithMessage("El nombre es obligatorio.")
                .Length(3, 50).WithMessage("El nombre debe tener entre 3 y 50 caracteres.");

            RuleFor(PaquetesHospedaje => PaquetesHospedaje.Descripcion)
                .MaximumLength(200).WithMessage("La descripción no puede tener más de 200 caracteres.")
                .When(PaquetesHospedajes => !string.IsNullOrEmpty(PaquetesHospedajes.Descripcion));

            RuleFor(PaquetesHospedaje => PaquetesHospedaje.PrecioTotal)
                .NotEmpty().WithMessage("el precio es obligatorio")
                .GreaterThan(0).WithMessage("El precio total debe ser mayor que 0.");

        }
    }
}
