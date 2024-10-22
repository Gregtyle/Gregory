using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Gregory.Models;

public partial class Servicio
{
    [Display(Name = "ID de Servicio")]
    public int IdServicio { get; set; }

    public string Nombre { get; set; } = null!;

    public bool Estado { get; set; }

    public string? Descripcion { get; set; }

    public decimal Precio { get; set; }

    public virtual ICollection<DetalleServicio> DetalleServicios { get; set; } = new List<DetalleServicio>();

    public virtual ICollection<PaquetesHospedaje> PaquetesHospedajes { get; set; } = new List<PaquetesHospedaje>();

    public virtual ICollection<PaquetesServicio> PaquetesServicios { get; set; } = new List<PaquetesServicio>();
}
