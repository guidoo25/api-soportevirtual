using api_soportevirtual.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


[ApiController]
[Route("api/[controller]")]
public class EmpresaController : ControllerBase
{
    private readonly Test1Context _context;

    public EmpresaController(Test1Context context)
    {
        _context = context;
    }

    // GET: api/Empresa
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Empresa>>> GetEmpresas()
    {
        return await _context.Empresas.ToListAsync();
    }

    // GET: api/Empresa/5
    [HttpGet("{id}")]
    public async Task<ActionResult<Empresa>> GetEmpresa(int id)
    {
        var empresa = await _context.Empresas.FindAsync(id);

        if (empresa == null)
        {
            return NotFound();
        }

        return empresa;
    }

    // POST: api/Empresa
    [HttpPost]
    public async Task<ActionResult<Empresa>> PostEmpresa(Empresa empresa)
    {
        _context.Empresas.Add(empresa);
        await _context.SaveChangesAsync();

        return CreatedAtAction("GetEmpresa", new { id = empresa.EmpresaId }, empresa);
    }

    // PUT: api/Empresa/5
    [HttpPut("{id}")]
    public async Task<IActionResult> PutEmpresa(int id, Empresa empresa)
    {
        if (id != empresa.EmpresaId)
        {
            return BadRequest();
        }

        _context.Entry(empresa).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
             }
            
        catch (DbUpdateConcurrencyException)
        {
            if (!EmpresaExists(id))
            {
                return NotFound();
            }
            else
            {
                throw;
            }
        }

        return NoContent();
    }

    private bool EmpresaExists(int id)
    {
        return _context.Empresas.Any(e => e.EmpresaId == id);
    }
}