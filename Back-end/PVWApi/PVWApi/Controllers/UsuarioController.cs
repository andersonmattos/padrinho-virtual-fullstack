using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PVWApi.Models;
using Swashbuckle.AspNetCore.Annotations;

namespace PVWApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly UsuarioContext _context;

        public UsuarioController(UsuarioContext context)
        {
            _context = context;
        }

        // GET: api/Usuario
        [HttpGet]        
        public async Task<ActionResult<IEnumerable<Usuario>>> GetUsuario()
        {
          if (_context.Usuario == null)
          {
              return NotFound();
          }
            return await _context.Usuario.ToListAsync();
        }

        // GET: api/Usuario/5
        [HttpGet("{id}")]        
        public async Task<ActionResult<Usuario>> GetUsuario(int id)
        {
          if (_context.Usuario == null)
          {
              return NotFound();
          }
            var usuario = await _context.Usuario.FindAsync(id);

            if (usuario == null)
            {
                return NotFound();
            }

            return usuario;
        }

        // PUT: api/Usuario/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]        
        //[Route("/put")]
        public async Task<IActionResult> PutUsuario(int id, Usuario usuario)
        {
            if (id != usuario.LoginId)
            {
                return BadRequest();
            }

            _context.Entry(usuario).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UsuarioExists(id))
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

        // POST: api/Usuario
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        //[Route("/post")]
        public async Task<ActionResult<Usuario>> PostUsuario([FromBody] Usuario usuario)
        {
          if (_context.Usuario == null)
          {
              return Problem("Entity set 'UsuarioContext.Usuario'  is null.");
          }
            _context.Usuario.Add(usuario);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUsuario", new { id = usuario.LoginId }, usuario);
        }

        // DELETE: api/Usuario/5
        [HttpDelete("{id}")]
        //[Route("/delete")]
        public async Task<IActionResult> DeleteUsuario(int id)
        {
            if (_context.Usuario == null)
            {
                return NotFound();
            }
            var usuario = await _context.Usuario.FindAsync(id);
            if (usuario == null)
            {
                return NotFound();
            }

            _context.Usuario.Remove(usuario);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool UsuarioExists(int id)
        {
            return (_context.Usuario?.Any(e => e.LoginId == id)).GetValueOrDefault();
        }

        [HttpPatch("{id}")]
        public async Task<ActionResult> Patch(int id, [FromBody] JsonPatchDocument<Usuario> patchUsuario)
        {
            if (patchUsuario == null)
            {
                return BadRequest();
            }

            var usuarioDB = await _context.Usuario.FirstOrDefaultAsync(usr => usr.LoginId == id);

            if (usuarioDB == null)
            {
                return NotFound();
            }

            patchUsuario.ApplyTo(usuarioDB, ModelState);

            var isValid = TryValidateModel(usuarioDB);

            if (!isValid)
            {
                return BadRequest(ModelState);
            }

            await _context.SaveChangesAsync();

            return NoContent();

            /*
                if (patchUsuario != null)
            {
                var usuario = await _context.Usuario.FirstOrDefaultAsync(cat => cat.LoginId == id);
                patchUsuario.ApplyTo(usuario, ModelState);

                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                return new ObjectResult(usuario);
            }
            else
            {
                return BadRequest(ModelState);
            }*/



        }
    }
}
