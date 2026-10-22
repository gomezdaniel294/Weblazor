using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TodoApi.Models;

namespace TodoApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ClientesController : ControllerBase
{
    private readonly Conexiones _context;

    public ClientesController(Conexiones context) => _context = context;

    // GET: api/clientes
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Clientes>>> GetClientes()
        => await _context.Clientes.AsNoTracking().ToListAsync();

    // GET: api/clientes/5
    [HttpGet("{id}")]
    public async Task<ActionResult<Clientes>> GetCliente(int id)
    {
        var cliente = await _context.Clientes.FindAsync(id);
        return cliente is null ? NotFound() : cliente;
    }

    // POST: api/clientes
    [HttpPost]
    public async Task<ActionResult<Clientes>> PostCliente(Clientes cliente)
    {
        _context.Clientes.Add(cliente);
        await _context.SaveChangesAsync();
        return CreatedAtAction(nameof(GetCliente), new { id = cliente.Id_cliente }, cliente);
    }

    // PUT: api/clientes/5
    [HttpPut("{id}")]
    public async Task<IActionResult> PutCliente(int id, Clientes cliente)
    {
        if (id != cliente.Id_cliente) return BadRequest();

        _context.Entry(cliente).State = EntityState.Modified;
        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!await _context.Clientes.AnyAsync(c => c.Id_cliente == id)) return NotFound();
            throw;
        }
        return NoContent();
    }

    // DELETE: api/clientes/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteCliente(int id)
    {
        var cliente = await _context.Clientes.FindAsync(id);
        if (cliente is null) return NotFound();

        _context.Clientes.Remove(cliente);
        await _context.SaveChangesAsync();
        return NoContent();
    }
}
