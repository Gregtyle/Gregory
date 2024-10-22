using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Gregory.Models;

public partial class Abono
{
    [Display(Name = "ID Abono")]
    public int IdAbono { get; set; }

    [Display(Name = "ID Reserva")]
    public int IdReserva { get; set; }

    [Display(Name = "Fecha de Abono")]
    public DateTime FechaAbono { get; set; }

    public decimal Valordeuda { get; set; }

    public decimal Porcentaje { get; set; }

    public decimal Subtotal { get; set; }

    public decimal Iva { get; set; }

    public decimal Total { get; set; }

    public int? CantidadAbono { get; set; }

    public bool Estado { get; set; }

    [Display(Name = "ID Reserva")]
    public virtual Reserva IdReservaNavigation { get; set; } = null!;
}
