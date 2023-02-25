using DataBaseAssigmentConsoleApp.Models;
using DataBaseAssigmentConsoleApp.Repositories;
using System.Diagnostics.Metrics;
using System.Numerics;

namespace DataBaseAssigmentConsoleApp
{
    internal class Program
    {
        /// <summary>
        /// The code can be executed from the Main method. Every method is (in theory) set up correctly according to the programs
        /// structure. To test them, just comment out one at the time (can also run everything at once but it becomes a bit chaotic).
        /// Feel free to play with different parameters. There are some natural
        /// limitations, for example do not attempt a crazy long LastName. This might lead to an error.
        /// </summary>
        static void Main(string[] args)
        {
            ICustomerRepository repository = new CustomerRepository();
            //Task 1

            //SelectAll(repository);

            //Task 2

            //Select(repository, 8);

            //Task 3

            //ReadCustomerByName(repository, "Dan", "Mill");

            //Task 4

            //GetPage(repository);

            //Task 5

            //AddCustomer(repository);

            //Task 6

            //UpdateCustomer(repository);

            //Task 7

            //DescendingCountries(repository);

            //Task 8

            //HighestSpenders(repository);

            //Task 9

            //GetFavoriteGenreById(repository, 9);
        }

       /// <summary>
       /// this functions displays all customers from the database
       /// </summary>
       /// <param name="repository"></param>
        static void SelectAll(ICustomerRepository repository)
        {
            PrintCustomer(repository.GetAllCustomers());
        }

        /// <summary>
        /// this function displays a single customer that is selected by id
        /// </summary>
        /// <param name="repository"></param>
        /// <param name="id"></param>
        static void Select(ICustomerRepository repository, int id)
        {
            PrintCustomer(repository.GetCustomerById(id));
        }

        /// <summary>
        /// this function displays a list a selected range of customers based on the customer id
        /// </summary>
        /// <param name="repository"></param>
        static void GetPage(ICustomerRepository repository)
        {
            PrintCustomer(repository.GetPageOfCustomers(1, 10));
        }

        /// <summary>
        /// this function displays a single customer that is selected by name
        /// </summary>
        /// <param name="repository"></param>
        /// <param name="FirstName"></param>
        /// <param name="LastName"></param>
        static void ReadCustomerByName(ICustomerRepository repository, string FirstName, string LastName)
        {
            PrintCustomer(repository.GetCustomerByName(FirstName, LastName));
        }
        
        /// <summary>
        /// this function adds a customer to the customer table in the database
        /// </summary>
        /// <param name="repository"></param>
        static void AddCustomer(ICustomerRepository repository)
        {
            Customer newCustomer = new()
            {
                FirstName = "Thomas",
                LastName = "Langballe",
                Country = "Afghanistan",
                PostalCode = "42069",
                Phone = "80085",
                Email = "idiotmail@gmail.com"
            };
            repository.AddNewCustomer(newCustomer);
            PrintCustomer(repository.GetCustomerByName(newCustomer.FirstName, newCustomer.LastName));

        }
        /// <summary>
        /// this function updates an existing single customer   
        /// </summary>
        /// <param name="repository"></param>
        static void UpdateCustomer(ICustomerRepository repository)
        {
            Customer updatedCustomer = new()
            {
                CustomerId = 12,
                FirstName = "SpiderMan",
                LastName = "Womanizer",
                Country = "Memeistan",
                PostalCode = "42069",
                Phone = "80085",
                Email = "SPiderman@gmail.com"
            };
            repository.UpdateCustomer(updatedCustomer);
            PrintCustomer(repository.GetCustomerByName(updatedCustomer.FirstName, updatedCustomer.LastName));

        }

        /// <summary>
        /// prints a list of customers
        /// </summary>
        /// <param name="customers"></param>
        static void PrintCustomer(IEnumerable<Customer> customers)
        {
            foreach (Customer customer in customers)
            {
                PrintCustomer(customer);
            }
        }


        /// <summary>
        /// this function prints 
        /// </summary>
        /// <param name="repository"></param>
        static void DescendingCountries(ICustomerRepository repository)
        {
            repository.GetCountriesFromCustomers().ForEach(x => Console.WriteLine(x.ToString()));
        }

        public static void GetFavoriteGenreById(ICustomerRepository repository, int Id)
        {
            Console.WriteLine($"Customer {repository.GetCustomerById(Id).FirstName} {repository.GetCustomerById(Id).LastName} most played genres are the following:");
            repository.GetFavoriteGenreCustomer(Id).ForEach(x => Console.WriteLine(x.ToString()));
        }
        static void HighestSpenders(ICustomerRepository repository)
        {
            repository.GetCustomerSpenders().ForEach(x => Console.WriteLine(x.ToString()));
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