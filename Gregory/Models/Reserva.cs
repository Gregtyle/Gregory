using System;
using System.Collections.Generic;

namespace Gregory.Models;

public partial class Reserva
{
    public int IdReserva { get; set; }

    public DateTime FechaReserva { get; set; }

    public DateOnly FechaInicio { get; set; }

    public DateOnly FechaFin { get; set; }

    public decimal Subtotal { get; set; }

    public decimal Iva { get; set; }

    public decimal Total { get; set; }

    public decimal Descuento { get; set; }

    public int NoPersonas { get; set; }

    public int IdCliente { get; set; }

    public int IdUsuario { get; set; }

    public string Nit { get; set; } = null!;

    public bool Estado { get; set; }

    public int IdMetodoPago { get; set; }

    public virtual ICollection<Abono> Abonos { get; set; } = new List<Abono>();

    public virtual ICollection<DetalleHabitacione> DetalleHabitaciones { get; set; } = new List<DetalleHabitacione>();

    public virtual ICollection<DetallePaquete> DetallePaquetes { get; set; } = new List<DetallePaquete>();

    public virtual ICollection<DetalleServicio> DetalleServicios { get; set; } = new List<DetalleServicio>();

    public virtual Cliente IdClienteNavigation { get; set; } = null!;

    public virtual MetodoPago IdMetodoPagoNavigation { get; set; } = null!;

    public virtual Usuario IdUsuarioNavigation { get; set; } = null!;

    public virtual Empresa NitNavigation { get; set; } = null!;
}
