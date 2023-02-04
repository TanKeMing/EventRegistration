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
    public class EventsController : ControllerBase
    {   //refractored
        //private readonly ApplicationDbContext _context;
        private readonly IUnitOfWork _unitOfWork;
        //refractored
        //public EventsController(ApplicationDbContext context)
        public EventsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            //_context = context;
        }

        // GET: api/Events
        [HttpGet]
        //refractored
        //public async Task<ActionResult<IEnumerable<Event>>> GetEvents()
        public async Task<IActionResult> GetEvents()
        {
            //Refractored
            //return await _context.Events.ToListAsync();
            var eventss = await _unitOfWork.Events.GetAll();
            return Ok(eventss);
        }

        // GET: api/Events/5
        [HttpGet("{id}")]
        //Refractored
        //public async Task<ActionResult<Event>> GetEvent(int id)
        public async Task<IActionResult> GetEvent(int id)
        {
            //var events = await _context.Events.FindAsync(id);
            var events = await _unitOfWork.Events.Get(q => q.Id == id);

            if (events == null)
            {
                return NotFound();
            }

            return Ok(events);
        }

        // PUT: api/Events/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEvent(int id, Event events)
        {
            if (id != events.Id)
            {
                return BadRequest();
            }

            //_context.Entry(events).State = EntityState.Modified;
            _unitOfWork.Events.Update(events);

            try
            {
                //await _context.SaveChangesAsync();
                await _unitOfWork.Save(HttpContext);
            }
            catch (DbUpdateConcurrencyException)
            {
                //if (!EventExists(id))
                if(!await EventExists(id))
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

        // POST: api/Events
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Event>> PostEvent(Event events)
        {
            //_context.Events.Add(events);
            //await _context.SaveChangesAsync();
             await _unitOfWork.Events.Insert(events);
            await _unitOfWork.Save(HttpContext);


            return CreatedAtAction("GetEvent", new { id = events.Id }, events);
        }

        // DELETE: api/Events/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEvent(int id)
        {
            //var events = await _context.Events.FindAsync(id);
            var events = await _unitOfWork.Events.Get(q => q.Id == id);
            if (events == null)
            {
                return NotFound();
            }

            //_context.Events.Remove(events);
            //await _context.SaveChangesAsync();
            await _unitOfWork.Events.Delete(id);
            await _unitOfWork.Save(HttpContext);

            return NoContent();
        }

        //private bool EventExists(int id)
        private async Task<bool> EventExists (int id)
        {
            //return _context.Events.Any(e => e.Eventid == id);
            var events = _unitOfWork.Events.Get(q => q.Id == id);
            return events != null;
        }
    }
}
