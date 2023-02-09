using System;
using System.ComponentModel.DataAnnotations;

namespace EventRegistration.Shared.Domain
{
    public class Event :BaseDomainModel
    {
        [Required]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "EventName does not meet length requirements")]
        public string EventName { get; set; }
        [Required]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "EventDescription does not meet length requirements")]
        public string EventDescription { get; set; }
        [Required]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "EventVenue does not meet length requirements")]
        public string EventVenue { get; set; }
        public string Eventtime { get; set; }
        public DateTime Eventdateout { get; set; }

        public DateTime Eventdatein { get; set; }

        public int Venueid { get; set; }
        public virtual Venue Venue { get; set; }

    }
}