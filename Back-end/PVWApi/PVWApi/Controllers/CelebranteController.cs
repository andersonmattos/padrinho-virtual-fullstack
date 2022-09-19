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
    public class CelebranteController : ControllerBase
    {
        private readonly CelebranteContext _context;

        public CelebranteController(CelebranteContext context)
        {
            _context = context;
        }

        // GET: api/Celebrante
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Celebrante>>> GetCelebrante()
        {
            return await _context.Celebrante.ToListAsync();
        }

        // GET: api/Celebrante/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Celebrante>> GetCelebrante(int id)
        {
            var celebrante = await _context.Celebrante.FindAsync(id);

            if (celebrante == null)
            {
                return NotFound();
            }

            return celebrante;
        }

        // PUT: api/Celebrante/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCelebrante(int id, Celebrante celebrante)
        {
            if (id != celebrante.CelebranteId)
            {
                return BadRequest();
            }

            _context.Entry(celebrante).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CelebranteExists(id))
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

        // POST: api/Celebrante
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Celebrante>> PostCelebrante(Celebrante celebrante)
        {
            _context.Celebrante.Add(celebrante);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCelebrante", new { id = celebrante.CelebranteId }, celebrante);
        }

        // DELETE: api/Celebrante/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCelebrante(int id)
        {
            var celebrante = await _context.Celebrante.FindAsync(id);
            if (celebrante == null)
            {
                return NotFound();
            }

            _context.Celebrante.Remove(celebrante);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CelebranteExists(int id)
        {
            return _context.Celebrante.Any(e => e.CelebranteId == id);
        }
    }
}
