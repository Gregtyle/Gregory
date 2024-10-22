using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Gregory.Models;

public partial class Usuario
{
    [Display(Name = "ID Usuario")]
    public int IdUsuario { get; set; }

    [Display(Name = "Tipo de Documento")]
    public string TipoDocumento { get; set; } = null!;

    public string Documento { get; set; } = null!;

    public string Nombre { get; set; } = null!;

    public string Apellido { get; set; } = null!;

    public string? Celular { get; set; }

    public string? Direccion { get; set; }

    [Display(Name = "Correo Electronico")]
    public string CorreoElectronico { get; set; } = null!;

    public bool Estado { get; set; }

    [Display(Name = "Fecha de Creacion")]
    public DateTime? FechaCreacion { get; set; }

    [Display(Name = "Rol")]
    public int IdRol { get; set; }

    [Display(Name = "ID Rol")]
    public virtual Role IdRolNavigation { get; set; } = null!;

    public virtual ICollection<Reserva> Reservas { get; set; } = new List<Reserva>();
}