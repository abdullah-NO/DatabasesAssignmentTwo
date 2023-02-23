using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBaseAssigmentConsoleApp.Models
{
        public class Customer
        {
            public string CustomerId { get; set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public string Country { get; set; }
            public string PhoneNumber { get; set; }
            public string PostalCode { get; set; }

            public string Email { get; set; }

        }
}
