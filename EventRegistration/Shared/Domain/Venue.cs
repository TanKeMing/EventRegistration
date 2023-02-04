using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventRegistration.Shared.Domain
{
    public class Venue :BaseDomainModel
    {
        
       public string Venuename { get; set; }
        public string Venueaddress { get; set; }
        public string Venuedescription { get; set; }
        public virtual List <Event> Events { get; set; }
    }
}
