using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventRegistration.Shared.Domain
{
    public class Payment
    {
        public DateTime PaymentdateCreated { get; set; }

        public DateTime PaymentdateUpdated { get; set; }

        public string PaymentCreatedBy { get; set; }

        public string PaymentUpdatedby { get; set; }
        public string Paymenttype { get; set; }
        public string Totalpayment { get; set; }
        public int Registrationid { get; set; }
        public virtual Registration Registration { get; set; }

    }
}
