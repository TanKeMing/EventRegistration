using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventRegistration.Client.Static
{
    public static class Endpoints
    {
        private static readonly string Prefix = "api";
        public static readonly string VenuesEndpoint = $"{Prefix}/venues";
        public static readonly string CustomersEndpoint = $"{Prefix}/customers";
        public static readonly string EventsEndpoint = $"{Prefix}/events";
        public static readonly string StaffsEndpoint = $"{Prefix}/staffs";
        public static readonly string RegistrationsEndpoint = $"{Prefix}/registrations";
        public static readonly string PaymentsEndpoint = $"{Prefix}/payments";
        public static readonly string CategorysEndpoint = $"{Prefix}/categorys";
    }
}
