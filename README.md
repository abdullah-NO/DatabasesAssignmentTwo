# DatabaseAssignment2
This assignment consists of two sub projects. The first is a series of queries that creates and populates, and manipulates a database. The second project is a C# .net console application that also does a series of database manipulation of a given database.

## Prerequisites
You need the following:
ssms: https://learn.microsoft.com/en-us/sql/ssms/download-sql-server-management-studio-ssms?view=sql-server-2017
sql express: https://www.microsoft.com/en-us/sql-server/sql-server-downloads
sql.client from nuget package manager: https://www.nuget.org/packages/Microsoft.Data.SqlClient

## How to use first project
run the sql scripts sequencially through the SSMS from 01-09

## How to use the second project
setup your own connection string to match your computer and express service
uncomment the function that you want to use.

These are the functions that the application provides:
            //Task 1 , displays all customers
            SelectAll(repository);
            //Task 2 , displays a customer sorted by Id number
            Select(repository, 8);
            //Task 3 , displays a customer sorted by name
            ReadCustomerByName(repository, "Dan", "Mill");
            //Task 4 , displays a range of customers sorted by Id, for instance : from Id 3 to Id 10
            GetPage(repository);
            //Task 5 , adds a new customer to database
            AddCustomer(repository);
            //Task 6, updates an excisting customer
            UpdateCustomer(repository);
            //Task 7, shows numbers of customers in different countries and is sorted in a descending order
            DescendingCountries(repository);
            //Task 8, shows highest customer spenders in a descending order 
            HighestSpenders(repository);
            //Task 9 shows a genrefavorite based on track record list, invoice and 
            GetFavoriteGenreById(repository, 9);
## Authors
The authors of this project are Sverre (Sverdet) Vinje and Abdullah (Abu) Hussain
