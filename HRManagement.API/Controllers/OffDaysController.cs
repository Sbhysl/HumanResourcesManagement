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
    public class OffDaysController : ControllerBase
    {
        private readonly HRDbContext _context;

        public OffDaysController(HRDbContext context)
        {
            _context = context;
        }

        // GET: api/OffDays
        [HttpGet]
        public async Task<ActionResult<IEnumerable<OffDay>>> GetOffDays()
        {
            return await _context.OffDays.ToListAsync();
        }

        // GET: api/OffDays/5
        [HttpGet("{id}")]
        public async Task<ActionResult<OffDay>> GetOffDay(long id)
        {
            var offDay = await _context.OffDays.FindAsync(id);

            if (offDay == null)
            {
                return NotFound();
            }

            return offDay;
        }

        // PUT: api/OffDays/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOffDay(long id, OffDay offDay)
        {
            if (id != offDay.ID)
            {
                return BadRequest();
            }

            _context.Entry(offDay).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OffDayExists(id))
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

        // POST: api/OffDays
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<OffDay>> PostOffDay(OffDay offDay)
        {
            _context.OffDays.Add(offDay);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetOffDay", new { id = offDay.ID }, offDay);
        }

        // DELETE: api/OffDays/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<OffDay>> DeleteOffDay(long id)
        {
            var offDay = await _context.OffDays.FindAsync(id);
            if (offDay == null)
            {
                return NotFound();
            }

            _context.OffDays.Remove(offDay);
            await _context.SaveChangesAsync();

            return offDay;
        }

        private bool OffDayExists(long id)
        {
            return _context.OffDays.Any(e => e.ID == id);
        }
    }
}
