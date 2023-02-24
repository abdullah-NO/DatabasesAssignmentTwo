using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBaseAssigmentConsoleApp.Repositories
{
    public class ConnectionHelper
    {
        public static string GetConnectionString()
        {
            SqlConnectionStringBuilder connectionStringBuilder = new SqlConnectionStringBuilder();
            string connectionStringAbdullah = "DESKTOP-36U8NTB\\SQLEXPRESS02";
            string connectionStringSverre = "N-NO-01-01-4564\\SQLEXPRESS";
            string connectionStringNICHOLAS = "PUT YOUR OWN HERE :)";

            //switch connection string for the DataSource when you use another pc.
            connectionStringBuilder.DataSource = connectionStringAbdullah;
            connectionStringBuilder.InitialCatalog = "Chinook";
            connectionStringBuilder.IntegratedSecurity = true;
            connectionStringBuilder.TrustServerCertificate= true;
            return connectionStringBuilder.ConnectionString;
        }
    }
}
