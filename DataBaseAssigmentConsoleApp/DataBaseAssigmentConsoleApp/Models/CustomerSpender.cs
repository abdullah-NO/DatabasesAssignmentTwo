using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBaseAssigmentConsoleApp.Models
{

       //public int CustomerId { get; set; }
       //public double TotalSpendingAmount { get; set; }
       public readonly record struct CustomerSpending(int CustomerId, decimal TotalAmountSpent);
        //internal readonly record struct Customer(int CustomerId, string FirstName, string LastName, string Country, string Phone, string PostalCode, string Email);

    
}
