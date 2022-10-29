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
    public class InspactionTypesController : ControllerBase
    {
        private readonly DBContext _context;

        public InspactionTypesController(DBContext context)
        {
            _context = context;
        }

        // GET: api/InspactionTypes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<InspactionType>>> GetInspactionTypes()
        {
            return await _context.InspactionTypes.ToListAsync();
        }

        // GET: api/InspactionTypes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<InspactionType>> GetInspactionType(int id)
        {
            var inspactionType = await _context.InspactionTypes.FindAsync(id);

            if (inspactionType == null)
            {
                return NotFound();
            }

            return inspactionType;
        }

        // PUT: api/InspactionTypes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutInspactionType(int id, InspactionType inspactionType)
        {
            if (id != inspactionType.InspactionTypeId)
            {
                return BadRequest();
            }

            _context.Entry(inspactionType).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!InspactionTypeExists(id))
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

        // POST: api/InspactionTypes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<InspactionType>> PostInspactionType(InspactionType inspactionType)
        {
            _context.InspactionTypes.Add(inspactionType);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetInspactionType", new { id = inspactionType.InspactionTypeId }, inspactionType);
        }

        // DELETE: api/InspactionTypes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteInspactionType(int id)
        {
            var inspactionType = await _context.InspactionTypes.FindAsync(id);
            if (inspactionType == null)
            {
                return NotFound();
            }

            _context.InspactionTypes.Remove(inspactionType);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool InspactionTypeExists(int id)
        {
            return _context.InspactionTypes.Any(e => e.InspactionTypeId == id);
        }
    }
}
