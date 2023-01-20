using System;

namespace EventRegistration.Shared.Domain
{
    public class Event
    {
        public string EventName { get; set; }
        public string EventDescription { get; set; }
        public string EventVenue { get; set; }
        public DateTime EventdateCreated { get; set; }

        public DateTime EventdateUpdated { get; set; }

        public string EventCreatedBy { get; set; }

        public string EventUpdatedby { get; set; }
        public int Venueid { get; set; }
        public virtual Venue Venue { get; set; }

    }
}