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
        private static readonly string ConnectionString = "server=127.0.0.1;user=sqlUser;database=client_schedule;port=3306;password=Passw0rd!";

        public static MySqlConnection GetConnection()
        {
            return new MySqlConnection(ConnectionString); // Always return a new connection instance
        }
    }
}
