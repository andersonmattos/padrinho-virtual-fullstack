using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PVWApi.Models;

namespace PVWApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CasamentoController : ControllerBase
    {
        private readonly CasamentoContext _context;

        public CasamentoController(CasamentoContext context)
        {
            _context = context;
        }

        // GET: api/Casamento
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Casamento>>> GetCasamento()
        {
            return await _context.Casamento.ToListAsync();
        }

        // GET: api/Casamento/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Casamento>> GetCasamento(int id)
        {
            var casamento = await _context.Casamento.FindAsync(id);

            if (casamento == null)
            {
                return NotFound();
            }

            return casamento;
        }

        // PUT: api/Casamento/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCasamento(int id, Casamento casamento)
        {
            if (id != casamento.CasamentoId)
            {
                return BadRequest();
            }

            _context.Entry(casamento).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CasamentoExists(id))
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

        // POST: api/Casamento
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Casamento>> PostCasamento(Casamento casamento)
        {
            _context.Casamento.Add(casamento);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCasamento", new { id = casamento.CasamentoId }, casamento);
        }

        // DELETE: api/Casamento/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCasamento(int id)
        {
            var casamento = await _context.Casamento.FindAsync(id);
            if (casamento == null)
            {
                return NotFound();
            }

            _context.Casamento.Remove(casamento);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CasamentoExists(int id)
        {
            return _context.Casamento.Any(e => e.CasamentoId == id);
        }

        [HttpPatch("{id}")]
        public async Task<ActionResult> Patch(int id, [FromBody] JsonPatchDocument<Casamento> patchCasamento)
        {

            if (patchCasamento == null)
            {
                return BadRequest();
            }

            var casamentoDB = await _context.Casamento.FirstOrDefaultAsync(csm => csm.CasamentoId == id);

            if (casamentoDB == null)
            {
                return NotFound();
            }

            patchCasamento.ApplyTo(casamentoDB, ModelState);

            var isValid = TryValidateModel(casamentoDB);

            if (!isValid)
            {
                return BadRequest(ModelState);
            }

            await _context.SaveChangesAsync();

            return NoContent();
        }

        }
}
