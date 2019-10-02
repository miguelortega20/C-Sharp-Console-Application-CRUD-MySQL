using System;
using MySql.Data.MySqlClient;

namespace CRUD1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("C#: Conectando con MySQL");

            try{

                string connectionString;
                connectionString = "server=localhost;port=3306;uid=root;pwd='';database=crud;charset=utf8;SslMode=none;";
                MySqlConnection con = new MySqlConnection(connectionString);

                con.Open();
                Console.WriteLine("Conection is " + con.State.ToString() + Environment.NewLine);


                MySqlCommand com = con.CreateCommand();

                con.Close();
                Console.WriteLine("Conection is " + con.State.ToString() + Environment.NewLine);

            }catch(MySql.Data.MySqlClient.MySqlException ex){
                Console.Write("Error: " + ex.Message.ToString());
            }

            Console.WriteLine("Press any key to exit...");
            Console.Read();
        }
    }
}
