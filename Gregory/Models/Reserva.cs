using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Gregory.Models;

public partial class Reserva
{
    [Display(Name = "ID Reserva")]
    public int IdReserva { get; set; }

    [Display(Name = "Fecha de Reserva")]
    public DateTime FechaReserva { get; set; }

    [Display(Name = "Fecha de Inicio")]
    public DateOnly FechaInicio { get; set; }

    [Display(Name = "Fecha de Fin")]
    public DateOnly FechaFin { get; set; }

    public decimal Subtotal { get; set; }

    public decimal Iva { get; set; }

    public decimal Total { get; set; }

    public decimal Descuento { get; set; }

    public int NoPersonas { get; set; }

    [Display(Name = "ID Cliente")]
    public int IdCliente { get; set; }

    [Display(Name = "ID Usuario")]
    public int IdUsuario { get; set; }

    public string Nit { get; set; } = null!;

    public bool Estado { get; set; }

    [Display(Name = "ID Metodo Pago")]
    public int IdMetodoPago { get; set; }

    public virtual ICollection<Abono> Abonos { get; set; } = new List<Abono>();

    public virtual ICollection<DetalleHabitacione> DetalleHabitaciones { get; set; } = new List<DetalleHabitacione>();

    public virtual ICollection<DetallePaquete> DetallePaquetes { get; set; } = new List<DetallePaquete>();

    public virtual ICollection<DetalleServicio> DetalleServicios { get; set; } = new List<DetalleServicio>();

    [Display(Name = "ID Cliente")]
    public virtual Cliente IdClienteNavigation { get; set; } = null!;

    [Display(Name = "ID Metodo de Pago")]
    public virtual MetodoPago IdMetodoPagoNavigation { get; set; } = null!;

    [Display(Name = "ID Usuario")]
    public virtual Usuario IdUsuarioNavigation { get; set; } = null!;

    [Display(Name = "Nit")]
    public virtual Empresa NitNavigation { get; set; } = null!;
}
