using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Gregory.Models;

public partial class Cliente
{
    [Display(Name = "ID Cliente")]
    public int IdCliente { get; set; }

    [Display(Name = "Tipo de Documento")]
    public string TipoDocumento { get; set; } = null!;

    public string Documento { get; set; } = null!;

    public string Nombre { get; set; } = null!;

    public string Apellido { get; set; } = null!;

    public string? Direccion { get; set; }

    public string? Celular { get; set; }

    [Display(Name = "Correo Electronico")]
    public string CorreoElectronico { get; set; } = null!;

    public bool Estado { get; set; }

    [Display(Name = "ID Rol")]
    public int IdRol { get; set; }

    [Display(Name = "Rol")]
    public virtual Role IdRolNavigation { get; set; } = null!;

    public virtual ICollection<Reserva> Reservas { get; set; } = new List<Reserva>();
}
