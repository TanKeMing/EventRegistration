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
    public class RegistrationsController : ControllerBase
    {   //refractored
        //private readonly ApplicationDbContext _context;
        private readonly IUnitOfWork _unitOfWork;
        //refractored
        //public RegistrationsController(ApplicationDbContext context)
        public RegistrationsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            //_context = context;
        }

        // GET: api/Registrations
        [HttpGet]
        //refractored
        //public async Task<ActionResult<IEnumerable<Registration>>> GetRegistrations()
        public async Task<IActionResult> GetRegistrations()
        {
            //Refractored
            //return await _context.Registrations.ToListAsync();
            var registrations = await _unitOfWork.Registrations.GetAll();
            return Ok(registrations);
        }

        // GET: api/Registrations/5
        [HttpGet("{id}")]
        //Refractored
        //public async Task<ActionResult<Registration>> GetRegistration(int id)
        public async Task<IActionResult> GetRegistration(int id)
        {
            //var registration = await _context.Registrations.FindAsync(id);
            var registration = await _unitOfWork.Registrations.Get(q => q.Id == id);

            if (registration == null)
            {
                return NotFound();
            }

            return Ok(registration);
        }

        // PUT: api/Registrations/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRegistration(int id, Registration registration)
        {
            if (id != registration.Id)
            {
                return BadRequest();
            }

            //_context.Entry(registration).State = EntityState.Modified;
            _unitOfWork.Registrations.Update(registration);

            try
            {
                //await _context.SaveChangesAsync();
                await _unitOfWork.Save(HttpContext);
            }
            catch (DbUpdateConcurrencyException)
            {
                //if (!RegistrationExists(id))
                if(!await RegistrationExists(id))
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

        // POST: api/Registrations
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Registration>> PostRegistration(Registration registration)
        {
            //_context.Registrations.Add(registration);
            //await _context.SaveChangesAsync();
             await _unitOfWork.Registrations.Insert(registration);
            await _unitOfWork.Save(HttpContext);


            return CreatedAtAction("GetRegistration", new { id = registration.Id }, registration);
        }

        // DELETE: api/Registrations/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRegistration(int id)
        {
            //var registration = await _context.Registrations.FindAsync(id);
            var registration = await _unitOfWork.Registrations.Get(q => q.Id == id);
            if (registration == null)
            {
                return NotFound();
            }

            //_context.Registrations.Remove(registration);
            //await _context.SaveChangesAsync();
            await _unitOfWork.Registrations.Delete(id);
            await _unitOfWork.Save(HttpContext);

            return NoContent();
        }

        //private bool RegistrationExists(int id)
        private async Task<bool> RegistrationExists (int id)
        {
            //return _context.Registrations.Any(e => e.Registrationid == id);
            var registration = _unitOfWork.Registrations.Get(q => q.Id == id);
            return registration != null;
        }
    }
}
