using DataBaseAssigmentConsoleApp.Models;
using DataBaseAssigmentConsoleApp.Repositories;
using System.Diagnostics.Metrics;
using System.Numerics;

namespace DataBaseAssigmentConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            ICustomerRepository repository = new CustomerRepository();
            //PrintCustomer(repository.GetCustomerByName("Astrid", "Gruber"));
            //Customer customer = repository.GetCustomerById(8);
            //Customer UpdatedCustomer = new()
            //{
            //    CustomerId = customer.CustomerId,
            //    FirstName = "NEW CUSTOMER FIRST NAME",
            //    LastName = "NEW GENERIC LAST NAME",
            //    Country = "North-Korea",
            //    PostalCode = "0880",
            //    Phone = "69",
            //    Email = "NEW_EMAIL@gmail.com"
            //};
            //repository.UpdateCustomer(UpdatedCustomer);
            //TestSelect(repository);
            GetAllCustomerCountires(repository);
            


        }

        static void GetAllCustomerCountires(ICustomerRepository repository)
        {
            repository.GetCountriesFromCustomers().ForEach(x => Console.WriteLine(x.ToString()));
        }

        static void TestSelectAll(ICustomerRepository repository)
        {
            PrintCustomer(repository.GetAllCustomers());
        }

        static void TestSelect(ICustomerRepository repository)
        {
            PrintCustomer(repository.GetCustomerById(8));
        }

        static void TestInsert(ICustomerRepository repository)
        {
            Customer test = new Customer()
            {
                CustomerId = 12,
                FirstName = "Some_Shitty_Name",
                LastName = "HalloTarzan",
                Country = "North-Korea",
                PostalCode = "12345",
                Phone = "1234567890",
                Email = "MyEmail"
            };
            if (repository.AddNewCustomer(test))
            {
                Console.WriteLine("Suuu");
            }
            else
            {
                Console.WriteLine("fuck");
            }
        }
        static void PrintCustomer(IEnumerable<Customer> customers)
        {
            foreach (Customer customer in customers)
            {
                PrintCustomer(customer);
            }
        }

        static void PrintCustomer(Customer customer)
        {
            Console.WriteLine($"--- ID: {customer.CustomerId} " +
                $" First name: {customer.FirstName} " +
                $" Last name: {customer.LastName} " +
                $" Country: {customer.Country} " +
                $" Postal code: {customer.PostalCode}" +
                $" Phone number: {customer.Phone} " +
                $" Email: {customer.Email} ---" );
        }
    }
}