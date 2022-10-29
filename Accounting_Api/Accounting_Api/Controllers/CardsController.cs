using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Accounting_Api.Data;
using Accounting_Api.Models.BankCard;

namespace Accounting_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CardsController : ControllerBase
    {
        private readonly DBContext _context;

        public CardsController(DBContext context)
        {
            _context = context;
        }

        // GET: api/Cards
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Card>>> GetCards()
        {
            return await _context.Cards.ToListAsync();
        }

        [HttpGet]
        [Route("{id:guid}")]
        [ActionName("GetCards")]
        public async Task<IActionResult> GetCards([FromRoute] Guid id)
        {
            var card = await _context.Cards.FirstOrDefaultAsync(c=>c.Id == id);
            if(card != null)
            {
                return Ok(card);
            }
            return NotFound("Card not fount");
        }

        // GET: api/Cards/5
        //[HttpGet("{id}")]
        //public async Task<ActionResult<Card>> GetCard(Guid id)
        //{
        //    var card = await _context.Cards.FindAsync(id);

        //    if (card == null)
        //    {
        //        return NotFound();
        //    }

        //    return card;
        //}

        // PUT: api/Cards/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id:guid}")]
        public async Task<IActionResult> PutCard([FromRoute] Guid id, [FromBody] Card card)
        {
            if (id != card.Id)
            {
                return BadRequest();
            }
            
            _context.Entry(card).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CardExists(id))
                {
                    return NotFound("Card not found");
                }
                else
                {
                    throw;
                }
            }
            var carddata = await _context.Cards.FindAsync(id);
            return Ok(carddata);
        }

        // POST: api/Cards
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Card>> PostCard([FromBody] Card card)
        {
            card.Id = Guid.NewGuid();
            _context.Cards.Add(card);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetCards), new { id = card.Id }, card);
        }

        // DELETE: api/Cards/5
        [HttpDelete]
        [Route("{id:guid}")]
        public async Task<IActionResult> DeleteCard([FromRoute] Guid id)
        {
            var card = await _context.Cards.FindAsync(id);
            if (card == null)
            {
                return NotFound("Card not found");
            }
            _context.Cards.Remove(card);
            await _context.SaveChangesAsync();
            var carddata = await _context.Cards.FindAsync(id);
            return Ok(carddata);
        }

        private bool CardExists(Guid id)
        {
            return _context.Cards.Any(e => e.Id == id);
        }
    }
}
