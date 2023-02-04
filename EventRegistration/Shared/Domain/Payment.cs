using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventRegistration.Shared.Domain
{
    public class Payment :BaseDomainModel
    {
       
        public string Paymenttype { get; set; }
        public string Totalpayment { get; set; }
        public int Registrationid { get; set; }
        public virtual Registration Registration { get; set; }

    }
}
