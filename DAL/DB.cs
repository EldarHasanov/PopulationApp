using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace DAL
{
    public class DB
    {
        private MySqlConnection connection;

        public void setConnection(string UID, string Pass)
        {
            connection = new MySqlConnection("server=localhost;database=country_info;password=" + Pass + ";uid=" + UID + ";");
        }

        public void setConnection()
        {
            connection = new MySqlConnection("server=localhost;database=country_info;password=1111;uid=admin;");
        }

        public void openConnection()
        {
            if (connection.State == System.Data.ConnectionState.Closed)
            {
                connection.Open();
            }
        }

        public void closeConnection()
        {
            if (connection.State == System.Data.ConnectionState.Open)
            {
                connection.Close();
            }
        }

        public MySqlConnection getConnection()
        {
            return connection;
        }
    }
}
