using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace EventRegistration.Shared.Domain
{
    public class Staff :BaseDomainModel
    {
        [Required]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "StaffName does not meet length requirements")]
        public string Staffname { get; set; }
        [Required]
        [DataType(DataType.EmailAddress, ErrorMessage = "Email Address is not a valid email")]
        [EmailAddress]
        public string Staffemail { get; set;  }
        [Required]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"(6|8|9)\d{7}", ErrorMessage = "Contact Number is not a valid phone number")]
        public string Staffcontactnumber { get; set; }
        [Required]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "StaffGender does not meet length requirements")]
        public string Staffgender { get; set; }

    }
}
