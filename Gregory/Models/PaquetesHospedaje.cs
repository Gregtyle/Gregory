using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Gregory.Models;

public partial class PaquetesHospedaje
{
    [Display(Name = "ID Paquete")]
    public int IdPaquete { get; set; }

    public string Nombre { get; set; } = null!;

    public string? Descripcion { get; set; }

    [Display(Name = "Precio")]
    public decimal PrecioTotal { get; set; }

    public int Duracion { get; set; }

    [Display(Name = "ID Servicio")]
    public int IdServicio { get; set; }

    [Display(Name = "ID Habitación")]
    public int IdHabitacion { get; set; }

    public virtual ICollection<DetallePaquete> DetallePaquetes { get; set; } = new List<DetallePaquete>();

    [Display(Name = "Habitación")]
    public virtual Habitacione IdHabitacionNavigation { get; set; } = null!;

    [Display(Name = "Servicio")]
    public virtual Servicio IdServicioNavigation { get; set; } = null!;

    public virtual ICollection<PaquetesHabitacione> PaquetesHabitaciones { get; set; } = new List<PaquetesHabitacione>();

    public virtual ICollection<PaquetesServicio> PaquetesServicios { get; set; } = new List<PaquetesServicio>();
}
