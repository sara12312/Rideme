using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Rideme.Models;

namespace Rideme.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RidesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public RidesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Rides
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Ride>>> GetRides()
        {
          if (_context.Rides == null)
          {
              return NotFound();
          }
            return await _context.Rides.ToListAsync();
        }

        // GET: api/Rides/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Ride>> GetRide(int id)
        {
          if (_context.Rides == null)
          {
              return NotFound();
          }
            var ride = await _context.Rides.FindAsync(id);

            if (ride == null)
            {
                return NotFound();
            }

            return ride;
        }

        // PUT: api/Rides/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRide(int id, Ride ride)
        {
            if (id != ride.RideId)
            {
                return BadRequest();
            }

            _context.Entry(ride).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RideExists(id))
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

        // POST: api/Rides
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Ride>> PostRide(Ride ride)
        {
          if (_context.Rides == null)
          {
              return Problem("Entity set 'ApplicationDbContext.Rides'  is null.");
          }
            _context.Rides.Add(ride);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetRide", new { id = ride.RideId }, ride);
        }

        // DELETE: api/Rides/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRide(int id)
        {
            if (_context.Rides == null)
            {
                return NotFound();
            }
            var ride = await _context.Rides.FindAsync(id);
            if (ride == null)
            {
                return NotFound();
            }

            _context.Rides.Remove(ride);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool RideExists(int id)
        {
            return (_context.Rides?.Any(e => e.RideId == id)).GetValueOrDefault();
        }
    }
}
