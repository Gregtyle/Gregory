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
                .GreaterThanOrEqualTo(0).WithMessage("El subtotal no puede ser negativo.");

            RuleFor(Abono => Abono.Iva)
                .GreaterThanOrEqualTo(0).WithMessage("El IVA no puede ser negativo.");

            RuleFor(Abono => Abono.Total)
                .GreaterThan(0).WithMessage("El total debe ser mayor que 0.")
                .Equal(Abono => Abono.Subtotal + Abono.Iva).WithMessage("El total debe ser igual a la suma del subtotal más IVA.");

            RuleFor(x => x.Valordeuda)
                .GreaterThan(0).WithMessage("El valor de la deuda debe ser mayor que 0.");

            RuleFor(x => x.Porcentaje)
                .InclusiveBetween(0, 100).WithMessage("El porcentaje debe estar entre 0 y 100.");

            RuleFor(x => x.CantidadAbono)
                .GreaterThan(0).WithMessage("La cantidad de abono debe ser mayor que 0.")
                .When(x => x.CantidadAbono.HasValue);

        }
    }
}
