using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace api_soportevirtual.Models;

public partial class Ticket
{
    public int TicketId { get; set; }

    public DateTime FechaIngreso { get; set; }

    public DateTime? FechaCierre { get; set; }

    public string Descripccion { get; set; } = null!;

    public string? NombreBaseDatos { get; set; }

    public string? NombreAplicativo { get; set; }

    public string? NombreServidor { get; set; }

    public string? VersionSoftware { get; set; }

    public int? UsuarioId { get; set; }

    public int? EmpresaId { get; set; }

    public int? TipoErrorId { get; set; }

    public int? EstadoId { get; set; }

    [JsonIgnore]
    public virtual Empresa? Empresa { get; set; }

    [JsonIgnore]
    public virtual Estado? Estado { get; set; }

    [JsonIgnore]
    public virtual ICollection<TicketImagene> TicketImagenes { get; set; } = new List<TicketImagene>();


    public virtual TipoError? TipoError { get; set; }

    public virtual Usuario? Usuario { get; set; }
}