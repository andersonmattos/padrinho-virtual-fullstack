using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PVWApi.Models;

namespace PVWApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConvidadoController : ControllerBase
    {
        private readonly ConvidadoContext _context;

        public ConvidadoController(ConvidadoContext context)
        {
            _context = context;
        }

        // GET: api/Convidadoes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Convidado>>> GetConvidado()
        {
            return await _context.Convidado.ToListAsync();
        }

        // GET: api/Convidadoes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Convidado>> GetConvidado(int id)
        {
            var convidado = await _context.Convidado.FindAsync(id);

            if (convidado == null)
            {
                return NotFound();
            }

            return convidado;
        }

        // PUT: api/Convidadoes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutConvidado(int id, Convidado convidado)
        {
            if (id != convidado.ConvidadoId)
            {
                return BadRequest();
            }

            _context.Entry(convidado).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ConvidadoExists(id))
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

        // POST: api/Convidadoes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Convidado>> PostConvidado(Convidado convidado)
        {
            _context.Convidado.Add(convidado);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetConvidado", new { id = convidado.ConvidadoId }, convidado);
        }

        // DELETE: api/Convidadoes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteConvidado(int id)
        {
            var convidado = await _context.Convidado.FindAsync(id);
            if (convidado == null)
            {
                return NotFound();
            }

            _context.Convidado.Remove(convidado);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ConvidadoExists(int id)
        {
            return _context.Convidado.Any(e => e.ConvidadoId == id);
        }
    }
}
