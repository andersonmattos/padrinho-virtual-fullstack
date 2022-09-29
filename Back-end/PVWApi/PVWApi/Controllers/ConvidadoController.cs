using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
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

        // GET: api/Convidadoes/5 - Método criado para localizar usando id do Casamento
        [HttpGet("/api/Convidado/casamentoId/{CasamentoId}")]
        public async Task<ActionResult<IEnumerable<Convidado>>> GetConvidadoByCasamentoId(int CasamentoId)
        {
                        
            var convidado = await _context.Convidado.Where(x => x.CasamentoId == CasamentoId).ToListAsync();            

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

        [HttpPatch("{id}")]
        public async Task<ActionResult> Patch(int id, [FromBody] JsonPatchDocument<Convidado> patchConvidado)
        {

            if (patchConvidado == null)
            {
                return BadRequest();
            }

            var convidadoDB = await _context.Convidado.FirstOrDefaultAsync(cvn => cvn.ConvidadoId == id);

            if (convidadoDB == null)
            {
                return NotFound();
            }

            patchConvidado.ApplyTo(convidadoDB, ModelState);

            var isValid = TryValidateModel(convidadoDB);

            if (!isValid)
            {
                return BadRequest(ModelState);
            }

            await _context.SaveChangesAsync();

            return NoContent();


            /*if (patchConvidado != null)
            {
                var convidado = await _context.Convidado.FirstOrDefaultAsync(cat => cat.ConvidadoId == id);
                patchConvidado.ApplyTo(convidado, ModelState);

                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                return new ObjectResult(convidado);
            }
            else
            {
                return BadRequest(ModelState);
            }*/

            /*var convidado = await _context.Convidado.FirstOrDefaultAsync(conv => conv.ConvidadoId == id);

            if (convidado == null)
                return NotFound();

            patchConvidado.ApplyTo(convidado);
            await _context.SaveChangesAsync();

            return NoContent();*/
        }
    }
}
