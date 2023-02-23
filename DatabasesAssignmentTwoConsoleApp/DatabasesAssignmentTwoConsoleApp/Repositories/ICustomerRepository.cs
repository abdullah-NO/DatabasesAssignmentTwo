using DatabasesAssignmentTwoConsoleApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabasesAssignmentTwoConsoleApp.Repositories
{
    public interface ICustomerRepository
    {
        public Customer GetCustomer(string id);
        public List<Customer> GetAllCustomers();
        public bool AddCustomer(Customer customer);
        public bool UpdateCustomer(Customer customer);
        public bool DeleteCustomer(string id);


    }
}
