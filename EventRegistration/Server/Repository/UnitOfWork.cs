using EventRegistration.Server.Data;
using EventRegistration.Server.IRepository;
using EventRegistration.Server.Models;
using EventRegistration.Shared.Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace EventRegistration.Server.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;
        private IGenericRepository<Category> _categorys;
        private IGenericRepository<Customer> _customers;
        private IGenericRepository<Event> _events;
        private IGenericRepository<Payment> _payments;
        private IGenericRepository<Registration> _registrations;
        private IGenericRepository<Staff> _staffs;
        private IGenericRepository<Venue> _venues;

        private UserManager<ApplicationUser> _userManager;

        public UnitOfWork(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public IGenericRepository<Category> Categorys
            => _categorys ??= new GenericRepository<Category>(_context);
        public IGenericRepository<Customer> Customers
            => _customers ??= new GenericRepository<Customer>(_context);
        public IGenericRepository<Event> Events
            => _events ??= new GenericRepository<Event>(_context);
        public IGenericRepository<Payment> Payments
            => _payments ??= new GenericRepository<Payment>(_context);
        public IGenericRepository<Registration> Registrations
            => _registrations ??= new GenericRepository<Registration>(_context);
        public IGenericRepository<Staff> Staffs
            => _staffs ??= new GenericRepository<Staff>(_context);
        public IGenericRepository<Venue> Venues
            => _venues ??= new GenericRepository<Venue>(_context);

        public void Dispose()
        {
            _context.Dispose();
            GC.SuppressFinalize(this);
        }

        public async Task Save(HttpContext httpContext)
        {
            //To be implemented
            string user = "System";

            var entries = _context.ChangeTracker.Entries()
                .Where(q => q.State == EntityState.Modified ||
                    q.State == EntityState.Added);

            foreach (var entry in entries)
            {
                ((Payment)entry.Entity).PaymentdateUpdated = DateTime.Now;
                ((Payment)entry.Entity).PaymentUpdatedby = user;
                if (entry.State == EntityState.Added)
                {
                    ((Payment)entry.Entity).PaymentdateCreated = DateTime.Now;
                    ((Payment)entry.Entity).PaymentUpdatedby = user;
                }
            }
            foreach (var entry in entries)
            {
                ((Registration)entry.Entity).DateUpdated = DateTime.Now;
                ((Registration)entry.Entity).Updatedby = user;
                if (entry.State == EntityState.Added)
                {
                    ((Registration)entry.Entity).DateCreated = DateTime.Now;
                    ((Registration)entry.Entity).CreatedBy = user;
                }
            }

            await _context.SaveChangesAsync();
        }
    }
}
