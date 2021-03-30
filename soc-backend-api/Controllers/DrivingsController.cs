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
        [Route("api/drivings")]
        public async Task<ActionResult<IEnumerable<Driving>>> GetDrivings()
        {
            return await _context.Drivings.ToListAsync();
        }

        // GET: api/Drivings/5
        [HttpGet]
        [Route("api/drivings/{id}")]
        public async Task<ActionResult<Driving>> GetDriving(int id)
        {
            var driving = await _context.Drivings.FindAsync(id);

            if (driving == null)
            {
                return NotFound();
            }

            return driving;
        }

        // POST: api/Drivings
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        [Route("api/drivings")]
        public async Task<ActionResult<Driving>> PostDriving(Driving driving)
        {
            _context.Drivings.Add(driving);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDriving", new { id = driving.Id }, driving);
        }
    }
}
