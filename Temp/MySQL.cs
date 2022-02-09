using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Temp
{
    class MySQL
    {
        public static MySqlConnection Connect()
        {
            //forming variables for connection string
            string server = "localhost";
            string database = "testdb";
            string username = "root";
            string password = "password";
            string constring = "SERVER=" + server + ";" + "DATABASE=" + database + ";" + "UID=" + username + ";" + "PASSWORD=" + password + ";";

            //opening sql database connection
            MySqlConnection conn = new MySqlConnection(constring);
            
            return conn;
        }
        
        public static void LoginUser()
        {
            //class within class from Encrytion.cs
            Encryption.Hashing hash = new Encryption.Hashing();
            //need to somehow call the GetHashString subroutine from Encrytion.Hashing and be able to send a parameter to it
            

            //user input useremail
            Console.WriteLine("Enter useremail: ");
            string UID = Console.ReadLine();

            //user input password and hash.
            //Reason to hash is for security as its very difficult to 'unhash' a string.
            Console.WriteLine("Enter password: ");
            string pass = GetHashString(Console.ReadLine());

            //select everything from sql database and check if hashed password matches
            string query = "select * from users where useremail = '" + UID + "'";
            MySqlCommand cmd = new MySqlCommand(query, conn);
            MySqlDataReader reader = cmd.ExecuteReader();


            while (reader.Read())
            {
                //assigning username and userpassword from database to static variables declared at the start
                resultusername = reader["useremail"].ToString();
                resultuserpass = reader["userpassword"].ToString();
            }


            //code to find if hashed password match
            if (GetHashString(resultuserpass) == pass)
            {
                Console.WriteLine("Logged in!");
            }
            else
            {
                Console.WriteLine("No work");
            }
        }
        public static void RegisterUser()
        {

        }
    }
}
