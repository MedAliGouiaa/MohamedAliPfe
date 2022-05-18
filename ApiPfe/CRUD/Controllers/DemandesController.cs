using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CRUD.Models;

namespace CRUD.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DemandesController : ControllerBase
    {
        private readonly UserContext _context;

        public DemandesController(UserContext context)
        {
            _context = context;
        }

        // GET: api/Demandes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Demande>>> GetDemandes()
        {
            return await _context.Demandes.ToListAsync();
        }

        // GET: api/Demandes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Demande>> GetDemande(int id)
        {
            var demande = await _context.Demandes.FindAsync(id);

            if (demande == null)
            {
                return NotFound();
            }

            return demande;
        }

        // PUT: api/Demandes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDemande(int id, Demande demande)
        {
            if (id != demande.IdDemande)
            {
                return BadRequest();
            }

            _context.Entry(demande).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DemandeExists(id))
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

        // POST: api/Demandes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Demande>> PostDemande(Demande demande)
        {
            demande.Date = DateTime.Now;
            _context.Demandes.Add(demande);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDemande", new { id = demande.IdDemande }, demande);
        }

        // DELETE: api/Demandes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDemande(int id)
        {
            var demande = await _context.Demandes.FindAsync(id);
            if (demande == null)
            {
                return NotFound();
            }

            _context.Demandes.Remove(demande);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DemandeExists(int id)
        {
            return _context.Demandes.Any(e => e.IdDemande == id);
        }
    }
}
