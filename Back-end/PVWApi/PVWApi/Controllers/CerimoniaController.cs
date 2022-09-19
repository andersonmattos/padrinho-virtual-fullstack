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
    public class CerimoniaController : ControllerBase
    {
        private readonly CerimoniaContext _context;

        public CerimoniaController(CerimoniaContext context)
        {
            _context = context;
        }

        // GET: api/Cerimonia
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Cerimonia>>> GetCerimonia()
        {
            return await _context.Cerimonia.ToListAsync();
        }

        // GET: api/Cerimonia/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Cerimonia>> GetCerimonia(int id)
        {
            var cerimonia = await _context.Cerimonia.FindAsync(id);

            if (cerimonia == null)
            {
                return NotFound();
            }

            return cerimonia;
        }

        // PUT: api/Cerimonia/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCerimonia(int id, Cerimonia cerimonia)
        {
            if (id != cerimonia.CerimoniaId)
            {
                return BadRequest();
            }

            _context.Entry(cerimonia).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CerimoniaExists(id))
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

        // POST: api/Cerimonia
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Cerimonia>> PostCerimonia(Cerimonia cerimonia)
        {
            _context.Cerimonia.Add(cerimonia);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCerimonia", new { id = cerimonia.CerimoniaId }, cerimonia);
        }

        // DELETE: api/Cerimonia/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCerimonia(int id)
        {
            var cerimonia = await _context.Cerimonia.FindAsync(id);
            if (cerimonia == null)
            {
                return NotFound();
            }

            _context.Cerimonia.Remove(cerimonia);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CerimoniaExists(int id)
        {
            return _context.Cerimonia.Any(e => e.CerimoniaId == id);
        }
    }
}
