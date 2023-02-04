using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventRegistration.Shared.Domain
{
    public class Registration :BaseDomainModel
    {
        public string location { get; set; }
        public int Customerid { get; set; }
        public virtual Customer Customer { get; set; }
        public virtual List<Payment> Payments { get; set; }

    }
}