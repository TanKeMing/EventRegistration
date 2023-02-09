using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventRegistration.Shared.Domain
{
    public class Registration :BaseDomainModel
    {
        public string Registrationname { get; set; }
        public DateTime Datein { get; set; }
        public DateTime Dateout { get; set; }
        public string Registrationtime { get; set; }
        public string location { get; set; }
        public int Customerid { get; set; }
        public virtual Customer Customer { get; set; }
        public virtual List<Payment> Payments { get; set; }

    }
}