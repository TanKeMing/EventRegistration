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
    public class CategorysController : ControllerBase
    {   //refractored
        //private readonly ApplicationDbContext _context;
        private readonly IUnitOfWork _unitOfWork;
        //refractored
        //public CategorysController(ApplicationDbContext context)
        public CategorysController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            //_context = context;
        }

        // GET: api/Categorys
        [HttpGet]
        //refractored
        //public async Task<ActionResult<IEnumerable<Category>>> GetCategorys()
        public async Task<IActionResult> GetCategorys()
        {
            //Refractored
            //return await _context.Categorys.ToListAsync();
            var categorys = await _unitOfWork.Categorys.GetAll();
            return Ok(categorys);
        }

        // GET: api/Categorys/5
        [HttpGet("{id}")]
        //Refractored
        //public async Task<ActionResult<Category>> GetCategory(int id)
        public async Task<IActionResult> GetCategory(int id)
        {
            //var category = await _context.Categorys.FindAsync(id);
            var category = await _unitOfWork.Categorys.Get(q => q.Id == id);

            if (category == null)
            {
                return NotFound();
            }

            return Ok(category);
        }

        // PUT: api/Categorys/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCategory(int id, Category category)
        {
            if (id != category.Id)
            {
                return BadRequest();
            }

            //_context.Entry(category).State = EntityState.Modified;
            _unitOfWork.Categorys.Update(category);

            try
            {
                //await _context.SaveChangesAsync();
                await _unitOfWork.Save(HttpContext);
            }
            catch (DbUpdateConcurrencyException)
            {
                //if (!CategoryExists(id))
                if(!await CategoryExists(id))
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

        // POST: api/Categorys
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Category>> PostCategory(Category category)
        {
            //_context.Categorys.Add(category);
            //await _context.SaveChangesAsync();
             await _unitOfWork.Categorys.Insert(category);
            await _unitOfWork.Save(HttpContext);


            return CreatedAtAction("GetCategory", new { id = category.Id }, category);
        }

        // DELETE: api/Categorys/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            //var category = await _context.Categorys.FindAsync(id);
            var category = await _unitOfWork.Categorys.Get(q => q.Id == id);
            if (category == null)
            {
                return NotFound();
            }

            //_context.Categorys.Remove(category);
            //await _context.SaveChangesAsync();
            await _unitOfWork.Categorys.Delete(id);
            await _unitOfWork.Save(HttpContext);

            return NoContent();
        }

        //private bool CategoryExists(int id)
        private async Task<bool> CategoryExists (int id)
        {
            //return _context.Categorys.Any(e => e.Categoryid == id);
            var category = _unitOfWork.Categorys.Get(q => q.Id == id);
            return category != null;
        }
    }
}
