using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Gregory.Models;

public partial class Inmueble
{
    [Display(Name = "ID Inmueble")]
    public int IdInmueble { get; set; }

    public string Nombre { get; set; } = null!;

    [Display(Name = "Tipo de Inmueble")]
    public string TipoInmueble { get; set; } = null!;

    [Display(Name = "Cantidad")]
    public int NumerodeInmuebles { get; set; }

    public string? Descripcion { get; set; }

    public bool Estado { get; set; }

    [Display(Name = "Fecha de Registro")]
    public DateTime FechaRegistro { get; set; }

    public virtual ICollection<Habitacione> Habitaciones { get; set; } = new List<Habitacione>();

    public virtual ICollection<HabitacionesInmueble> HabitacionesInmuebles { get; set; } = new List<HabitacionesInmueble>();
}
