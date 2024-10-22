﻿using System;
using System.Collections.Generic;

namespace Gregory.Models;

public partial class Cliente
{
    public int IdCliente { get; set; }

    public string TipoDocumento { get; set; } = null!;

    public string Documento { get; set; } = null!;

    public string Nombre { get; set; } = null!;

    public string Apellido { get; set; } = null!;

    public string? Direccion { get; set; }

    public string? Celular { get; set; }

    public string CorreoElectronico { get; set; } = null!;

    public bool Estado { get; set; }

    public int IdRol { get; set; }

    public virtual Role IdRolNavigation { get; set; } = null!;

    public virtual ICollection<Reserva> Reservas { get; set; } = new List<Reserva>();
}
