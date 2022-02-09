using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Security.Cryptography;

namespace Temp
{
    class Program
    {
        static string resultusername;
        static string resultuserpass;

        //hashing code found from https://stackoverflow.com/questions/3984138/hash-string-in-c-sharp/21109622
        public static byte[] GetHash(string inputString)
        {
            using (HashAlgorithm algorithm = SHA256.Create())
                return algorithm.ComputeHash(Encoding.UTF8.GetBytes(inputString));
        }

        public static string GetHashString(string inputString)
        {
            StringBuilder sb = new StringBuilder();
            foreach (byte b in GetHash(inputString))
                sb.Append(b.ToString("X2"));

            return sb.ToString();
        }

        static void Main(string[] args)
        {
            //initiating connection from MySQL.cs
            MySqlConnection conn = MySQL.Connect();
            conn.Open();

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
            Console.ReadKey();

        }
    }
}
