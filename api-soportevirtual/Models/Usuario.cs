using System;
using System.Collections.Generic;

namespace api_soportevirtual.Models;


public partial class Usuario
{
    public int UsuarioId { get; set; }

    public string NombreUsuario { get; set; } = null!;

    public string Passwordhash { get; set; } = null!;

    public string? PasswordSalt { get; set; } 

    public int? RolesId { get; set; }

    public int? EmpleadoId { get; set; }

    public virtual Empleado? Empleado { get; set; }

    public virtual Role? Roles { get; set; }

    public virtual ICollection<Ticket> Tickets { get; set; } = new List<Ticket>();

}
