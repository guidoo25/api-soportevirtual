using System;
using System.Collections.Generic;

namespace api_soportevirtual.Models;

public partial class Role
{
    public int RolesId { get; set; }

    public string NombreRoles { get; set; } = null!;

    public virtual ICollection<Usuario> Usuarios { get; set; } = new List<Usuario>();
}
