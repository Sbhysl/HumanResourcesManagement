using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HRManagement.Data;
using HRManagement.Data.Entities;

namespace HRManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PublicHolidaysController : ControllerBase
    {
        private readonly HRDbContext _context;

        public PublicHolidaysController(HRDbContext context)
        {
            _context = context;
        }

        // GET: api/PublicHolidays
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PublicHolidays>>> GetPublicHolidays()
        {

            return await _context.PublicHolidays.ToListAsync();
        }

        // GET: api/PublicHolidays/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PublicHolidays>> GetPublicHolidays(long id)
        {
            PublicHolidays publicHolidays = await _context.PublicHolidays.FindAsync(id);

            if (publicHolidays == null)
            {
                return NotFound();
            }

            return publicHolidays;
        }

       
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPublicHolidays(long id, PublicHolidays publicHolidays)
        {
            if (id != publicHolidays.ID)
            {
                return BadRequest();
            }

            _context.Entry(publicHolidays).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PublicHolidaysExists(id))
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

  
        [HttpPost]
        public async Task<ActionResult<PublicHolidays>> PostPublicHolidays(PublicHolidays publicHolidays)
        {
            _context.PublicHolidays.Add(publicHolidays);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPublicHolidays", new { id = publicHolidays.ID }, publicHolidays);
        }

        // DELETE: api/PublicHolidays/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<PublicHolidays>> DeletePublicHolidays(long id)
        {
            var publicHolidays = await _context.PublicHolidays.FindAsync(id);
            if (publicHolidays == null)
            {
                return NotFound();
            }

            _context.PublicHolidays.Remove(publicHolidays);
            await _context.SaveChangesAsync();

            return publicHolidays;
        }

        private bool PublicHolidaysExists(long id)
        {
            return _context.PublicHolidays.Any(e => e.ID == id);
        }
    }
}
