using System;
using System.Collections.Generic;

namespace api_soportevirtual.Models;

public partial class TicketImagene
{
    public int ImagenId { get; set; }

    public byte[]? Imagen { get; set; }

    public int? TicketId { get; set; }

    public virtual Ticket? Ticket { get; set; }
}
