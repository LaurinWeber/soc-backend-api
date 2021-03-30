using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using soc_backend_api.Models;

namespace soc_backend_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DrivingsController : ControllerBase
    {
        private readonly StickOnCarContext _context;

        public DrivingsController(StickOnCarContext context)
        {
            _context = context;
        }

        // GET: api/Drivings
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Driving>>> GetDrivings()
        {
            return await _context.Drivings.ToListAsync();
        }

        // GET: api/Drivings/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Driving>> GetDriving(int id)
        {
            var driving = await _context.Drivings.FindAsync(id);

            if (driving == null)
            {
                return NotFound();
            }

            return driving;
        }

        // PUT: api/Drivings/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDriving(int id, Driving driving)
        {
            if (id != driving.Id)
            {
                return BadRequest();
            }

            _context.Entry(driving).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DrivingExists(id))
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

        // POST: api/Drivings
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Driving>> PostDriving(Driving driving)
        {
            _context.Drivings.Add(driving);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDriving", new { id = driving.Id }, driving);
        }

        // DELETE: api/Drivings/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Driving>> DeleteDriving(int id)
        {
            var driving = await _context.Drivings.FindAsync(id);
            if (driving == null)
            {
                return NotFound();
            }

            _context.Drivings.Remove(driving);
            await _context.SaveChangesAsync();

            return driving;
        }

        private bool DrivingExists(int id)
        {
            return _context.Drivings.Any(e => e.Id == id);
        }
    }
}
