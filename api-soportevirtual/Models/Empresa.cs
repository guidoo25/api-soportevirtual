using System;
using System.Collections.Generic;

namespace api_soportevirtual.Models;

public partial class Empresa
{
    public int EmpresaId { get; set; }

    public string RazonSocial { get; set; } = null!;

    public string Ruc { get; set; } = null!;

    public string Direccion { get; set; } = null!;

    public string Telefono { get; set; } = null!;

    public string Email { get; set; } = null!;

    public virtual ICollection<Ticket> Tickets { get; set; } = new List<Ticket>();
}
