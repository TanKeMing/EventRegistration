using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventRegistration.Shared.Domain
{
    public class Customer :BaseDomainModel
    {
        public string Customername { get; set; }
        public string Customeraddress { get; set; }
        public string Customeremail { get; set; }
        public string Customernumber { get; set; }
        public virtual List<Registration> Registrations { get; set; }

    }
}
