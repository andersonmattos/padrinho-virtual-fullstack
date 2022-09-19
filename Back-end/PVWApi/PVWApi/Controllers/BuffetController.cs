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
    public class BuffetController : ControllerBase
    {
        private readonly BuffetContext _context;

        public BuffetController(BuffetContext context)
        {
            _context = context;
        }

        // GET: api/Buffet
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Buffet>>> GetBuffet()
        {
            return await _context.Buffet.ToListAsync();
        }

        // GET: api/Buffet/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Buffet>> GetBuffet(int id)
        {
            var buffet = await _context.Buffet.FindAsync(id);

            if (buffet == null)
            {
                return NotFound();
            }

            return buffet;
        }

        // PUT: api/Buffet/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBuffet(int id, Buffet buffet)
        {
            if (id != buffet.BuffetId)
            {
                return BadRequest();
            }

            _context.Entry(buffet).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BuffetExists(id))
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

        // POST: api/Buffet
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Buffet>> PostBuffet(Buffet buffet)
        {
            _context.Buffet.Add(buffet);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBuffet", new { id = buffet.BuffetId }, buffet);
        }

        // DELETE: api/Buffet/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBuffet(int id)
        {
            var buffet = await _context.Buffet.FindAsync(id);
            if (buffet == null)
            {
                return NotFound();
            }

            _context.Buffet.Remove(buffet);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool BuffetExists(int id)
        {
            return _context.Buffet.Any(e => e.BuffetId == id);
        }
    }
}
