using api_soportevirtual.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;



[Route("api/[controller]")]
[ApiController]
public class TicketsController : ControllerBase
{
    private readonly Test1Context _context;

    public TicketsController(Test1Context context)
    {
        _context = context;
    }

    // GET: api/Tickets
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Ticket>>> GetTickets()
    {
        return await _context.Tickets.ToListAsync();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Ticket>> GetTicket(int id)
    {
        var ticket = await _context.Tickets
            .Include(t => t.Empresa)
            .Include(t => t.Usuario)
            .Include(t => t.TipoError)
            .FirstOrDefaultAsync(t => t.TicketId == id);

        if (ticket == null)
        {
            return NotFound();
        }

        return ticket;
    }

    [HttpPost]
    public async Task<ActionResult<Ticket>> PostTicket(Ticket ticket)
    {
        _context.Tickets.Add(ticket);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetTicket), new { id = ticket.TicketId }, ticket);
    }


    //consultar tickets por idEmpleado
    [HttpGet("Empleado/{empleadoId}")]
    public async Task<ActionResult<IEnumerable<Ticket>>> GetTicketsByEmpleado(int empleadoId)
    {
        var tickets = await _context.Tickets
            .Include(t => t.Usuario)
            .Include(t => t.Empresa)
            .Include(t => t.TipoError)
            .Where(t => t.UsuarioId == empleadoId)
            .ToListAsync();

        if (tickets == null || !tickets.Any())
        {
            return NotFound();
        }

        return tickets;
    }


    [HttpPut("{id}")]
    public async Task<IActionResult> PutTicket(int id, Ticket ticket)
    {
        if (id != ticket.TicketId)
        {
            return BadRequest();
        }

        _context.Entry(ticket).State = EntityState.Modified;
        await _context.SaveChangesAsync();

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteTicket(int id)
    {
        var ticket = await _context.Tickets.FindAsync(id);
        if (ticket == null)
        {
            return NotFound();
        }

        _context.Tickets.Remove(ticket);
        await _context.SaveChangesAsync();

        return NoContent();
    }
}