using EventRegistration.Shared.Domain;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventRegistration.Server.IRepository
{
    public interface IUnitOfWork : IDisposable
    {
        Task Save(HttpContext httpContext);
        IGenericRepository<Category> Categorys { get; }
        IGenericRepository<Customer> Customers { get; }
        IGenericRepository<Event> Events { get; }
        IGenericRepository<Payment> Payments { get; }
        IGenericRepository<Registration> Registrations { get; }
        IGenericRepository<Staff> Staffs { get; }
        IGenericRepository<Venue> Venues { get; }
    }
}
