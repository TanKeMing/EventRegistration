using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventRegistration.Shared.Domain
{
    public class Venue :BaseDomainModel
    {
        [Required]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "Venue does not meet length requirements")]
        public string Venuename { get; set; }
        [Required]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "Venueaddress does not meet length requirements")]
        public string Venueaddress { get; set; }
        [Required]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "Venuedescription does not meet length requirements")]
        public string Venuedescription { get; set; }
        public virtual List <Event> Events { get; set; }
    }
}
