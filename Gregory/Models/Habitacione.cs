using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Gregory.Models;

public partial class Habitacione
{
    [Display(Name ="ID Habitación")]
    public int IdHabitacion { get; set; }

    public string Nombre { get; set; } = null!;

    [Display(Name = "ID Tipo de Habitacion")]
    public int IdTipoHabitacion { get; set; }

    public bool Estado { get; set; }

    public string? Descripcion { get; set; }

    public decimal Precio { get; set; }

    [Display(Name = "ID Inmueble")]
    public int IdInmueble { get; set; }

    public virtual ICollection<DetalleHabitacione> DetalleHabitaciones { get; set; } = new List<DetalleHabitacione>();

    public virtual ICollection<HabitacionesInmueble> HabitacionesInmuebles { get; set; } = new List<HabitacionesInmueble>();

    [Display(Name = "ID Inmueble")]
    public virtual Inmueble IdInmuebleNavigation { get; set; } = null!;

    [Display(Name = "ID Habitación")]
    public virtual TipoHabitacione IdTipoHabitacionNavigation { get; set; } = null!;

    public virtual ICollection<PaquetesHabitacione> PaquetesHabitaciones { get; set; } = new List<PaquetesHabitacione>();

    public virtual ICollection<PaquetesHospedaje> PaquetesHospedajes { get; set; } = new List<PaquetesHospedaje>();
}
