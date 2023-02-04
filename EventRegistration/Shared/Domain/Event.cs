using System;

namespace EventRegistration.Shared.Domain
{
    public class Event :BaseDomainModel
    {
        public string EventName { get; set; }
        public string EventDescription { get; set; }
        public string EventVenue { get; set; }

        public int Venueid { get; set; }
        public virtual Venue Venue { get; set; }

    }
}