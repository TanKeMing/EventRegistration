using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EventRegistration.Server.Data;
using EventRegistration.Shared.Domain;
using EventRegistration.Server.IRepository;

namespace EventRegistration.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VenuesController : ControllerBase
    {   //refractored
        //private readonly ApplicationDbContext _context;
        private readonly IUnitOfWork _unitOfWork;
        //refractored
        //public VenuesController(ApplicationDbContext context)
        public VenuesController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            //_context = context;
        }

        // GET: api/Venues
        [HttpGet]
        //refractored
        //public async Task<ActionResult<IEnumerable<Venue>>> GetVenues()
        public async Task<IActionResult> GetVenues()
        {
            //Refractored
            //return await _context.Venues.ToListAsync();
            var venues = await _unitOfWork.Venues.GetAll();
            return Ok(venues);
        }

        // GET: api/Venues/5
        [HttpGet("{id}")]
        //Refractored
        //public async Task<ActionResult<Venue>> GetVenue(int id)
        public async Task<IActionResult> GetVenue(int id)
        {
            //var venue = await _context.Venues.FindAsync(id);
            var venue = await _unitOfWork.Venues.Get(q => q.Venueid == id);

            if (venue == null)
            {
                return NotFound();
            }

            return Ok(venue);
        }

        // PUT: api/Venues/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutVenue(int id, Venue venue)
        {
            if (id != venue.Venueid)
            {
                return BadRequest();
            }

            //_context.Entry(venue).State = EntityState.Modified;
            _unitOfWork.Venues.Update(venue);

            try
            {
                //await _context.SaveChangesAsync();
                await _unitOfWork.Save(HttpContext);
            }
            catch (DbUpdateConcurrencyException)
            {
                //if (!VenueExists(id))
                if(!await VenueExists(id))
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

        // POST: api/Venues
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Venue>> PostVenue(Venue venue)
        {
            //_context.Venues.Add(venue);
            //await _context.SaveChangesAsync();
             await _unitOfWork.Venues.Insert(venue);
            await _unitOfWork.Save(HttpContext);


            return CreatedAtAction("GetVenue", new { id = venue.Venueid }, venue);
        }

        // DELETE: api/Venues/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVenue(int id)
        {
            //var venue = await _context.Venues.FindAsync(id);
            var venue = await _unitOfWork.Venues.Get(q => q.Venueid == id);
            if (venue == null)
            {
                return NotFound();
            }

            //_context.Venues.Remove(venue);
            //await _context.SaveChangesAsync();
            await _unitOfWork.Venues.Delete(id);
            await _unitOfWork.Save(HttpContext);

            return NoContent();
        }

        //private bool VenueExists(int id)
        private async Task<bool> VenueExists(int id)
        {
            //return _context.Venues.Any(e => e.Venueid == id);
            var venue = _unitOfWork.Venues.Get(q => q.Venueid == id);
            return venue != null;
        }
    }
}
