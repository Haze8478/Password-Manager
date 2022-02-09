using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Connect_to_database
{
    public class Connect
    {
        public static void Main(string[] args)
        {
            //forming variables for connection string
            string server = "localhost";
            string database = "testdb";
            string username = "root";
            string password = "password";
            string constring = "SERVER=" + server + ";" + "DATABASE=" + database + ";" + "UID=" + username + ";" + "PASSWORD=" + password + ";";

            //opening sql database connection
            MySqlConnection conn = new MySqlConnection(constring);
            conn.Open();
        }
    }
}
