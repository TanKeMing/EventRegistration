using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace EventRegistration.Shared.Domain
{
    public class Staff :BaseDomainModel
    { 
        public string Staffemail { get; set;  }
        public string Staffcontactnumber { get; set; }
        public string Staffgender { get; set; }

    }
}
