using DataBaseAssigmentConsoleApp.Models;
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
                using(SqlConnection conn = new SqlConnection(ConnectionHelper.GetConnectionString())) 
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
                                temp.Email= reader.GetString(6);
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
        public bool AddNewCustomer(Customer customer)
        {
            throw new NotImplementedException();
        }

        public bool DeleteCustomer(string id)
        {
            throw new NotImplementedException();
        }

        public bool UpdateCustomer(Customer customer)
        {
            throw new NotImplementedException();
        }
    }
}
