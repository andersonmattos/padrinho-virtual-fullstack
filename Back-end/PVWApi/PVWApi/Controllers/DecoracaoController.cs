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
    public class DecoracaoController : ControllerBase
    {
        private readonly DecoracaoContext _context;

        public DecoracaoController(DecoracaoContext context)
        {
            _context = context;
        }

        // GET: api/Decoracao
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Decoracao>>> GetDecoracao()
        {
            return await _context.Decoracao.ToListAsync();
        }

        // GET: api/Decoracao/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Decoracao>> GetDecoracao(int id)
        {
            var decoracao = await _context.Decoracao.FindAsync(id);

            if (decoracao == null)
            {
                return NotFound();
            }

            return decoracao;
        }

        // PUT: api/Decoracao/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDecoracao(int id, Decoracao decoracao)
        {
            if (id != decoracao.DecoracaoId)
            {
                return BadRequest();
            }

            _context.Entry(decoracao).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DecoracaoExists(id))
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

        // POST: api/Decoracao
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Decoracao>> PostDecoracao(Decoracao decoracao)
        {
            _context.Decoracao.Add(decoracao);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDecoracao", new { id = decoracao.DecoracaoId }, decoracao);
        }

        // DELETE: api/Decoracao/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDecoracao(int id)
        {
            var decoracao = await _context.Decoracao.FindAsync(id);
            if (decoracao == null)
            {
                return NotFound();
            }

            _context.Decoracao.Remove(decoracao);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DecoracaoExists(int id)
        {
            return _context.Decoracao.Any(e => e.DecoracaoId == id);
        }
    }
}
