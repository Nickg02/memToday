using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using memTodayApi.Models;

namespace memTodayApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class memTodayItemsController : ControllerBase
    {
        private readonly memTodayContext _context;

        public memTodayItemsController(memTodayContext context)
        {
            _context = context;
        }

        // GET: api/memTodayItems
        [HttpGet]
        public async Task<ActionResult<IEnumerable<memTodayItem>>> GetmemTodayItems()
        {
            return await _context.memTodayItems.ToListAsync();
        }

        // GET: api/memTodayItems/5
        [HttpGet("{id}")]
        public async Task<ActionResult<memTodayItem>> GetmemTodayItem(long id)
        {
            var memTodayItem = await _context.memTodayItems.FindAsync(id);

            if (memTodayItem == null)
            {
                return NotFound();
            }

            return memTodayItem;
        }

        // PUT: api/memTodayItems/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutmemTodayItem(long id, memTodayItem memTodayItem)
        {
            if (id != memTodayItem.Id)
            {
                return BadRequest();
            }

            _context.Entry(memTodayItem).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!memTodayItemExists(id))
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

        // POST: api/memTodayItems
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<memTodayItem>> PostmemTodayItem(memTodayItem memTodayItem)
        {
            _context.memTodayItems.Add(memTodayItem);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetmemTodayItem", new { id = memTodayItem.Id }, memTodayItem);
        }

        // DELETE: api/memTodayItems/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletememTodayItem(long id)
        {
            var memTodayItem = await _context.memTodayItems.FindAsync(id);
            if (memTodayItem == null)
            {
                return NotFound();
            }

            _context.memTodayItems.Remove(memTodayItem);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool memTodayItemExists(long id)
        {
            return _context.memTodayItems.Any(e => e.Id == id);
        }
    }
}
