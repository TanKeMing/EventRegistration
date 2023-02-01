﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventRegistration.Shared.Domain
{
    public class Registration
    {
        public int id { get; set; }
        public DateTime DateCreated { get; set; }

        public DateTime DateUpdated { get; set; }

        public string CreatedBy { get; set; }

        public string Updatedby { get; set; }
        public string location { get; set; }
        public int Customerid { get; set; }
        public virtual Customer Customer { get; set; }
        public virtual List<Payment> Payments { get; set; }

    }
}