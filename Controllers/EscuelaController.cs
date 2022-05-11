using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ApiExamenFinal.Data;
using ApiExamenFinal.Entities;

namespace ApiExamenFinal.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EscuelaController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public EscuelaController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Escuela
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Escuela>>> GetEscuela()
        {
            return await _context.Escuela.ToListAsync();
        }

        // GET: api/Escuela/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Escuela>> GetEscuela(int id)
        {
            var escuela = await _context.Escuela.FindAsync(id);

            if (escuela == null)
            {
                return NotFound();
            }

            return escuela;
        }

        // PUT: api/Escuela/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEscuela(int id, Escuela escuela)
        {
            if (id != escuela.Id)
            {
                return BadRequest();
            }

            _context.Entry(escuela).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EscuelaExists(id))
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

        // POST: api/Escuela
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Escuela>> PostEscuela(Escuela escuela)
        {
            _context.Escuela.Add(escuela);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEscuela", new { id = escuela.Id }, escuela);
        }

        // DELETE: api/Escuela/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Escuela>> DeleteEscuela(int id)
        {
            var escuela = await _context.Escuela.FindAsync(id);
            if (escuela == null)
            {
                return NotFound();
            }

            _context.Escuela.Remove(escuela);
            await _context.SaveChangesAsync();

            return escuela;
        }

        private bool EscuelaExists(int id)
        {
            return _context.Escuela.Any(e => e.Id == id);
        }
    }
}
