using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace C969_Scheduling_App
{
    
    internal class SqlConnection
    {
        private static MySqlConnection _connection;
        private static readonly object _lock = new object();

        private SqlConnection() { }

        public static MySqlConnection GetConnection()
        {
            if (_connection == null)
            {
                lock (_lock)
                {
                    if (_connection == null)
                    {
                        string connectionString = "server=127.0.0.1;user=sqlUser;database=client_schedule;port=3306;password=Passw0rd!";
                        _connection = new MySqlConnection(connectionString);
                    }
                }
            }

            if (_connection.State != System.Data.ConnectionState.Open)
            {
                _connection.Open();
            }

            return _connection;
        }
    }
}
