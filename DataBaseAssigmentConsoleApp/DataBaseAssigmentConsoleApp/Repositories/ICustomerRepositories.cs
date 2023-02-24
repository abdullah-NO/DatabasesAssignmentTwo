using DataBaseAssigmentConsoleApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBaseAssigmentConsoleApp.Repositories
{
    public interface ICustomerRepository
    {
        public Customer GetCustomerById(int id);
        public List<Customer> GetAllCustomers();
        public Customer GetCustomerByName(string Firstname, string LastName);
        public List <Customer> GetPageOfCustomers(int offset, int limit);
        public bool AddNewCustomer(Customer customer);
        public bool UpdateCustomer(Customer customer);
        public bool DeleteCustomer(string id);
        public List <CustomerCountries> GetCountriesFromCustomers();
        public List<CustomerSpending> GetCustomerSpenders();
    }
}

