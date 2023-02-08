using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventRegistration.Shared.Domain
{
    public class Customer :BaseDomainModel
    {
        [Required]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "Customer does not meet length requirements")]
        public string Customername { get; set; }
        public string Customeraddress { get; set; }
        [Required]
        [DataType(DataType.EmailAddress, ErrorMessage = "Email Address is not a valid email")]
        [EmailAddress]
        public string Customeremail { get; set; }
        [Required]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"(6|8|9)\d{7}", ErrorMessage = "Contact Number is not a valid phone number")]
        public string Customernumber { get; set; }
        public virtual List<Registration> Registrations { get; set; }

    }
}
