using DataBaseAssigmentConsoleApp.Models;
using DataBaseAssigmentConsoleApp.Repositories;

namespace DataBaseAssigmentConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
        }

        static void TestSelectAll(ICustomerRepository repository)
        {
            PrintCustomer(repository.GetAllCustomers());
        }

        static void TestSelect(ICustomerRepository repository)
        {
            PrintCustomer(repository.GetCustomer("SomeId"));
        }

        static void TestInsert(ICustomerRepository repository)
        {
            Customer test = new Customer()
            {
                CustomerId = "Some_string",
                FirstName = "Some_Shitty_Name",
                LastName = "HalloTarzan",
                Country = "North-Korea",
                PostalCode = "Kim Jong Uns adress",
                PhoneNumber = "1234567890",
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
            Console.WriteLine($"--- {customer.CustomerId}" +
                $" {customer.FirstName} " +
                $"{customer.LastName} " +
                $"{customer.Country} " +
                $"{customer.PostalCode}" +
                $" {customer.PhoneNumber} " +
                $"{customer.Email} ---" );
        }


    }

}