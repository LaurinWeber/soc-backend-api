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
    public class PeopleController : ControllerBase
    {
        private readonly StickOnCarContext _context;

        public PeopleController(StickOnCarContext context)
        {
            _context = context;
        }

        // GET: api/People
        [HttpGet]
        [Route("api/people")]
        public async Task<ActionResult<IEnumerable<Person>>> GetPeople()
        {
            return await _context.People.ToListAsync();
        }

                // GET: api/People/hans.muster@email.com
        [HttpGet]
        [Route("api/people/{id}")]
        public async Task<ActionResult<Person>> GetPerson(int id)
        {
            var person = await _context.People.FindAsync(id);

            if (person == null)
            {
                return NotFound();
            }
           
            return person;
        }

       
        // POST: api/People
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        [Route("api/people")]
        public async Task<ActionResult<Person>> PostPerson(Person person)
        {
            _context.People.Add(person);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPerson", new { id = person.Id }, person);
        }
    }
}
