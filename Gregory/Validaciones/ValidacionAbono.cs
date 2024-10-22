using Gregory.Models;
using FluentValidation;

namespace Gregory.Validaciones
{
    public class ValidacionAbono : AbstractValidator<Abono>
    {
        public ValidacionAbono()
        {
            RuleFor(Abono => Abono.IdReserva)
                .GreaterThan(0).WithMessage("Debe seleccionar una reserva");

            RuleFor(Abono => Abono.Subtotal)
                .NotEmpty().WithMessage("El subtotal es obligatorio.")
                .GreaterThanOrEqualTo(0).WithMessage("El subtotal no puede ser negativo.");

            RuleFor(Abono => Abono.Iva)
                .NotEmpty().WithMessage("El iva es obligatorio.")
                .GreaterThanOrEqualTo(0).WithMessage("El IVA no puede ser negativo.");

            RuleFor(Abono => Abono.Total)
                .NotEmpty().WithMessage("El total es obligatorio.")
                .GreaterThan(0).WithMessage("El total debe ser mayor que 0.");
                //.Equal(Abono => Abono.Subtotal + Abono.Iva).WithMessage("El total debe ser igual a la suma del subtotal más IVA.");

            RuleFor(x => x.Valordeuda)
                .NotEmpty().WithMessage("El valor deuda es obligatorio.")
                .GreaterThan(0).WithMessage("El valor de la deuda debe ser mayor que 0.");

            RuleFor(x => x.Porcentaje)
                .NotEmpty().WithMessage("El porcentaje es obligatorio.")
                .InclusiveBetween(0, 100).WithMessage("El porcentaje debe estar entre 0 y 100.");

            RuleFor(x => x.CantidadAbono)
                .GreaterThan(0).WithMessage("La cantidad de abono debe ser mayor que 0.")
                .When(x => x.CantidadAbono.HasValue);

        }
    }
}
