using EventRegistration.Shared.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventRegistration.Server.Configuration.Entities
{
    public class Venueseedconfiguration : IEntityTypeConfiguration<Venue>
    {
        public void Configure(EntityTypeBuilder<Venue> builder)
        {
            builder.HasData(
                new Venue
                {
                    Id = 1,
                    Venuename = "Expo",
                    Venueaddress = " Changi",
                    Venuedescription = "Tech show"
                },
                 new Venue
                 {
                     Id = 2,
                     Venuename = "Tampines Hall",
                     Venueaddress = "Tampines Heartbeat",
                     Venuedescription = "Food show"
                 }
                 );


        }
    }
}
