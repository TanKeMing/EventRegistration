﻿using System;
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
    public class PaymentsController : ControllerBase
    {   //refractored
        //private readonly ApplicationDbContext _context;
        private readonly IUnitOfWork _unitOfWork;
        //refractored
        //public PaymentsController(ApplicationDbContext context)
        public PaymentsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            //_context = context;
        }

        // GET: api/Payments
        [HttpGet]
        //refractored
        //public async Task<ActionResult<IEnumerable<Payment>>> GetPayments()
        public async Task<IActionResult> GetPayments()
        {
            //Refractored
            //return await _context.Payments.ToListAsync();
            var payments = await _unitOfWork.Payments.GetAll();
            return Ok(payments);
        }

        // GET: api/Payments/5
        [HttpGet("{id}")]
        //Refractored
        //public async Task<ActionResult<Payment>> GetPayment(int id)
        public async Task<IActionResult> GetPayment(int id)
        {
            //var payment = await _context.Payments.FindAsync(id);
            var payment = await _unitOfWork.Payments.Get(q => q.Id == id);

            if (payment == null)
            {
                return NotFound();
            }

            return Ok(payment);
        }

        // PUT: api/Payments/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPayment(int id, Payment payment)
        {
            if (id != payment.Id)
            {
                return BadRequest();
            }

            //_context.Entry(payment).State = EntityState.Modified;
            _unitOfWork.Payments.Update(payment);

            try
            {
                //await _context.SaveChangesAsync();
                await _unitOfWork.Save(HttpContext);
            }
            catch (DbUpdateConcurrencyException)
            {
                //if (!PaymentExists(id))
                if(!await PaymentExists(id))
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

        // POST: api/Payments
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Payment>> PostPayment(Payment payment)
        {
            //_context.Payments.Add(payment);
            //await _context.SaveChangesAsync();
             await _unitOfWork.Payments.Insert(payment);
            await _unitOfWork.Save(HttpContext);


            return CreatedAtAction("GetPayment", new { id = payment.Id }, payment);
        }

        // DELETE: api/Payments/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePayment(int id)
        {
            //var payment = await _context.Payments.FindAsync(id);
            var payment = await _unitOfWork.Payments.Get(q => q.Id == id);
            if (payment == null)
            {
                return NotFound();
            }

            //_context.Payments.Remove(payment);
            //await _context.SaveChangesAsync();
            await _unitOfWork.Payments.Delete(id);
            await _unitOfWork.Save(HttpContext);

            return NoContent();
        }

        //private bool PaymentExists(int id)
        private async Task<bool> PaymentExists (int id)
        {
            //return _context.Payments.Any(e => e.Paymentid == id);
            var payment = _unitOfWork.Payments.Get(q => q.Id == id);
            return payment != null;
        }
    }
}
