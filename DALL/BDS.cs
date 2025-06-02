using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DALL
{
    public class BDS
    {
        protected readonly string connectionString;

        protected SqlConnection Connection { get; }

        public BDS()
        {
            connectionString = "Server=LAPTOP-F5R60DKK;Database=smartwallet;Integrated Security=True;";
        }

        public SqlConnection AbrirConexion()
        {
            var connection = new SqlConnection(connectionString);
            connection.Open();
            return connection;
        }

        public void CloseConnection(SqlConnection connection)
        {
            if (connection != null && connection.State != ConnectionState.Closed)
            {
                connection.Close();
                connection.Dispose();
            }
        }
    }
}
