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
    public class PersonelsController : ControllerBase
    {
        private readonly HRDbContext _context;

        public PersonelsController(HRDbContext context)
        {
            _context = context;
        }

        // GET: api/Personels
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Personel>>> GetPersonels()
        {
            return await _context.Personels.ToListAsync();
        }

        // GET: api/Personels/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Personel>> GetPersonel(long id)
        {
            Personel personel = await _context.Personels.FindAsync(id);

            if (personel == null)
            {
                return NotFound();
            }

            return personel;
        }

        // PUT: api/Personels/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPersonel(long id, Personel personel)
        {
            if (id != personel.ID)
            {
                return BadRequest();
            }

            _context.Entry(personel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PersonelExists(id))
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

        // POST: api/Personels
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Personel>> PostPersonel(Personel personel)
        {
            _context.Personels.Add(personel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPersonel", new { id = personel.ID }, personel);
        }

        // DELETE: api/Personels/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Personel>> DeletePersonel(long id)
        {
            var personel = await _context.Personels.FindAsync(id);
            if (personel == null)
            {
                return NotFound();
            }

            _context.Personels.Remove(personel);
            await _context.SaveChangesAsync();

            return personel;
        }

        private bool PersonelExists(long id)
        {
            return _context.Personels.Any(e => e.ID == id);
        }
    }
}
