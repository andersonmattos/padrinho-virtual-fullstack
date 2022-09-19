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
    public class FestaController : ControllerBase
    {
        private readonly FestaContext _context;

        public FestaController(FestaContext context)
        {
            _context = context;
        }

        // GET: api/Festa
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Festa>>> GetFesta()
        {
            return await _context.Festa.ToListAsync();
        }

        // GET: api/Festa/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Festa>> GetFesta(int id)
        {
            var festa = await _context.Festa.FindAsync(id);

            if (festa == null)
            {
                return NotFound();
            }

            return festa;
        }

        // PUT: api/Festa/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFesta(int id, Festa festa)
        {
            if (id != festa.FestaId)
            {
                return BadRequest();
            }

            _context.Entry(festa).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FestaExists(id))
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

        // POST: api/Festa
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Festa>> PostFesta(Festa festa)
        {
            _context.Festa.Add(festa);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetFesta", new { id = festa.FestaId }, festa);
        }

        // DELETE: api/Festa/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFesta(int id)
        {
            var festa = await _context.Festa.FindAsync(id);
            if (festa == null)
            {
                return NotFound();
            }

            _context.Festa.Remove(festa);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool FestaExists(int id)
        {
            return _context.Festa.Any(e => e.FestaId == id);
        }
    }
}
