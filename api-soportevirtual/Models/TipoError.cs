using System;
using System.Collections.Generic;

namespace api_soportevirtual.Models;

public partial class TipoError
{
    public int TipoErrorId { get; set; }

    public string Descripccion { get; set; } = null!;

    public virtual ICollection<Ticket> Tickets { get; set; } = new List<Ticket>();
}
