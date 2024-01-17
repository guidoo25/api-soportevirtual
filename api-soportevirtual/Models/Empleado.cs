using System;
using System.Collections.Generic;

namespace api_soportevirtual.Models;

public partial class Empleado
{
    public int EmpleadoId { get; set; }

    public string Nombre { get; set; } = null!;

    public string Apellido { get; set; } = null!;

    public string? Area { get; set; }

    public virtual ICollection<Usuario> Usuarios { get; set; } = new List<Usuario>();
}
