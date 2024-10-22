using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Gregory.Models;

public partial class Permiso
{
    [Display(Name = "ID Permiso")]
    public int IdPermiso { get; set; }

    [Display(Name = "Nombre del Permiso")]
    public string NombrePermiso { get; set; } = null!;
    public string? Descripcion { get; set; }

    public bool Estado { get; set; }

    public virtual ICollection<RolesPermiso> RolesPermisos { get; set; } = new List<RolesPermiso>();
}
