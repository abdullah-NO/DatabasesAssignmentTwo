﻿using DataBaseAssigmentConsoleApp.Models;
using Microsoft.Data.SqlClient;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBaseAssigmentConsoleApp.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        public List<Customer> GetAllCustomers()
        {
            List<Customer> CustomerList = new List<Customer>();
            string sql = "SELECT CustomerId, FirstName, LastName, Country, PostalCode, Phone, Email FROM Chinook.dbo.Customer;";
            try
            {
                //Connect
                using (SqlConnection conn = new SqlConnection(ConnectionHelper.GetConnectionString()))
                {
                    conn.Open();
                    //Make a command
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                //Handle result
                                Customer temp = new Customer();
                                temp.CustomerId = reader.GetInt32(0);
                                temp.FirstName = reader.GetString(1);
                                temp.LastName = reader.GetString(2);
                                temp.Country = reader.GetString(3);
                                if (!reader.IsDBNull(reader.GetOrdinal("PostalCode")))
                                    temp.PostalCode = reader.GetString(4);
                                if (!reader.IsDBNull(reader.GetOrdinal("Phone")))
                                    temp.Phone = reader.GetString(5);
                                temp.Email = reader.GetString(6);
                                CustomerList.Add(temp);
                            }
                        }
                    }
                    // Reader   
                }

            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
                //Log the fucking error
            }
            return CustomerList;
            throw new NotImplementedException();
        }

        public Customer GetCustomerById(int id)
        {
            string sql = "SELECT CustomerId, FirstName, LastName, Country, PostalCode, Phone, Email FROM Chinook.dbo.Customer WHERE CustomerId = @CustomerId;";
            Customer customer = new Customer();

            try
            {
                //Connect
                using SqlConnection conn = new SqlConnection((ConnectionHelper.GetConnectionString()));
                conn.Open();
                using SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@CustomerId", id);
                using SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    Customer temp = new Customer();
                    temp.CustomerId = reader.GetInt32(0);
                    temp.FirstName = reader.GetString(1);
                    temp.LastName = reader.GetString(2);
                    temp.Country = reader.GetString(3);
                    if (!reader.IsDBNull(reader.GetOrdinal("PostalCode")))
                        temp.PostalCode = reader.GetString(4);
                    if (!reader.IsDBNull(reader.GetOrdinal("Phone")))
                        temp.Phone = reader.GetString(5);
                    temp.Email = reader.GetString(6);
                    customer = temp;

                }
                else
                {
                    throw new Exception("Some annoying mistake in database or some shit");
                }
                // Reader   


            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
                //Log the fucking error
            }
            return customer;



        }
        public Customer GetCustomerByName(string FirstName, string LastName)
        {
            string sql = "SELECT CustomerId, FirstName, LastName, Country, PostalCode, Phone, Email FROM Chinook.dbo.Customer WHERE FirstName LIKE '%' + @FirstName + '%' OR LastName LIKE '%' + @LastName + '%';";
            Customer customer = new Customer();

            try
            {
                //Connect
                using SqlConnection conn = new SqlConnection((ConnectionHelper.GetConnectionString()));
                conn.Open();
                using SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@FirstName", FirstName + "%");
                cmd.Parameters.AddWithValue("@LastName", LastName + "%");
                using SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    Customer temp = new Customer();
                    temp.CustomerId = reader.GetInt32(0);
                    temp.FirstName = reader.GetString(1);
                    temp.LastName = reader.GetString(2);
                    temp.Country = reader.GetString(3);
                    if (!reader.IsDBNull(reader.GetOrdinal("PostalCode")))
                        temp.PostalCode = reader.GetString(4);
                    if (!reader.IsDBNull(reader.GetOrdinal("Phone")))
                        temp.Phone = reader.GetString(5);
                    temp.Email = reader.GetString(6);
                    customer = temp;
                }
                else
                {
                    throw new Exception("Some annoying mistake in database or some shit");
                }
                // Reader   
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
                //Log the fucking error
            }
            return customer;
        }

        public List<Customer> GetPageOfCustomers(int offset, int limit)
        {
            List<Customer> CustomerList = new List<Customer>();
            string sql = "SELECT CustomerId, FirstName, LastName, Country, PostalCode, Phone, Email FROM Customer ORDER BY CustomerId OFFSET @Offset ROWS FETCH NEXT @Limit ROWS ONLY";
            try
            {
                using SqlConnection conn = new SqlConnection((ConnectionHelper.GetConnectionString()));
                conn.Open();
                using SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@Offset", offset -1);
                cmd.Parameters.AddWithValue("@Limit", limit);
                using SqlDataReader reader = cmd.ExecuteReader();


                while (reader.Read())
                {
                    //Handle result
                    Customer temp = new Customer();
                    temp.CustomerId = reader.GetInt32(0);
                    temp.FirstName = reader.GetString(1);
                    temp.LastName = reader.GetString(2);
                    temp.Country = reader.GetString(3);
                    if (!reader.IsDBNull(reader.GetOrdinal("PostalCode")))
                        temp.PostalCode = reader.GetString(4);
                    if (!reader.IsDBNull(reader.GetOrdinal("Phone")))
                        temp.Phone = reader.GetString(5);
                    temp.Email = reader.GetString(6);
                    CustomerList.Add(temp);
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                //Log the fucking error
            }

            return CustomerList;
        }
        public bool AddNewCustomer(Customer customer)
        {
            bool success = false;
            string sql = "INSERT INTO Customer(FirstName,LastName,Country,PostalCode,Phone,Email) VALUES(@FirstName, @LastName, @Country, @PostalCode, @Phone, @Email)";
            try
            {
                using SqlConnection conn = new SqlConnection((ConnectionHelper.GetConnectionString()));
                conn.Open();
                using SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@FirstName", customer.FirstName);
                cmd.Parameters.AddWithValue("@LastName", customer.LastName);
                cmd.Parameters.AddWithValue("@Country", customer.Country);
                cmd.Parameters.AddWithValue("@PostalCode", customer.PostalCode);
                cmd.Parameters.AddWithValue("@Phone", customer.Phone);
                cmd.Parameters.AddWithValue("@Email", customer.Email);
                success = cmd.ExecuteNonQuery() > 0;
            }
            catch (Exception ex)
            {
                //Some message indicating customer not added.
                Console.WriteLine(ex.Message);
            }
            Console.WriteLine($"Customer with name: {customer.FirstName} {customer.LastName} added");
            return success;
        }
        public bool DeleteCustomer(string id)
        {
            throw new NotImplementedException();
        }

        public bool UpdateCustomer(Customer customer)
        {
            bool success = false;
            using SqlConnection conn = new SqlConnection(ConnectionHelper.GetConnectionString());
            conn.Open();
            string sql = "UPDATE Customer SET FirstName = @FirstName, " +
                " LastName = @LastName, " +
                " Country = @Country, " +
                "PostalCode = @PostalCode, " +
                "Phone = @Phone, " +
                "Email = @Email WHERE CustomerId = @CustomerId";
            try
            {
                using SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@CustomerId", customer.CustomerId);
                cmd.Parameters.AddWithValue("@FirstName", customer.FirstName);
                cmd.Parameters.AddWithValue("@LastName", customer.LastName);
                cmd.Parameters.AddWithValue("@Country", customer.Country);
                cmd.Parameters.AddWithValue("@PostalCode", customer.PostalCode);
                cmd.Parameters.AddWithValue("@Phone", customer.Phone);
                cmd.Parameters.AddWithValue("@Email", customer.Email);
                success = cmd.ExecuteNonQuery() > 0 ? true : false;
            }
            catch (Exception ex)
            {
                //Some message indicating customer updated.
                Console.WriteLine(ex.Message);
                Console.WriteLine(":( :(");
                return false;
            }
            Console.WriteLine($"Customer updated");
            return success;
        }
        public List<CustomerCountries> GetCountriesFromCustomers()
        {
            List<CustomerCountries> customerCountries = new();
            using SqlConnection conn = new SqlConnection(ConnectionHelper.GetConnectionString());
            conn.Open();
            string sql = "SELECT Country, COUNT(CustomerId) NumberOfCustomers FROM dbo.Customer GROUP BY Country ORDER BY NumberOfCustomers DESC";
            SqlCommand command = new SqlCommand(sql, conn);
            using SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                customerCountries.Add(new CustomerCountries(
                    reader.GetString(0),
                    reader.GetInt32(1)
                    ));
            }
            return customerCountries;
        }

        public List<CustomerSpending> GetCustomerSpenders()
        {
            List<CustomerSpending> customerSpenders = new List<CustomerSpending>();
            string sql = "SELECT CustomerId, SUM(Total) TotalAmount FROM Invoice GROUP BY CustomerId ORDER BY TotalAmount DESC";
            try
            {
                using SqlConnection connection = new SqlConnection(ConnectionHelper.GetConnectionString());
                connection.Open();
                SqlCommand command = new SqlCommand(sql, connection);
                using SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {

                    customerSpenders.Add(new CustomerSpending(
                        reader.GetInt32(0),
                        reader.GetDecimal(1)
                        ));
                }
            }
            catch (Exception ex)
            {
                //log ex
            }
            return customerSpenders;
        }

        public List<CustomerGenre> GetFavoriteGenreCustomer(int id)
        {
            string sql = "SELECT Genre.Name,  COUNT(Genre.GenreId) PopularGenre FROM Invoice " +
                    "INNER JOIN InvoiceLine on Invoice.InvoiceId = InvoiceLine.InvoiceId " +
                    "INNER JOIN Track on InvoiceLine.TrackId = Track.TrackId " +
                    "INNER JOIN Genre on Track.GenreId = Genre.GenreId " +
                    "WHERE CustomerId = @CustomerId " +
                    "GROUP BY Genre.Name " +
                    "ORDER BY PopularGenre DESC";
            List<CustomerGenre> favoriteGenres = new List<CustomerGenre>();
            try
            {
                using SqlConnection conn = new SqlConnection(ConnectionHelper.GetConnectionString());
                conn.Open();

                SqlCommand command = new SqlCommand(sql, conn);
                command.Parameters.AddWithValue("@CustomerId", id);
                using SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    favoriteGenres.Add(new CustomerGenre(

                        reader.GetString(0),
                        reader.GetInt32(1)
                    ));
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }


            return favoriteGenres;
        }
    }
}

