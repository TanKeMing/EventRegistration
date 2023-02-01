using EventRegistration.Shared.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventRegistration.Server.Configuration.Entities
{
    public class Staffseedconfiguration : IEntityTypeConfiguration<Staff>
    {
        public void Configure(EntityTypeBuilder<Staff> builder)
        {
            builder.HasData(
                   new Staff
                   {
                       Staffid = 1,
                       Staffemail = "kolan@gmail.com",
                       Staffcontactnumber = "89422042",
                       Staffgender = "female"
                   },
                     new Staff
                     {
                         Staffid = 2,
                         Staffemail = "sam@gmail.com",
                         Staffcontactnumber = "99427042",
                         Staffgender = "male"
                     });

        }
    }
}
