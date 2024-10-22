﻿using System;
using System.Collections.Generic;

namespace Gregory.Models;

public partial class Inmueble
{
    public int IdInmueble { get; set; }

    public string Nombre { get; set; } = null!;

    public string TipoInmueble { get; set; } = null!;

    public int NumerodeInmuebles { get; set; }

    public string? Descripcion { get; set; }

    public bool Estado { get; set; }

    public DateTime FechaRegistro { get; set; }

    public virtual ICollection<Habitacione> Habitaciones { get; set; } = new List<Habitacione>();

    public virtual ICollection<HabitacionesInmueble> HabitacionesInmuebles { get; set; } = new List<HabitacionesInmueble>();
}
