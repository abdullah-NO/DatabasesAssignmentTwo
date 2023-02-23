using DataBaseAssigmentConsoleApp.Models;
using DataBaseAssigmentConsoleApp.Repositories;

namespace DataBaseAssigmentConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            ICustomerRepository repository = new CustomerRepository();
           // TestSelectAll(repository);
            PrintCustomer(repository.GetCustomerByName("Astrid", "Gruber"));
        }

        static void TestSelectAll(ICustomerRepository repository)
        {
            PrintCustomer(repository.GetAllCustomers());
        }

        static void TestSelect(ICustomerRepository repository)
        {
            PrintCustomer(repository.GetCustomerById(6));
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