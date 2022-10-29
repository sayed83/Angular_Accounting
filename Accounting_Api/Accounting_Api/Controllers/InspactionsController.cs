using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Accounting_Api.Data;
using Accounting_Api.Models.Inspactions;

namespace Accounting_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InspactionsController : ControllerBase
    {
        private readonly DBContext _context;

        public InspactionsController(DBContext context)
        {
            _context = context;
        }

        // GET: api/Inspactions
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Inspaction>>> GetInspactions()
        {
            return await _context.Inspactions.ToListAsync();
        }

        // GET: api/Inspactions/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Inspaction>> GetInspaction(int id)
        {
            var inspaction = await _context.Inspactions.FindAsync(id);

            if (inspaction == null)
            {
                return NotFound();
            }

            return inspaction;
        }

        // PUT: api/Inspactions/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutInspaction(int id, Inspaction inspaction)
        {
            if (id != inspaction.InspactionId)
            {
                return BadRequest();
            }

            _context.Entry(inspaction).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!InspactionExists(id))
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

        // POST: api/Inspactions
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Inspaction>> PostInspaction(Inspaction inspaction)
        {
            _context.Inspactions.Add(inspaction);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetInspaction", new { id = inspaction.InspactionId }, inspaction);
        }

        // DELETE: api/Inspactions/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteInspaction(int id)
        {
            var inspaction = await _context.Inspactions.FindAsync(id);
            if (inspaction == null)
            {
                return NotFound();
            }

            _context.Inspactions.Remove(inspaction);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool InspactionExists(int id)
        {
            return _context.Inspactions.Any(e => e.InspactionId == id);
        }
    }
}
